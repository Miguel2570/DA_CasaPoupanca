using CasaPoupanca.Controllers;
using CasaPoupança.database;
using CasaPoupanca.Helpers;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            listBoxItensPrevistos.DisplayMember = "DisplayText";
            listBoxItensPrevistos.ValueMember = "Id";
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddItemNaoPrevisto_Click(object sender, EventArgs e)
        {
            FormItemNaoPrevisto itemNaoPrevisto = new FormItemNaoPrevisto(_compraId);
            itemNaoPrevisto.ShowDialog();
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

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonAdquirirItensPrevistos_Click(object sender, EventArgs e)
        {
            if (listBoxItensPrevistos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item para adquirir.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxQuantidade.Text))
            {
                MessageBox.Show("Insira a quantidade!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPrecoUnitario.Text))
            {
                MessageBox.Show("Insira o preço!");
                return;
            }

            int quantidade;
            if (!int.TryParse(textBoxQuantidade.Text, out quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Insira uma quantidade válida!");
                return;
            }

            decimal precoUnitario;
            if (!decimal.TryParse(textBoxPrecoUnitario.Text, out precoUnitario) || precoUnitario <= 0)
            {
                MessageBox.Show("Insira um preço válido!");
                return;
            }

            try
            {
                var item = (ItemCompra)listBoxItensPrevistos.SelectedItem;

                if (quantidade > item.QuantidadePrevista - item.QuantidadeAdquirida)
                {
                    DialogResult resultado = MessageBox.Show(
                        $"A quantidade a adquirir ({quantidade}) é maior que a quantidade prevista por adquirir.\n\nDeseja continuar?",
                        "Aviso", MessageBoxButtons.YesNo);

                    if (resultado != DialogResult.Yes)
                        return;
                }

                decimal subtotal = quantidade * precoUnitario;

                if (subtotal > _orcamentoDisponivel && _orcamentoDisponivel >= 0)
                {
                    DialogResult resultado = MessageBox.Show(
                        $"Este item custa {subtotal:C}. Orçamento disponível: {_orcamentoDisponivel:C}\n\nDeseja continuar?",
                        "Aviso de Orçamento", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resultado != DialogResult.Yes)
                        return;
                }

                _controller.AdquirirItem(item.Id, quantidade, precoUnitario);

                MessageBox.Show($"Item adquirido: {quantidade} x {precoUnitario:C} = {subtotal:C}");

                CarregarOrcamento();
                CarregarItensPrevistos();
                textBoxQuantidade.Clear();
                textBoxPrecoUnitario.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adquirir item: {ex.Message}");
            }
        }

    }
}
