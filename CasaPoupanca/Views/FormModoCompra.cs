using CasaPoupanca.Controllers;
using CasaPoupanca.models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CasaPoupanca
{
    public partial class FormModoCompra : Form
    {
        private int _compraId;
        private decimal _orcamentoDisponivel;
        private CompraController _compraController;
        private ModoCompraController _controller;
        private Compra _compraAtual;

        public FormModoCompra(int compraId)
        {
            InitializeComponent();
            _compraId = compraId;
            _compraController = new CompraController();
            _controller = new ModoCompraController();

            ConfigurarControles();

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

        private void ConfigurarControles()
        {
            numericUpDownQuantidadeAdquirir.Minimum = 1;
            numericUpDownQuantidadeAdquirir.Maximum = 999999;
            numericUpDownQuantidadeAdquirir.Value = 1;

            numericUpDownPrecoUnitarioAdquirir.Minimum = 0.01M;
            numericUpDownPrecoUnitarioAdquirir.Maximum = 1000000M;
            numericUpDownPrecoUnitarioAdquirir.DecimalPlaces = 2;
            numericUpDownPrecoUnitarioAdquirir.Value = 0.01M;
        }

        private void CarregarDadosCompra()
        {
            _compraAtual = _controller.GetCompraById(_compraId);
            if (_compraAtual != null)
            {
                this.Text = $"Modo Compra - {_compraAtual.Nome}";
                if (labelNomeCompra != null)
                    labelNomeCompra.Text = _compraAtual.Nome;
            }
        }

        private void CarregarOrcamento()
        {
            _orcamentoDisponivel = _controller.GetOrcamentoDisponivel(Session.UtilizadorId);
            labelOrcamentoDisponivel.Text = $"Orçamento Disponível: {_orcamentoDisponivel:C}";

            decimal totalGasto = _controller.GetTotalGastoCompra(_compraId);
            decimal restante = _orcamentoDisponivel - totalGasto;

            if (restante < 0)
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Red;
                labelAviso.Text = "ATENÇÃO: Orçamento ultrapassado!";
                labelAviso.ForeColor = System.Drawing.Color.Red;
                labelAviso.Visible = true;
            }
            else if (restante < (_orcamentoDisponivel * 0.1M) && _orcamentoDisponivel > 0)
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Orange;
                labelAviso.Text = "ATENÇÃO: Orçamento a terminar!";
                labelAviso.ForeColor = System.Drawing.Color.Orange;
                labelAviso.Visible = true;
            }
            else
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Green;
                labelAviso.Visible = false;
            }
        }

        private void CarregarItensPrevistos()
        {
            var itens = _controller.GetItensPrevistos(_compraId);
            listBoxItensPrevistos.DataSource = null;
            listBoxItensPrevistos.DataSource = itens;
            listBoxItensPrevistos.DisplayMember = "DisplayName";
            listBoxItensPrevistos.ValueMember = "Id";
        }

        private void CarregarItensNaoPrevistos()
        {
            var itens = _controller.GetItensNaoPrevistos(_compraId);
            listBoxItensNaoPrevistos.DataSource = null;
            listBoxItensNaoPrevistos.DataSource = itens;
            listBoxItensNaoPrevistos.DisplayMember = "DisplayName";
            listBoxItensNaoPrevistos.ValueMember = "Id";
        }

        private void LimparCamposAdquirir()
        {
            numericUpDownQuantidadeAdquirir.Value = 1;
            numericUpDownPrecoUnitarioAdquirir.Value = 0.01M;
            listBoxItensPrevistos.ClearSelected();
        }

        private void buttonAddItemNaoPrevisto_Click(object sender, EventArgs e)
        {
            FormItemNaoPrevisto formItemNaoPrevisto = new FormItemNaoPrevisto(_compraId);
            formItemNaoPrevisto.ShowDialog();

            CarregarItensNaoPrevistos();
            CarregarOrcamento();
        }

        private void buttonFecharCompra_Click(object sender, EventArgs e)
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
                "Confirmar Fecho", MessageBoxButtons.YesNo);

            if (resultadoFinal == DialogResult.Yes)
            {
                try
                {
                    _controller.FecharCompra(_compraId, Session.UtilizadorId);

                    MessageBox.Show("Compra fechada com sucesso!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao fechar compra: {ex.Message}");
                }
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja sair? As alterações não salvas serão perdidas.",
                "Sair", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void listBoxItensPrevistos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItensPrevistos.SelectedItem is ItemCompra item)
            {
                numericUpDownQuantidadeAdquirir.Value = Math.Min(item.QuantidadePrevista, 1);
                numericUpDownPrecoUnitarioAdquirir.Value = item.PrecoUnitario;
            }
        }

        private void buttonRemoverItemNaoPrevisto_Click(object sender, EventArgs e)
        {
            if (listBoxItensNaoPrevistos.SelectedItem is ItemCompra item)
            {
                DialogResult resultado = MessageBox.Show(
                    $"Remover '{item.Artigo?.Nome}' da compra?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        _controller.RemoverItemNaoPrevisto(item.Id);
                        MessageBox.Show("Item removido com sucesso!");
                        CarregarItensNaoPrevistos();
                        CarregarOrcamento();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao remover item: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um item não previsto para remover.", "Aviso");
            }
        }

        private void buttonAdquirirItemNaoPrevisto_Click(object sender, EventArgs e)
        {
            if (!(listBoxItensNaoPrevistos.SelectedItem is ItemCompra item))
            {
                MessageBox.Show("Selecione um item não previsto para adquirir.", "Aviso");
                return;
            }

            try
            {
                int quantidade = (int)numericUpDownQuantidadeAdquirir.Value;
                decimal preco = numericUpDownPrecoUnitarioAdquirir.Value;

                _controller.AdquirirItemNaoPrevisto(item.Id, quantidade, preco);

                MessageBox.Show($"Item '{item.Artigo?.Nome}' adquirido com sucesso!");

                CarregarItensNaoPrevistos();
                CarregarOrcamento();
                LimparCamposAdquirir();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adquirir item: {ex.Message}");
            }
        }

        private void buttonAdquirirItemPrevisto_Click(object sender, EventArgs e)
        {
            if (!(listBoxItensPrevistos.SelectedItem is ItemCompra item))
            {
                MessageBox.Show("Selecione um item previsto para adquirir.", "Aviso");
                return;
            }

            try
            {
                int quantidade = (int)numericUpDownQuantidadeAdquirir.Value;
                decimal preco = numericUpDownPrecoUnitarioAdquirir.Value;

                _controller.AdquirirItemPrevisto(item.Id, quantidade, preco);

                MessageBox.Show($"Item '{item.Artigo?.Nome}' adquirido com sucesso!");

                CarregarItensPrevistos();
                CarregarOrcamento();
                LimparCamposAdquirir();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adquirir item: {ex.Message}");
            }
        }

        private void listBoxItensPrevistos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBoxItensPrevistos.SelectedItem is ItemCompra item)
            {
                int qtd = item.QuantidadeAdquirida > 0 ? item.QuantidadeAdquirida : item.QuantidadePrevista;
                numericUpDownQuantidadeAdquirir.Value = Math.Max(qtd, 1);
                numericUpDownPrecoUnitarioAdquirir.Value = item.PrecoUnitario > 0 ? item.PrecoUnitario : 0.01M;
            }
        }

        private void listBoxItensNaoPrevistos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItensNaoPrevistos.SelectedItem is ItemCompra item)
            {
                numericUpDownQuantidadeAdquirir.Value = item.QuantidadeAdquirida > 0 ? item.QuantidadeAdquirida : 1;
                numericUpDownPrecoUnitarioAdquirir.Value = item.PrecoUnitario > 0 ? item.PrecoUnitario : 0.01M;
            }
        }
    }
}