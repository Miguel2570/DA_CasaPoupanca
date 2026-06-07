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
        private ModoCompraController _controller;
        private Compra _compraAtual;

        public FormModoCompra(int compraId)
        {
            InitializeComponent();
            _compraId = compraId;
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
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            listBoxItensPrevistos.Format -= ListBoxItensPrevistos_Format;
            listBoxItensPrevistos.Format += ListBoxItensPrevistos_Format;
        }

        private void ListBoxItensPrevistos_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is ItemCompra item)
            {
                string artigoNome = item.Artigo?.Nome ?? $"Artigo #{item.ArtigoId}";
                decimal totalPrevisto = item.QuantidadePrevista * item.PrecoUnitario;
                e.Value = $"{artigoNome} | Qtd: {item.QuantidadePrevista} x €{item.PrecoUnitario:F2} = €{totalPrevisto:F2}";
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
                string artigoNome = item.Artigo?.Nome ?? $"Item #{item.Id}";
                decimal totalAdquirido = item.QuantidadeAdquirida * item.PrecoUnitario;
                e.Value = $"{artigoNome} | Qtd: {item.QuantidadeAdquirida} x €{item.PrecoUnitario:F2} = €{totalAdquirido:F2}";
            }
        }

        private void LimparCamposAdquirir()
        {
            numericUpDownQuantidadeAdquirir.Value = 1;
            numericUpDownPrecoUnitarioAdquirir.Value = 0.01M;
            listBoxItensPrevistos.ClearSelected();
        }

        private void buttonAdquirirItemPrevisto_Click(object sender, EventArgs e)
        {
            if (listBoxItensPrevistos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item previsto para adquirir!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantidade = (int)numericUpDownQuantidadeAdquirir.Value;
            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero!", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal precoUnitario = numericUpDownPrecoUnitarioAdquirir.Value;
            if (precoUnitario <= 0)
            {
                MessageBox.Show("O preço unitário deve ser maior que zero!", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal totalCompra = quantidade * precoUnitario;
            decimal totalGastoAposCompra = _controller.GetTotalGastoCompra(_compraId) + totalCompra;

            if (totalGastoAposCompra > _orcamentoDisponivel && _orcamentoDisponivel > 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Esta compra vai custar {totalCompra:C}. Isso fará ultrapassar o orçamento disponível ({_orcamentoDisponivel:C}).\n\nDeseja continuar?",
                    "Aviso de Orçamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
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

                MessageBox.Show($"Item adquirido com sucesso!\n\nTotal: {totalCompra:C}", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarOrcamento();
                CarregarItensPrevistos();
                CarregarItensNaoPrevistos();
                LimparCamposAdquirir();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adquirir item: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            decimal totalCompra = quantidade * precoUnitario;
            decimal totalGastoAposCompra = _controller.GetTotalGastoCompra(_compraId) + totalCompra;

            if (totalGastoAposCompra > _orcamentoDisponivel && _orcamentoDisponivel > 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Este item vai custar {totalCompra:C}. Isso fará ultrapassar o orçamento disponível ({_orcamentoDisponivel:C}).\n\nDeseja continuar?",
                    "Aviso de Orçamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;
            }

            try
            {
                var item = (ItemCompra)listBoxItensNaoPrevistos.SelectedItem;

                _controller.AdquirirItemNaoPrevisto(item.Id, quantidade, precoUnitario);

                MessageBox.Show($"Item não previsto adquirido com sucesso!\n\nTotal: {totalCompra:C}", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CarregarOrcamento();
                CarregarItensNaoPrevistos();
                CarregarItensPrevistos();

                numericUpDownQuantidadeAdquirir.Value = 1;
                numericUpDownPrecoUnitarioAdquirir.Value = 0.01M;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adquirir item: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado != DialogResult.Yes)
                    return;
            }

            DialogResult resultadoFinal = MessageBox.Show(
                "Tem certeza que deseja fechar esta compra?\n\nApós fechada, não poderá mais ser alterada!",
                "Confirmar Fecho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultadoFinal == DialogResult.Yes)
            {
                try
                {
                    _controller.FecharCompra(_compraId, Session.UtilizadorId);

                    MessageBox.Show("Compra fechada com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao fechar compra: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja sair? As alterações não salvas serão perdidas.",
                "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
    }
}