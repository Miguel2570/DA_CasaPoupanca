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
        public FormArtigo()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CarregarTiposComboBox();
            CarregarArtigos();

            dataGridViewArtigos.DataBindingComplete += DataGridViewArtigos_DataBindingComplete;

            LimparCampos();
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

        private void CarregarTiposComboBox()
        {
            using (var db = new CasaPoupancaDB())
            {
                var tipoArtigo = db.TiposArtigo.OrderBy(tipo => tipo.Nome).ToList();
                tipoArtigo.Insert(0, new TipoArtigo { Id = 0, Nome = "Todos" });

                comboBoxTipo.DataSource = null;
                comboBoxTipo.DisplayMember = "Nome";
                comboBoxTipo.ValueMember = "Id";
                comboBoxTipo.DataSource = tipoArtigo;

                comboBoxFiltrar.DataSource = null;
                comboBoxFiltrar.DisplayMember = "Nome";
                comboBoxFiltrar.ValueMember = "Id";
                comboBoxFiltrar.DataSource = tipoArtigo.ToList();
            }
        }

        private void CarregarArtigos()
        {
            using (var db = new CasaPoupancaDB())
            {
                var artigos = db.Artigos.Include("TipoArtigo").ToList();

                int filtroId = (int)comboBoxFiltrar.SelectedValue;
                if (filtroId > 0)
                {
                    artigos = artigos.Where(artigo => artigo.TipoArtigoId == filtroId).ToList();
                }

                dataGridViewArtigos.DataSource = null;
                dataGridViewArtigos.DataSource = artigos.OrderBy(a => a.Nome).ToList();
            }
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

            using (var db = new CasaPoupancaDB())
            {
                if (db.Artigos.Any(artigo => artigo.Nome == nome && artigo.TipoArtigoId == tipoId))
                {
                    MessageBox.Show("Este artigo já existe no tipo de artigos!");
                    return;
                }

                var novoArtigo = new Artigo
                {
                    Nome = nome,
                    TipoArtigoId = tipoId
                };

                db.Artigos.Add(novoArtigo);
                db.SaveChanges();
            }
            MessageBox.Show("Artigo adicionado com sucesso!");

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

            using (var db = new CasaPoupancaDB())
            {
                var artigo = db.Artigos.Find(_artigoEditandoId.Value);
                if (artigo != null)
                {
                    artigo.Nome = nome;
                    artigo.TipoArtigoId = tipoId;
                    db.SaveChanges();
                }
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
                using (var db = new CasaPoupancaDB())
                {
                    var artigo = db.Artigos.Find(id);
                    if (artigo != null)
                    {
                        db.Artigos.Remove(artigo);
                        db.SaveChanges();
                    }
                }

                MessageBox.Show("Artigo removido!", "Sucesso");

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
    }
}
