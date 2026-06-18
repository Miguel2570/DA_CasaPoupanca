using CasaPoupanca.Controllers;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CasaPoupanca.Views
{
    public partial class FormPlaneamentoCompras : Form
    {
        private PlaneamentoComprasController _controller;
        private int _utilizadorId;
        private List<Compra> _todasCompras;

        public FormPlaneamentoCompras(int utilizadorId)
        {
            InitializeComponent();
            _controller = new PlaneamentoComprasController();
            _utilizadorId = utilizadorId;

            comboBoxEstado.SelectedIndex = 0;
            CarregarCompras();
        }

        private void CarregarCompras()
        {
            try
            {
                _todasCompras = _controller.GetComprasByUtilizador(_utilizadorId);
                FiltrarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarCompras()
        {
            try
            {
                string filtro = comboBoxEstado.SelectedItem?.ToString();

                var comprasFiltradas = _controller.FiltrarCompras(_utilizadorId, filtro);

                listBoxListaCompras.DataSource = null;
                listBoxListaCompras.DisplayMember = "Nome";
                listBoxListaCompras.ValueMember = "Id";
                listBoxListaCompras.DataSource = comprasFiltradas;
                labelTotalCompras.Text = $"Total: {comprasFiltradas.Count} compras";

                listBoxDetalhesCompra.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar compras: {ex.Message}");
            }
        }

        private void buttonGerirCompra_Click(object sender, EventArgs e)
        {
            if (!(listBoxListaCompras.SelectedItem is Compra compra))
            {
                MessageBox.Show("Selecione uma compra.");
                return;
            }

            if (compra.IsFechada)
            {
                MessageBox.Show("Compra fechada não pode ser alterada.");
                return;
            }

            var formCompra = new FormCompra(compra.Id);
            formCompra.ShowDialog();

            CarregarCompras();
        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarCompras();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxListaCompras_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!(listBoxListaCompras.SelectedItem is Compra compra)) return;

            listBoxDetalhesCompra.Items.Clear();

            listBoxDetalhesCompra.Items.Add($"ID: {compra.Id}");
            listBoxDetalhesCompra.Items.Add($"Nome: {compra.Nome}");
            listBoxDetalhesCompra.Items.Add($"Data: {compra.DataCriacao:dd/MM/yyyy HH:mm}");
            listBoxDetalhesCompra.Items.Add($"Estado: {_controller.GetEstadoTexto(compra.IsFechada)}");

            if (compra.DataFecho.HasValue)
                listBoxDetalhesCompra.Items.Add($"Data Fecho: {compra.DataFecho:dd/MM/yyyy HH:mm}");

            listBoxDetalhesCompra.Items.Add($"Total Gasto: {_controller.GetTotalGasto(compra.Id):C}");

            var compraDetalhes = _controller.GetCompraDetalhes(compra.Id);

            if (compraDetalhes?.Itens != null && compraDetalhes.Itens.Any())
            {
                var itensPrevistos = compraDetalhes.Itens.Where(i => i.IsPrevisto).ToList();
                var itensNaoPrevistos = compraDetalhes.Itens.Where(i => !i.IsPrevisto).ToList();

                int totalItens = compraDetalhes.Itens.Count;
                decimal totalPrevistos = itensPrevistos.Sum(i => i.QuantidadePrevista * i.PrecoUnitario);
                decimal totalNaoPrevistos = itensNaoPrevistos.Sum(i => i.QuantidadePrevista * i.PrecoUnitario);
                decimal valorTotal = totalPrevistos + totalNaoPrevistos;

                listBoxDetalhesCompra.Items.Add("");
                listBoxDetalhesCompra.Items.Add("══════════ RESUMO ══════════");
                listBoxDetalhesCompra.Items.Add($"Total de Itens: {totalItens}");
                listBoxDetalhesCompra.Items.Add($"Valor Total Previsto: {valorTotal:C}");
                listBoxDetalhesCompra.Items.Add("");

                // Itens previstos
                listBoxDetalhesCompra.Items.Add("═══ ITENS PREVISTOS ═══");
                listBoxDetalhesCompra.Items.Add($"Quantidade: {itensPrevistos.Count} | Total: {totalPrevistos:C}");
                listBoxDetalhesCompra.Items.Add("───────────────────────────");

                foreach (var item in itensPrevistos)
                {
                    string nome = item.Artigo?.Nome ?? "Artigo?";
                    decimal subtotal = item.QuantidadePrevista * item.PrecoUnitario;
                    listBoxDetalhesCompra.Items.Add($"  ✓ {nome}: {item.QuantidadePrevista} x €{item.PrecoUnitario:F2} = €{subtotal:F2}");
                }

                listBoxDetalhesCompra.Items.Add("");

                // Itens não previstos
                listBoxDetalhesCompra.Items.Add("═══ ITENS NÃO PREVISTOS ═══");
                listBoxDetalhesCompra.Items.Add($"Quantidade: {itensNaoPrevistos.Count} | Total: {totalNaoPrevistos:C}");
                listBoxDetalhesCompra.Items.Add("───────────────────────────");

                foreach (var item in itensNaoPrevistos)
                {
                    string nome = item.Artigo?.Nome ?? (item.Observacao ?? "Item?");
                    decimal subtotal = item.QuantidadePrevista * item.PrecoUnitario;
                    listBoxDetalhesCompra.Items.Add($"  ✗ {nome}: {item.QuantidadePrevista} x €{item.PrecoUnitario:F2} = €{subtotal:F2}");
                }
            }
            else
            {
                listBoxDetalhesCompra.Items.Add("");
                listBoxDetalhesCompra.Items.Add("--- Sem itens registrados ---");
            }
        }

        private void buttonNovaCompra_Click(object sender, EventArgs e)
        {
            FormCompra novaCompra = new FormCompra();
            novaCompra.ShowDialog();
        }
    }
}