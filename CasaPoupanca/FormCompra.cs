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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CasaPoupanca
{
    public partial class FormCompra : Form
    {
        private int? _compraEditandoId = null;
        private CompraController _controller;
        public FormCompra()
        {
            InitializeComponent();
            _controller = new CompraController();
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
            var compras = _controller.GetComprasByUtilizador(Session.UtilizadorId);
            dataGridViewCompras.DataSource = null;
            dataGridViewCompras.DataSource = compras;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string nomeCompra = textBoxNomeCompra.Text.Trim();

            if (string.IsNullOrEmpty(nomeCompra))
            {
                MessageBox.Show("Por favor, insira o nome da compra.");
                return;
            }

            var novaCompra = new Compra
            {
                Nome = nomeCompra,
                DataCriacao = DateTime.Now,
                CriadoPorId = Session.UtilizadorId,
                IsFechada = false
            };

            _controller.AddCompra(novaCompra);
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

            var compra = new Compra
            {
                Id = _compraEditandoId.Value,
                Nome = nomeCompra,
                AlteradoPorId = Session.UtilizadorId,
                DataAlteracao = DateTime.Now
            };

            if (_controller.UpdateCompra(compra))
            {
                MessageBox.Show("Compra editada com sucesso!");
                CarregarCompras();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Compra não encontrada.");
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (_compraEditandoId == null && dataGridViewCompras.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma compra para remover.");
                return;
            }

            int id = _compraEditandoId ?? (int)dataGridViewCompras.CurrentRow.Cells["Id"].Value;

            // Verificar se está fechada
            var compra = _controller.GetCompraById(id);
            if (compra != null && compra.IsFechada)
            {
                MessageBox.Show("Não pode remover uma compra já fechada.");
                return;
            }

            DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover esta compra?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (_controller.DeleteCompra(id))
                {
                    MessageBox.Show("Compra removida com sucesso!");
                    CarregarCompras();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Compra não encontrada.");
                }
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _controller?.Dispose();
            base.OnFormClosed(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNomeCompra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
