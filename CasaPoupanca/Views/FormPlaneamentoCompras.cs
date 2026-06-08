using CasaPoupanca.Controllers;
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

            ConfigurarFormulario();
            CarregarCompras();

        }

        private void ConfigurarFormulario()
        {
            listBoxListaCompras.ValueMember = "Id";

            comboBoxEstado.Items.AddRange(new[] { "Todas", "Aberta", "Fechada" });
            comboBoxEstado.SelectedIndex = 0;

            comboBoxEstado.SelectedIndexChanged += comboBoxEstado_SelectedIndexChanged;
            listBoxListaCompras.SelectedIndexChanged += ListBoxListaCompras_SelectedIndexChanged;
            buttonGerirCompra.Click += buttonGerirCompra_Click;
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
            if (comboBoxEstado == null || listBoxListaCompras == null || _todasCompras == null)
            {
                return;
            }

            var comprasFiltradas = _controller.FiltrarCompras(_todasCompras, comboBoxEstado.SelectedItem?.ToString());

            if (comprasFiltradas == null)
            {
                comprasFiltradas = new List<Compra>();
            }

            listBoxListaCompras.DataSource = null;

            listBoxListaCompras.DisplayMember = "";
            listBoxListaCompras.ValueMember = "Id";

            listBoxListaCompras.DataSource = comprasFiltradas;

            if (labelTotalCompras != null)
            {
                labelTotalCompras.Text = $"Total: {comprasFiltradas.Count} compras encontradas";
            }
        }


        private void ListBoxListaCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(listBoxListaCompras.SelectedItem is Compra compra)) return;

            listBoxDetalhesCompra.Items.Clear();

            // Informações básicas
            listBoxDetalhesCompra.Items.Add($"ID: {compra.Id}");
            listBoxDetalhesCompra.Items.Add($"Nome: {compra.Nome}");
            listBoxDetalhesCompra.Items.Add($"Data: {compra.DataCriacao:dd/MM/yyyy HH:mm}");
            listBoxDetalhesCompra.Items.Add($"Estado: {_controller.GetEstadoTexto(compra.IsFechada)}");

            if (compra.DataFecho.HasValue)
                listBoxDetalhesCompra.Items.Add($"Data Fecho: {compra.DataFecho:dd/MM/yyyy HH:mm}");

            listBoxDetalhesCompra.Items.Add($"Total Gasto: {_controller.GetTotalGasto(compra.Id):C}");

            // Mostrar itens detalhados
            var compraDetalhes = _controller.GetCompraDetalhes(compra.Id);

            if (compraDetalhes?.Itens != null && compraDetalhes.Itens.Any())
            {
                // Separar itens previstos e não previstos
                var itensPrevistos = compraDetalhes.Itens.Where(i => i.IsPrevisto).ToList();
                var itensNaoPrevistos = compraDetalhes.Itens.Where(i => !i.IsPrevisto).ToList();

                // Calcular totais
                int totalItens = compraDetalhes.Itens.Count;
                decimal totalPrevistos = itensPrevistos.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
                decimal totalNaoPrevistos = itensNaoPrevistos.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);

                listBoxDetalhesCompra.Items.Add("");
                listBoxDetalhesCompra.Items.Add("══════════ RESUMO ══════════");
                listBoxDetalhesCompra.Items.Add($"Total de Itens: {totalItens}");
                listBoxDetalhesCompra.Items.Add($"Valor Total: {compraDetalhes.Itens.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario):C}");
                listBoxDetalhesCompra.Items.Add("");

                // Mostrar itens previstos
                listBoxDetalhesCompra.Items.Add("═══ ITENS PREVISTOS ═══");
                listBoxDetalhesCompra.Items.Add($"Quantidade: {itensPrevistos.Count} | Total: {totalPrevistos:C}");
                listBoxDetalhesCompra.Items.Add("───────────────────────────");

                if (itensPrevistos.Any())
                {
                    foreach (var item in itensPrevistos)
                    {
                        string nome = item.Artigo?.Nome ?? "Artigo?";
                        decimal subtotal = item.QuantidadeAdquirida * item.PrecoUnitario;
                        listBoxDetalhesCompra.Items.Add($"  ✓ {nome}: {item.QuantidadeAdquirida} x €{item.PrecoUnitario:F2} = €{subtotal:F2}");
                    }
                }
                else
                {
                    listBoxDetalhesCompra.Items.Add("  Nenhum item previsto");
                }

                listBoxDetalhesCompra.Items.Add("");

                // Mostrar itens não previstos
                listBoxDetalhesCompra.Items.Add("═══ ITENS NÃO PREVISTOS ═══");
                listBoxDetalhesCompra.Items.Add($"Quantidade: {itensNaoPrevistos.Count} | Total: {totalNaoPrevistos:C}");
                listBoxDetalhesCompra.Items.Add("───────────────────────────");

                if (itensNaoPrevistos.Any())
                {
                    foreach (var item in itensNaoPrevistos)
                    {
                        string nome = item.Artigo?.Nome ?? "Artigo?";
                        decimal subtotal = item.QuantidadeAdquirida * item.PrecoUnitario;
                        listBoxDetalhesCompra.Items.Add($"  ✗ {nome}: {item.QuantidadeAdquirida} x €{item.PrecoUnitario:F2} = €{subtotal:F2}");
                    }
                }
                else
                {
                    listBoxDetalhesCompra.Items.Add("  Nenhum item não previsto");
                }
            }
            else
            {
                listBoxDetalhesCompra.Items.Add("");
                listBoxDetalhesCompra.Items.Add("--- Sem itens registrados ---");
            }
        }

        private void buttonGerirCompra_Click(object sender, EventArgs e)
        {
            if (!(listBoxListaCompras.SelectedItem is Compra compra))
            {
                MessageBox.Show("Selecione uma compra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (compra.IsFechada)
            {
                MessageBox.Show("Compra fechada não pode ser alterada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formModoCompra = new FormModoCompra(compra.Id);
            formModoCompra.ShowDialog();

            CarregarCompras();
        }

        private void comboBoxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarCompras();
        }
    }
}
