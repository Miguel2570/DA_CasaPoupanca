using CasaPoupanca.Controllers;
using CasaPoupanca.models;
using CasaPoupança.database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CasaPoupanca
{
    public partial class FormEstatisticas : Form
    {
        private EstatisticasController _controller;

        public FormEstatisticas()
        {
            InitializeComponent();
            _controller = new EstatisticasController();
            ConfigurarTabControl();
            CarregarDados();
        }

        private void ConfigurarTabControl()
        {
            tabControl.TabPages.Clear();

            var tabResumoMensal = new TabPage("📅 Resumo Mensal");
            tabResumoMensal.Controls.Add(dataGridViewResumo);
            dataGridViewResumo.Dock = DockStyle.Fill;
            tabControl.TabPages.Add(tabResumoMensal);

            var tabCompras = new TabPage("📋 % de Compras");
            tabCompras.Controls.Add(dataGridViewCompras);
            dataGridViewCompras.Dock = DockStyle.Fill;
            tabControl.TabPages.Add(tabCompras);

            var tabSugestoes = new TabPage("💡 Sugestões");
            var panelSugestoes = new Panel { Dock = DockStyle.Fill };
            lblSugestaoOrcamento.Dock = DockStyle.Top;
            lstSugestaoCompras.Dock = DockStyle.Fill;
            panelSugestoes.Controls.Add(lblSugestaoOrcamento);
            panelSugestoes.Controls.Add(lstSugestaoCompras);
            tabSugestoes.Controls.Add(panelSugestoes);
            tabControl.TabPages.Add(tabSugestoes);
        }

        private void CarregarDados()
        {
            CarregarResumoMensal();
            CarregarResumoCompras();
            CarregarSugestoes();
        }

        private void CarregarResumoMensal()
        {
            var resumo = _controller.GetResumoMensal();

            dataGridViewResumo.DataSource = null;
            dataGridViewResumo.AutoGenerateColumns = false;
            dataGridViewResumo.Columns.Clear();

            dataGridViewResumo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MesAno",
                HeaderText = "Mês/Ano",
                DataPropertyName = "MesAno",
                Width = 120
            });

            dataGridViewResumo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Orcamento",
                HeaderText = "Orçamento (€)",
                DataPropertyName = "Orcamento",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C" },
                Width = 120
            });

            dataGridViewResumo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalGasto",
                HeaderText = "Total Gasto (€)",
                DataPropertyName = "TotalGasto",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C" },
                Width = 120
            });

            dataGridViewResumo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Diferenca",
                HeaderText = "Diferença (€)",
                DataPropertyName = "Diferenca",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C" },
                Width = 120
            });

            dataGridViewResumo.DataSource = resumo;
        }

        private void CarregarResumoCompras()
        {
            var resumo = _controller.GetResumoComprasFechadas();

            dataGridViewCompras.DataSource = null;
            dataGridViewCompras.AutoGenerateColumns = false;
            dataGridViewCompras.Columns.Clear();

            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomeCompra",
                HeaderText = "Compra",
                DataPropertyName = "NomeCompra",
                Width = 150
            });

            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataFecho",
                HeaderText = "Data Fecho",
                DataPropertyName = "DataFecho",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 100
            });

            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItensPrevistos",
                HeaderText = "Previstos",
                DataPropertyName = "ItensPrevistos",
                Width = 80
            });

            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItensNaoPrevistos",
                HeaderText = "Não Previstos",
                DataPropertyName = "ItensNaoPrevistos",
                Width = 100
            });

            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PercentagemPrevistos",
                HeaderText = "% Previstos",
                DataPropertyName = "PercentagemPrevistos",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "0.00" },
                Width = 100
            });

            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PercentagemNaoPrevistos",
                HeaderText = "% Não Previstos",
                DataPropertyName = "PercentagemNaoPrevistos",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "0.00" },
                Width = 100
            });

            dataGridViewCompras.DataSource = resumo;
        }

        private void CarregarSugestoes()
        {
            // Sugestão de orçamento
            decimal sugestaoOrcamento = _controller.SugerirOrcamentoProximoMes();
            lblSugestaoOrcamento.Text = $"💰 Sugestão de Orçamento para o próximo mês: {sugestaoOrcamento:C}";

            // Sugestão de lista de compras
            var sugestaoItens = _controller.SugerirListaCompras();
            lstSugestaoCompras.Items.Clear();

            if (sugestaoItens.Count == 0)
            {
                lstSugestaoCompras.Items.Add("Sem dados suficientes para sugestão.");
            }
            else
            {
                lstSugestaoCompras.Items.Add("📋 Lista de compras sugerida (baseada em meses anteriores):");
                lstSugestaoCompras.Items.Add("");
                foreach (var item in sugestaoItens)
                {
                    lstSugestaoCompras.Items.Add($"  • {item.NomeArtigo}: {item.Quantidade} unidade(s)");
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados();
            MessageBox.Show("Dados atualizados!");
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            FormExportarCSV exportar = new FormExportarCSV();
            exportar.ShowDialog();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _controller?.Dispose();
            base.OnFormClosed(e);
        }
    }
}