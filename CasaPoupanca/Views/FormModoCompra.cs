using CasaPoupanca.Controllers;
using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CasaPoupanca
{
    public partial class FormModoCompra : Form
    {
        private int _compraId;
        private decimal _orcamentoDisponivel;
        private ModoCompraController _controller;

        public FormModoCompra(int compraId)
        {
            InitializeComponent();
            _compraId = compraId;
            _controller = new ModoCompraController();

            try
            {
                CarregarDadosCompra();
                CarregarOrcamento();
                CarregarItensPrevistos();
                CarregarItensNaoPrevistos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }

        private void CarregarDadosCompra()
        {
            var compra = _controller.GetCompraById(_compraId);
            if (compra != null)
            {
                this.Text = $"Modo Compra - {compra.Nome}";
            }
        }

        private void CarregarOrcamento()
        {
            _orcamentoDisponivel = _controller.GetOrcamentoDisponivel(Session.UtilizadorId);
            labelOrcamentoDisponivel.Text = $"Orçamento Disponível: {_orcamentoDisponivel:C}";

            if (_orcamentoDisponivel < 0)
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Red;
                labelAviso.Text = "ATENÇÃO: Orçamento ultrapassado!";
            }
            else
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Green;
                labelAviso.Text = "";
            }
        }

        private void CarregarItensPrevistos()
        {
            var itens = _controller.GetItensPrevistos(_compraId);
            listBoxItensPrevistos.DataSource = null;
            listBoxItensPrevistos.DataSource = itens;

            // Usar evento Format para mostrar texto personalizado
            listBoxItensPrevistos.Format -= ListBoxItensPrevistos_Format;
            listBoxItensPrevistos.Format += ListBoxItensPrevistos_Format;
        }

        private void ListBoxItensPrevistos_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ItemCompra item)
            {
                // Ajusta estas propriedades conforme o teu modelo
                string artigoNome = item.Artigo?.Nome ?? $"Artigo #{item.ArtigoId}";
                e.Value = $"{artigoNome} | Previsto: {item.QuantidadePrevista} x €{item.PrecoUnitario:F2} = €{(item.QuantidadePrevista * item.PrecoUnitario):F2}";
            }
        }

        private void CarregarItensNaoPrevistos()
        {
            var itens = _controller.GetItensNaoPrevistos(_compraId);
            listBoxItensNaoPrevistos.DataSource = null;
            listBoxItensNaoPrevistos.DataSource = itens;

            listBoxItensNaoPrevistos.Format -= ListBoxItensNaoPrevistos_Format;
            listBoxItensNaoPrevistos.Format += ListBoxItensNaoPrevistos_Format;
        }

        private void ListBoxItensNaoPrevistos_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ItemCompra item)
            {
                string artigoNome = item.Artigo?.Nome ?? $"Artigo #{item.ArtigoId}";
                e.Value = $"{artigoNome} | Adquirido: {item.QuantidadeAdquirida} x €{item.PrecoUnitario:F2} = €{(item.QuantidadeAdquirida * item.PrecoUnitario):F2}";
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddItemNaoPrevisto_Click(object sender, EventArgs e)
        {
            FormItemNaoPrevisto itemNaoPrevisto = new FormItemNaoPrevisto(_compraId);
            itemNaoPrevisto.ShowDialog();
            // Recarregar após adicionar
            CarregarItensNaoPrevistos();
            CarregarOrcamento();
        }

        private void buttonFecharCompra_Click(object sender, EventArgs e)
        {
            try
            {
                int itensNaoAdquiridos = _controller.CountItensNaoAdquiridos(_compraId);

                if (itensNaoAdquiridos > 0)
                {
                    DialogResult resultado = MessageBox.Show(
                        $"Ainda existem {itensNaoAdquiridos} itens previstos não adquiridos.\n\nDeseja fechar a compra mesmo assim?",
                        "Aviso", MessageBoxButtons.YesNo);

                    if (resultado != DialogResult.Yes)
                        return;
                }

                DialogResult resultadoFinal = MessageBox.Show(
                    "Tem certeza que deseja fechar esta compra?\n\nApós fechada, não poderá mais ser alterada!",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultadoFinal == DialogResult.Yes)
                {
                    _controller.FecharCompra(_compraId, Session.UtilizadorId);
                    MessageBox.Show("Compra fechada com sucesso!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao fechar compra: {ex.Message}");
            }
        }

        private void buttonAdquirirItemPrevisto_Click(object sender, EventArgs e)
        {
            if (listBoxItensPrevistos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item previsto para adquirir");
                return;
            }

            int quantidade = (int)numericUpDownQuantidadeAdquirir.Value;
            decimal precoUnitario = numericUpDownPrecoUnitarioAdquirir.Value;

            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero");
                return;
            }

            if (precoUnitario <= 0)
            {
                MessageBox.Show("O preço unitário deve ser maior que zero");
                return;
            }

            try
            {
                var item = (ItemCompra)listBoxItensPrevistos.SelectedItem;

                if (quantidade > item.QuantidadePrevista)
                {
                    DialogResult result = MessageBox.Show(
                        $"A quantidade a adquirir ({quantidade}) é maior que a prevista ({item.QuantidadePrevista}).\n\nDeseja continuar?",
                        "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                        return;
                }

                _controller.AdquirirItemPrevisto(item.Id, quantidade, precoUnitario);

                MessageBox.Show("Item adquirido com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarOrcamento();
                CarregarItensPrevistos();
                CarregarItensNaoPrevistos();

                numericUpDownQuantidadeAdquirir.Value = 1;
                numericUpDownPrecoUnitarioAdquirir.Value = 0;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Erro ao adquirir item: {ex.Message}");
            }
        }

        private void buttonAdquirirItemNaoPrevisto_Click(object sender, EventArgs e)
        {
            if (listBoxItensNaoPrevistos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item não previsto para adquirir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantidade = (int)numericUpDownQuantidadeAdquirir.Value;
            decimal precoUnitario = numericUpDownPrecoUnitarioAdquirir.Value;

            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (precoUnitario <= 0)
            {
                MessageBox.Show("O preço unitário deve ser maior que zero.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var item = (ItemCompra)listBoxItensNaoPrevistos.SelectedItem;

                _controller.AdquirirItemNaoPrevisto(item.Id, quantidade, precoUnitario);

                MessageBox.Show("Item não previsto adquirido com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarOrcamento();
                CarregarItensNaoPrevistos();
                CarregarItensPrevistos(); // Recarregar também por precaução

                numericUpDownQuantidadeAdquirir.Value = 1;
                numericUpDownPrecoUnitarioAdquirir.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adquirir item: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}