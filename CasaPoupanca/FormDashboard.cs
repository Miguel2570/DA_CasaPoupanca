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
        public FormDashboard()
        {
            InitializeComponent();
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
            using (var db = new CasaPoupancaDB())
            {
                int mesAtual = DateTime.Now.Month;
                int anoAtual = DateTime.Now.Year;

                var orcamento = db.Orcamentos
                    .FirstOrDefault(o => o.Mes == mesAtual && o.Ano == anoAtual);

                decimal valorOrcamento = orcamento?.Valor ?? 0;

                var comprasFechadas = db.Compras
                    .Where(c => c.DataCriacao.Month == mesAtual &&
                                c.DataCriacao.Year == anoAtual &&
                                c.IsFechada)
                    .ToList();

                decimal totalGasto = 0;
                foreach (var compra in comprasFechadas)
                {
                    var itens = db.ItensCompra.Where(i => i.CompraId == compra.Id);
                    totalGasto += itens.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
                }

                decimal disponivel = valorOrcamento - totalGasto;

                labelOrcamento.Text = valorOrcamento.ToString("C");
                labelTotalGasto.Text = totalGasto.ToString("C");
                labelDisponivel.Text = disponivel.ToString("C");

                if (disponivel < 0)
                {
                    labelDisponivel.ForeColor = Color.Red;
                }
            }
        }

        private void CarregarComprasAberto()
        {
            using (var db = new CasaPoupancaDB())
            {
                var compras = db.Compras
                    .Where(c => !c.IsFechada && c.CriadoPorId == Session.UtilizadorId)
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();

                dataGridViewCompras.DataSource = null;
                dataGridViewCompras.DataSource = compras;
            }
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewCompras.AutoGenerateColumns = false;
            dataGridViewCompras.RowHeadersWidth = 60;
            dataGridViewCompras.Columns.Clear();

            // Coluna ID
            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            // Coluna Nome da Compra
            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome da Compra",
                DataPropertyName = "Nome",
                Width = 200
            });

            // Coluna Data Criação
            dataGridViewCompras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataCriacao",
                HeaderText = "Data Criação",
                DataPropertyName = "DataCriacao",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 120
            });

            // Coluna Estado (Aberto/Fechado)
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

        private void estisticasToolStripMenuItem_Click(object sender, EventArgs e)
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

            FormModoCompra modoCompra = new FormModoCompra(compra.Id);
            modoCompra.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
