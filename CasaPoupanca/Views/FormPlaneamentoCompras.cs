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

            // Mostrar resumo de itens
            var compraDetalhes = _controller.GetCompraDetalhes(compra.Id);

            if (compraDetalhes?.Itens != null && compraDetalhes.Itens.Any())
            {
                int totalItens = compraDetalhes.Itens.Count;
                int itensPrevistos = compraDetalhes.Itens.Count(i => i.IsPrevisto);
                int itensNaoPrevistos = totalItens - itensPrevistos;

                listBoxDetalhesCompra.Items.Add("");
                listBoxDetalhesCompra.Items.Add("--- Resumo ---");
                listBoxDetalhesCompra.Items.Add($"Total Itens: {totalItens}");
                listBoxDetalhesCompra.Items.Add($"Itens Previstos: {itensPrevistos}");
                listBoxDetalhesCompra.Items.Add($"Itens Não Previstos: {itensNaoPrevistos}");

                // Mostrar últimos 3 itens
                listBoxDetalhesCompra.Items.Add("");
                listBoxDetalhesCompra.Items.Add("--- Últimos Itens ---");
                foreach (var item in compraDetalhes.Itens.Take(3))
                {
                    string nome = item.Artigo?.Nome ?? "Artigo?";
                    listBoxDetalhesCompra.Items.Add($"  • {nome}: {item.QuantidadeAdquirida} x €{item.PrecoUnitario:F2}");
                }

                if (compraDetalhes.Itens.Count > 3)
                    listBoxDetalhesCompra.Items.Add($"  ... e mais {compraDetalhes.Itens.Count - 3} itens");
            }
            else
            {
                listBoxDetalhesCompra.Items.Add("");
                listBoxDetalhesCompra.Items.Add("--- Sem itens ---");
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
