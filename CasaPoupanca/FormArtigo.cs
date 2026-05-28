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
    public partial class FormArtigo : Form
    {
        private int? _artigoEditandoId = null;
        private ArtigoController _controller;
        public FormArtigo()
        {
            InitializeComponent();
            _controller = new ArtigoController();
            ConfigurarDataGridView();
            CarregarTiposComboBox();
            CarregarArtigos();

            dataGridViewArtigos.DataBindingComplete += DataGridViewArtigos_DataBindingComplete;
            LimparCampos();
        }

        private void CarregarTiposComboBox()
        {
            var tipos = _controller.GetTiposComTodos();
            comboBoxTipo.DataSource = null;
            comboBoxTipo.DisplayMember = "Nome";
            comboBoxTipo.ValueMember = "Id";
            comboBoxTipo.DataSource = tipos;

            comboBoxFiltrar.DataSource = null;
            comboBoxFiltrar.DisplayMember = "Nome";
            comboBoxFiltrar.ValueMember = "Id";
            comboBoxFiltrar.DataSource = tipos.ToList();
        }

        private void CarregarArtigos()
        {
            int filtroId = (int)comboBoxFiltrar.SelectedValue;
            var artigos = _controller.GetArtigosFiltrados(filtroId > 0 ? filtroId : (int?)null);
            dataGridViewArtigos.DataSource = null;
            dataGridViewArtigos.DataSource = artigos;
        }

        private void DataGridViewArtigos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewArtigos.ClearSelection();
            LimparCampos();
        }

        private void LimparCampos()
        {
            textBoxNome.Clear();
            comboBoxTipo.SelectedIndex = 0;
            _artigoEditandoId = null;
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewArtigos.AutoGenerateColumns = false;
            dataGridViewArtigos.Columns.Clear();

            dataGridViewArtigos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            dataGridViewArtigos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome do Artigo",
                DataPropertyName = "Nome",
                Width = 200
            });

            dataGridViewArtigos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TipoArtigo",
                HeaderText = "Tipo",
                DataPropertyName = "TipoArtigo.Nome",
                Width = 150
            });
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            CarregarArtigos();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string nome = textBoxNome.Text.Trim();
            int tipoId = (int)comboBoxTipo.SelectedValue;

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Preencha o nome do artigo!");
                return;
            }

            if (tipoId == 0)
            {
                MessageBox.Show("Selecione um tipo de artigo!");
                return;
            }

            var novoArtigo = new Artigo
            {
                Nome = nome,
                TipoArtigoId = tipoId
            };

            if (_controller.AddArtigo(novoArtigo))
            {
                MessageBox.Show("Artigo adicionado com sucesso!");
                CarregarArtigos();
                LimparCampos();
            }
            else
            {
                MessageBox.Show("Este artigo já existe no tipo de artigos!");
            }

            CarregarArtigos();
            textBoxNome.Clear();
            comboBoxTipo.SelectedIndex = 0;
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (_artigoEditandoId == null)
            {
                MessageBox.Show("Selecione um artigo para editar.");
                return;
            }

            string nome = textBoxNome.Text.Trim();
            int tipoId = (int)comboBoxTipo.SelectedValue;

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Preencha o nome do artigo!");
                return;
            }

            if (tipoId == 0)
            {
                MessageBox.Show("Selecione um tipo de artigo!");
                return;
            }

            var artigo = _controller.GetArtigoById(_artigoEditandoId.Value);
            if (artigo != null)
            {
                artigo.Nome = nome;
                artigo.TipoArtigoId = tipoId;
                _controller.UpdateArtigo(artigo);
            }

            MessageBox.Show("Artigo atualizado com sucesso!");

            textBoxNome.Clear();
            comboBoxTipo.SelectedIndex = 0;
            _artigoEditandoId = null;
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
            CarregarArtigos();
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (_artigoEditandoId == null && dataGridViewArtigos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um artigo para remover.");
                return;
            }

            int id = _artigoEditandoId ?? (int)dataGridViewArtigos.CurrentRow.Cells["Id"].Value;

            DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover este artigo?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (_controller.DeleteArtigo(id))
                {
                    MessageBox.Show("Artigo removido!", "Sucesso");
                }
                else
                {
                    MessageBox.Show("Erro ao remover artigo!");
                }

                textBoxNome.Clear();
                _artigoEditandoId = null;
                buttonAdicionar.Enabled = true;
                buttonEditar.Enabled = false;
                CarregarArtigos();
            }
        }

        private void dataGridViewArtigos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewArtigos.CurrentRow != null)
            {
                _artigoEditandoId = (int)dataGridViewArtigos.CurrentRow.Cells["Id"].Value;
                textBoxNome.Text = dataGridViewArtigos.CurrentRow.Cells["Nome"].Value.ToString();

                string tipoNome = dataGridViewArtigos.CurrentRow.Cells["TipoArtigo"].Value?.ToString();
                if (!string.IsNullOrEmpty(tipoNome))
                {
                    comboBoxTipo.SelectedItem = comboBoxTipo.Items.Cast<TipoArtigo>()
                        .FirstOrDefault(t => t.Nome == tipoNome);
                }

                buttonAdicionar.Enabled = true;
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
    }
}
