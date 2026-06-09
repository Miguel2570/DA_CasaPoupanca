using CasaPoupanca.Controllers;
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
                CarregarListaFinal();
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
                labelNomeCompra.Text = _compraAtual.Nome;
            }
        }

        private void CarregarOrcamento()
        {
            int mes = _compraAtual?.DataCriacao.Month ?? DateTime.Now.Month;
            int ano = _compraAtual?.DataCriacao.Year ?? DateTime.Now.Year;

            _orcamentoDisponivel = _controller.GetOrcamentoDisponivel(Session.UtilizadorId, mes, ano);
            decimal totalGasto = _controller.GetTotalGastoCompra(_compraId);
            decimal restante = _orcamentoDisponivel - totalGasto;

            labelOrcamentoDisponivel.Text = $"Orçamento: {restante:C2}";

            if (restante < 0)
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Red;
                labelAviso.Text = "⚠️ ATENÇÃO: Orçamento ultrapassado!";
                labelAviso.ForeColor = System.Drawing.Color.Red;
                labelAviso.Visible = true;
            }
            else if (restante < (_orcamentoDisponivel * 0.1M) && _orcamentoDisponivel > 0)
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Orange;
                labelAviso.Text = "⚠️ ATENÇÃO: Orçamento a terminar!";
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
            var itens = _controller.GetItensPrevistos(_compraId)
        .Where(i => i.QuantidadeAdquirida == 0)
        .ToList();

            if (itens.Count == 0)
            {
                listBoxItensPrevistos.DataSource = null;
                listBoxItensPrevistos.Items.Clear();
            }
            else
            {
                var itensFormatados = itens.Select(i => new
                {
                    i.Id,
                    Display = $"📋 {i.Artigo?.Nome} - Previsto: {i.QuantidadePrevista} x €{i.PrecoUnitario:F2}"
                }).ToList();

                listBoxItensPrevistos.DataSource = null;
                listBoxItensPrevistos.DataSource = itensFormatados;
                listBoxItensPrevistos.DisplayMember = "Display";
                listBoxItensPrevistos.ValueMember = "Id";
            }
        }

        private void CarregarItensNaoPrevistos()
        {
            var itens = _controller.GetItensNaoPrevistos(_compraId)
                .Where(i => i.QuantidadeAdquirida == 0)
                .ToList();

            if (itens.Count == 0)
            {
                listBoxItensNaoPrevistos.DataSource = null;
                listBoxItensNaoPrevistos.Items.Clear();
            }
            else
            {
                var itensFormatados = itens.Select(i => new
                {
                    i.Id,
                    Display = $"🛒 {i.Artigo?.Nome ?? i.Observacao} - {i.QuantidadePrevista} x €{i.PrecoUnitario:F2}"
                }).ToList();

                listBoxItensNaoPrevistos.DataSource = null;
                listBoxItensNaoPrevistos.DataSource = itensFormatados;
                listBoxItensNaoPrevistos.DisplayMember = "Display";
                listBoxItensNaoPrevistos.ValueMember = "Id";
            }
        }

        private void LimparCamposAdquirir()
        {
            numericUpDownQuantidadeAdquirir.Value = 1;
            numericUpDownPrecoUnitarioAdquirir.Value = 0.01M;
            listBoxItensPrevistos.ClearSelected();
            listBoxItensNaoPrevistos.ClearSelected();
        }

        // ==================== ITENS PREVISTOS ====================

        private void buttonAdquirirItemPrevisto_Click(object sender, EventArgs e)
        {
            if (listBoxItensPrevistos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item previsto para adquirir.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = listBoxItensPrevistos.SelectedItem;
            var itemId = (int)selected.GetType().GetProperty("Id").GetValue(selected);

            int quantidade = (int)numericUpDownQuantidadeAdquirir.Value;
            decimal precoUnitario = numericUpDownPrecoUnitarioAdquirir.Value;

            if (quantidade <= 0)
            {
                MessageBox.Show("Quantidade deve ser maior que zero.", "Validação");
                return;
            }

            if (precoUnitario <= 0)
            {
                MessageBox.Show("Preço deve ser maior que zero.", "Validação");
                return;
            }

            try
            {
                var item = _controller.GetItemCompraById(itemId);
                if (item == null)
                {
                    MessageBox.Show("Item não encontrado.");
                    return;
                }

                decimal totalCompra = quantidade * precoUnitario;

                _controller.AdquirirItemPrevisto(itemId, quantidade, precoUnitario);

                MessageBox.Show($"✅ Item adquirido com sucesso!\n\n{quantidade} x €{precoUnitario:F2} = €{totalCompra:C2}",
                    "Sucesso");

                // Atualizar todas as listas
                CarregarOrcamento();
                CarregarItensPrevistos();
                CarregarListaFinal();
                LimparCamposAdquirir();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adquirir item: {ex.Message}");
            }
        }

        private void buttonRemoverItemPrevisto_Click(object sender, EventArgs e)
        {
            if (listBoxItensPrevistos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item previsto para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = listBoxItensPrevistos.SelectedItem;
            var itemId = (int)selected.GetType().GetProperty("Id").GetValue(selected);

            DialogResult resultado = MessageBox.Show("Remover este item previsto da compra?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _controller.RemoverItemPrevisto(itemId);
                    MessageBox.Show("Item removido com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarItensPrevistos();
                    CarregarOrcamento();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover item: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== ITENS NÃO PREVISTOS ====================

        private void buttonAddItemNaoPrevisto_Click(object sender, EventArgs e)
        {
            FormItemNaoPrevisto formItemNaoPrevisto = new FormItemNaoPrevisto(_compraId);
            formItemNaoPrevisto.ShowDialog();

            CarregarItensNaoPrevistos();
            CarregarOrcamento();
        }

        private void buttonRemoverItemNaoPrevisto_Click(object sender, EventArgs e)
        {
            if (listBoxItensNaoPrevistos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item não previsto para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selected = listBoxItensNaoPrevistos.SelectedItem;
            var itemId = (int)selected.GetType().GetProperty("Id").GetValue(selected);

            DialogResult resultado = MessageBox.Show("Remover este item não previsto da compra?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _controller.RemoverItemNaoPrevisto(itemId);
                    MessageBox.Show("Item removido com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarItensNaoPrevistos();
                    CarregarOrcamento();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover item: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ==================== OUTROS ====================

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
            DialogResult result = MessageBox.Show("Deseja guardar antes de sair?", "Sair",
        MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                buttonSalvar_Click(sender, e);
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                this.Close();
            }
        }

        private void listBoxItensPrevistos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBoxItensPrevistos.SelectedItem != null)
            {
                var selected = listBoxItensPrevistos.SelectedItem;
                var itemId = (int)selected.GetType().GetProperty("Id").GetValue(selected);
                var item = _controller.GetItemCompraById(itemId);

                if (item != null)
                {
                    numericUpDownQuantidadeAdquirir.Value = Math.Min(item.QuantidadePrevista, 1);
                    numericUpDownPrecoUnitarioAdquirir.Value = item.PrecoUnitario;
                }
            }
        }

        private void listBoxItensNaoPrevistos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItensNaoPrevistos.SelectedItem != null)
            {
                var selected = listBoxItensNaoPrevistos.SelectedItem;
                var itemId = (int)selected.GetType().GetProperty("Id").GetValue(selected);
                var item = _controller.GetItemCompraById(itemId);

                if (item != null)
                {
                    numericUpDownQuantidadeAdquirir.Value = item.QuantidadeAdquirida > 0 ? item.QuantidadeAdquirida : 1;
                    numericUpDownPrecoUnitarioAdquirir.Value = item.PrecoUnitario > 0 ? item.PrecoUnitario : 0.01M;
                }
            }
        }

        private void CarregarListaFinal()
        {
            var itensPrevistos = _controller.GetItensPrevistos(_compraId)
                .Where(i => i.QuantidadeAdquirida > 0).ToList();
            var itensNaoPrevistos = _controller.GetItensNaoPrevistos(_compraId)
                .Where(i => i.QuantidadeAdquirida > 0).ToList();

            var todosAdquiridos = new List<object>();

            foreach (var item in itensPrevistos)
            {
                todosAdquiridos.Add(new
                {
                    item.Id,
                    IsPrevisto = true,
                    Display = $"✅ {item.Artigo?.Nome} - {item.QuantidadeAdquirida} x €{item.PrecoUnitario:F2} = €{item.QuantidadeAdquirida * item.PrecoUnitario:F2}"
                });
            }

            foreach (var item in itensNaoPrevistos)
            {
                todosAdquiridos.Add(new
                {
                    item.Id,
                    IsPrevisto = false,
                    Display = $"🛒 {item.Artigo?.Nome ?? item.Observacao} - {item.QuantidadeAdquirida} x €{item.PrecoUnitario:F2} = €{item.QuantidadeAdquirida * item.PrecoUnitario:F2}"
                });
            }

            listBoxListaFinal.DataSource = null;
            listBoxListaFinal.Items.Clear();

            if (todosAdquiridos.Count > 0)
            {
                listBoxListaFinal.DisplayMember = "Display";
                listBoxListaFinal.ValueMember = "Id";
                listBoxListaFinal.DataSource = todosAdquiridos;
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_compraAtual != null)
                {
                    _compraAtual.DataAlteracao = DateTime.Now;
                    _compraAtual.AlteradoPorId = Session.UtilizadorId;

                    var compraController = new CompraController();
                    compraController.UpdateCompra(_compraAtual);
                }

                MessageBox.Show("Compra guardada com sucesso!");
                CarregarOrcamento();
                CarregarItensPrevistos();
                CarregarItensNaoPrevistos();
                CarregarListaFinal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar: {ex.Message}");
            }
        }

        private void buttonRemoverItemListaFinal_Click(object sender, EventArgs e)
        {
            if (listBoxListaFinal.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista final para remover.", "Aviso");
                return;
            }

            var selected = listBoxListaFinal.SelectedItem;
            var itemId = (int)selected.GetType().GetProperty("Id").GetValue(selected);
            var isPrevisto = (bool)selected.GetType().GetProperty("IsPrevisto").GetValue(selected);

            DialogResult resultado = MessageBox.Show(
                "Remover este item da lista final? Ele voltará para a lista de itens por adquirir.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    var item = _controller.GetItemCompraById(itemId);
                    if (item != null)
                    {
                        // Repor a quantidade para 0 (volta a não adquirido)
                        item.QuantidadeAdquirida = 0;

                        if (isPrevisto)
                        {
                            // Para itens previstos, voltam à lista de previstos
                            _controller.AdquirirItemPrevisto(itemId, 0, item.PrecoUnitario);
                        }
                        else
                        {
                            // Para não previstos, remove completamente
                            _controller.RemoverItemNaoPrevisto(itemId);
                        }

                        MessageBox.Show("Item removido da lista final!");
                        CarregarItensPrevistos();
                        CarregarItensNaoPrevistos();
                        CarregarListaFinal();
                        CarregarOrcamento();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover item: {ex.Message}");
                }
            }
        }

        private void buttonAdquirirItemNaoPrevisto_Click(object sender, EventArgs e)
        {
            if (listBoxItensNaoPrevistos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item não previsto para adquirir.", "Aviso");
                return;
            }

            var selected = listBoxItensNaoPrevistos.SelectedItem;
            var itemId = (int)selected.GetType().GetProperty("Id").GetValue(selected);

            int quantidade = (int)numericUpDownQuantidadeAdquirir.Value;
            decimal precoUnitario = numericUpDownPrecoUnitarioAdquirir.Value;

            if (quantidade <= 0)
            {
                MessageBox.Show("Quantidade deve ser maior que zero.");
                return;
            }

            try
            {
                _controller.AdquirirItemNaoPrevisto(itemId, quantidade, precoUnitario);

                MessageBox.Show("✅ Item não previsto adquirido com sucesso!");
                CarregarOrcamento();
                CarregarItensNaoPrevistos();
                CarregarListaFinal();
                LimparCamposAdquirir();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adquirir item: {ex.Message}");
            }
        }
    }
}