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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CasaPoupanca
{
    public partial class FormCompra : Form
    {
        private int? _compraEditandoId = null;
        public FormCompra()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CarregarCompras();

            dataGridViewCompras.DataBindingComplete += DataGridViewCompras_DataBindingComplete;

            LimparCampos();
        }

        private void DataGridViewCompras_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewCompras.ClearSelection();
            LimparCampos();
        }

        private void LimparCampos()
        {
            textBoxNomeCompra.Clear();
            _compraEditandoId = null;
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewCompras.AutoGenerateColumns = false;
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
                Name = "IsFechada",
                HeaderText = "Estado",
                DataPropertyName = "IsFechada",
                Width = 80
            });
        }

        private void CarregarCompras()
        {
            using (var db = new CasaPoupancaDB())
            {
                var compras = db.Compras
                    .Where(c => c.CriadoPorId == Session.UtilizadorId)
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();

                dataGridViewCompras.DataSource = null;
                dataGridViewCompras.DataSource = compras;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string nomeCompra = textBoxNomeCompra.Text.Trim();

            if (string.IsNullOrEmpty(nomeCompra))
            {
                MessageBox.Show("Por favor, insira o nome da compra.");
                return;
            }

            using (var db = new CasaPoupancaDB())
            {
                var novaCompra = new Compra
                {
                    Nome = nomeCompra,
                    DataCriacao = DateTime.Now,
                    CriadoPorId = Session.UtilizadorId,
                    IsFechada = false
                };
                db.Compras.Add(novaCompra);
                db.SaveChanges();
            }
            MessageBox.Show("Compra adicionada com sucesso!");

            CarregarCompras();
            LimparCampos();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (_compraEditandoId == null)
            {
                MessageBox.Show("Nenhuma compra selecionada para edição.");
                return;
            }

            string nomeCompra = textBoxNomeCompra.Text.Trim();

            if (string.IsNullOrEmpty(nomeCompra))
            {
                MessageBox.Show("Por favor, insira o nome da compra.");
                return;
            }

            using (var db = new CasaPoupancaDB())
            {
                var compra = db.Compras.Find(_compraEditandoId.Value);
                if (compra == null)
                {
                    MessageBox.Show("Compra não encontrada.");
                    return;
                }

                compra.Nome = nomeCompra;
                compra.AlteradoPorId = Session.UtilizadorId;
                compra.DataAlteracao = DateTime.Now;
                db.SaveChanges();
            }
            MessageBox.Show("Compra editada com sucesso!");

            CarregarCompras();
            LimparCampos();
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (_compraEditandoId == null && dataGridViewCompras.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma compra para remover.");
                return;
            }

            int id = _compraEditandoId ?? (int)dataGridViewCompras.CurrentRow.Cells["Id"].Value;

            using (var db = new CasaPoupancaDB())
            {
                var compra = db.Compras.Find(id);
                if (compra != null && compra.IsFechada)
                {
                    MessageBox.Show("Não pode remover uma compra já fechada.");
                    return;
                }
            }
            DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover esta compra?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                using (var db = new CasaPoupancaDB())
                {
                    var compra = db.Compras.Find(id);
                    if (compra != null)
                    {
                        db.Compras.Remove(compra);
                        db.SaveChanges();
                        MessageBox.Show("Compra removida com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Compra não encontrada.");
                    }
                }
                CarregarCompras();
                LimparCampos();
            }
        }

        private void dataGridViewCompras_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCompras.CurrentRow != null)
            {
                _compraEditandoId = (int)dataGridViewCompras.CurrentRow.Cells["Id"].Value;
                textBoxNomeCompra.Text = dataGridViewCompras.CurrentRow.Cells["Nome"].Value?.ToString();

                buttonAdicionar.Enabled = false;
                buttonEditar.Enabled = true;
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
