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
    public partial class FormDashboard : Form
    {
        private OrcamentoController _orcamentoController;
        private CompraController _compraController;
        public FormDashboard()
        {
            InitializeComponent();
            _orcamentoController = new OrcamentoController();
            _compraController = new CompraController();
            CarregarDados();
        }
        private void CarregarDados()
        {
            labelPerfil.Text = $"Perfil {Session.Username}";
            CarregarOrcamento();
            CarregarComprasAberto();
            ConfigurarDataGridView();
        }

        private void CarregarOrcamento()
        {
            int mesAtual = DateTime.Now.Month;
            int anoAtual = DateTime.Now.Year;

            decimal valorOrcamento = _orcamentoController.GetValorOrcamentoAtual();
            decimal totalGasto = _compraController.GetTotalGastoComprasFechadas(mesAtual, anoAtual, Session.UtilizadorId);
            decimal disponivel = valorOrcamento - totalGasto;

            labelOrcamento.Text = valorOrcamento.ToString("C");
            labelTotalGasto.Text = totalGasto.ToString("C");
            labelDisponivel.Text = disponivel.ToString("C");

            if (disponivel < 0)
            {
                labelDisponivel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                labelDisponivel.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void CarregarComprasAberto()
        {
            var compras = _compraController.GetComprasAbertoPorUtilizador(Session.UtilizadorId);
            dataGridViewCompras.DataSource = null;
            dataGridViewCompras.DataSource = compras;
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewCompras.AutoGenerateColumns = false;
            dataGridViewCompras.RowHeadersWidth = 60;
            dataGridViewCompras.Columns.Clear();

            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome da Compra",
                DataPropertyName = "Nome",
                Width = 200
            });

            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataCriacao",
                HeaderText = "Data Criação",
                DataPropertyName = "DataCriacao",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 120
            });

            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "IsFechada",
                Width = 80
            });
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCompra compras = new FormCompra();
            compras.ShowDialog();

            CarregarComprasAberto();
            CarregarOrcamento();
        }

        private void estatisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEstatisticas estatisticas = new FormEstatisticas();
            estatisticas.ShowDialog();
        }

        private void buttonNovaCompra_Click(object sender, EventArgs e)
        {
            FormCompra compra = new FormCompra();
            compra.ShowDialog();

            CarregarComprasAberto();
            CarregarOrcamento();
        }

        private void buttonContinuarCompra_Click(object sender, EventArgs e)
        {
            if (dataGridViewCompras.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma compra na tabela para continuar.");
                return;
            }

            var compra = (Compra)dataGridViewCompras.CurrentRow.DataBoundItem;

            if (compra.IsFechada)
            {
                MessageBox.Show("Esta compra já está fechada e não pode ser alterada.");
                return;
            }

            FormModoCompra modocompra = new FormModoCompra(compra.Id);
            modocompra.ShowDialog();

            CarregarComprasAberto();
            CarregarOrcamento();
        }

        private void buttonEstatisticas_Click(object sender, EventArgs e)
        {
            FormEstatisticas estatisticas = new FormEstatisticas();
            estatisticas.ShowDialog();
        }

        private void OrcamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOrcamento orcamento = new FormOrcamento();
            orcamento.ShowDialog();

            CarregarOrcamento();
        }

        private void tiposDeArtigoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTipoArtigo tipoArtigo = new FormTipoArtigo();
            tipoArtigo.ShowDialog();
        }

        private void artigosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormArtigo artigo = new FormArtigo();
            artigo.ShowDialog();
        }

        private void utilizadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtilizadores utilizadores = new FormUtilizadores();
            utilizadores.ShowDialog();
        }

        private void modoCompraToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewCompras.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma compra para continuar.");
                return;
            }

            var compra = (Compra)dataGridViewCompras.CurrentRow.DataBoundItem;

            if (compra.IsFechada)
            {
                MessageBox.Show("Esta compra já está fechada e não pode ser alterada.");
                return;
            }

            FormModoCompra modoCompra = new FormModoCompra(compra.Id);
            modoCompra.ShowDialog();
        }

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            FormExportarCSV exportar = new FormExportarCSV();
            exportar.ShowDialog();
        }

        private void exportarCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExportarCSV exportar = new FormExportarCSV();
            exportar.ShowDialog();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _orcamentoController?.Dispose();
            _compraController?.Dispose();
            base.OnFormClosed(e);
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
