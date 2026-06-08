using CasaPoupanca.Controllers;
using CasaPoupança.database;
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
    public partial class FormTipoArtigo : Form
    {
        private int? _tipoEditandoId = null;
        private ArtigoController _controller;
        public FormTipoArtigo()
        {
            InitializeComponent();
            _controller = new ArtigoController();
            ConfigurarDataGridView();
            CarregarTiposArtigo();

            dataGridViewTipoArtigo.DataBindingComplete += dataGridViewTipoArtigo_DataBindingComplete;
            LimparCampos();
        }

        private void LimparCampos()
        {
            textBoxNome.Clear();
            _tipoEditandoId = null;
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewTipoArtigo.AutoGenerateColumns = false;
            dataGridViewTipoArtigo.Columns.Clear();

            dataGridViewTipoArtigo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dataGridViewTipoArtigo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome do Tipo",
                DataPropertyName = "Nome",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            });
        }

        private void CarregarTiposArtigo()
        {
            var tipos = _controller.GetAllTipos();

            // Ordenar por ID antes de atribuir ao DataGridView
            var tiposOrdenados = tipos.OrderBy(t => t.Id).ToList();

            dataGridViewTipoArtigo.DataSource = null;
            dataGridViewTipoArtigo.DataSource = tiposOrdenados;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string nome = textBoxNome.Text.Trim();

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Preencha o campo nome!");
                return;
            }

            var novoTipo = new TipoArtigo
            {
                Nome = nome
            };

            if (_controller.AddTipo(novoTipo))
            {
                MessageBox.Show("Tipo de artigo adicionado com sucesso!");
                LimparCampos();
                CarregarTiposArtigo();
            }
            else
            {
                MessageBox.Show("O nome deste tipo de artigo já existe!");
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (_tipoEditandoId == null)
            {
                MessageBox.Show("Selecione um tipo de artigo para editar.");
                return;
            }

            string nome = textBoxNome.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Preencha o nome do tipo de artigo!");
                return;
            }

            var tipo = new TipoArtigo
            {
                Id = _tipoEditandoId.Value,
                Nome = nome
            };

            if (_controller.UpdateTipo(tipo))
            {
                MessageBox.Show("Tipo de artigo atualizado com sucesso!");
                LimparCampos();
                CarregarTiposArtigo();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar ou nome já existe!");
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (_tipoEditandoId == null && dataGridViewTipoArtigo.CurrentRow == null)
            {
                MessageBox.Show("Selecione um tipo de artigo para remover.");
                return;
            }

            int id = _tipoEditandoId ?? (int)dataGridViewTipoArtigo.CurrentRow.Cells["Id"].Value;

            DialogResult resultado = MessageBox.Show(
                "Tem certeza que deseja remover este tipo de artigo?\n\nOs artigos associados também serão removidos.",
                "Confirmar", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                if (_controller.DeleteTipo(id))
                {
                    MessageBox.Show("Tipo de artigo removido!");
                    LimparCampos();
                    CarregarTiposArtigo();
                }
                else
                {
                    MessageBox.Show("Erro ao remover tipo de artigo!");
                }
            }
        }

        private void dataGridViewTipoArtigo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTipoArtigo.CurrentRow != null)
            {
                _tipoEditandoId = (int)dataGridViewTipoArtigo.CurrentRow.Cells["Id"].Value;
                textBoxNome.Text = dataGridViewTipoArtigo.CurrentRow.Cells["Nome"].Value.ToString();

                buttonAdicionar.Enabled = false;
                buttonEditar.Enabled = true;
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewTipoArtigo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewTipoArtigo.ClearSelection();
            LimparCampos();
        }
    }
}
