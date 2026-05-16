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
        public FormTipoArtigo()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CarregarTiposArtigo();

            dataGridViewTipoArtigo.DataBindingComplete += DataGridViewArtigos_DataBindingComplete;

            LimparCampos();
        }

        private void DataGridViewArtigos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewTipoArtigo.ClearSelection();
            LimparCampos();
        }
        private void LimparCampos()
        {
            textBoxNome.Clear();
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
                Width = 50
            });

            dataGridViewTipoArtigo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome do Tipo",
                DataPropertyName = "Nome",
                Width = 250
            });
        }

        private void CarregarTiposArtigo()
        {
            using (var db = new CasaPoupancaDB())
            {
                var tipoArtigo = db.TiposArtigo.OrderBy(tipo =>tipo.Nome).ToList();
                dataGridViewTipoArtigo.DataSource = null;
                dataGridViewTipoArtigo.DataSource = tipoArtigo;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string nome = textBoxNome.Text.Trim();

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Preencha o campo nome!");
                return;
            }

            using (var db = new CasaPoupancaDB())
            {
                if (db.TiposArtigo.Any(tipo => tipo.Nome == nome))
                {
                    MessageBox.Show("O nome deste tipo de artigo já existe");
                    return;
                }

                var novoTipo = new TipoArtigo
                {
                    Nome = nome,
                };

                db.TiposArtigo.Add(novoTipo);
                db.SaveChanges();
            }
            MessageBox.Show("Tipo de artigo adicionado com sucesso!");
            textBoxNome.Clear();
            CarregarTiposArtigo();
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

            using (var db = new CasaPoupancaDB())
            {
                var tipo = db.TiposArtigo.Find(_tipoEditandoId.Value);
                if (tipo != null)
                {
                    tipo.Nome = nome;
                    db.SaveChanges();
                }
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

            DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover este tipo de artigo?\n\nOs artigos associados também serão removidos.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                using (var db = new CasaPoupancaDB())
                {
                    var tipo = db.TiposArtigo.Find(id);
                    if (tipo != null)
                    {
                        db.TiposArtigo.Remove(tipo);
                        db.SaveChanges();
                    }
                }

                MessageBox.Show("Tipo de artigo removido!", "Sucesso");

                textBoxNome.Clear();
                _tipoEditandoId = null;
                buttonAdicionar.Enabled = true;
                buttonEditar.Enabled = false;
                CarregarTiposArtigo();
            }
        }

        private void dataGridViewTipoArtigo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewTipoArtigo.CurrentRow != null)
            {
                _tipoEditandoId = (int)dataGridViewTipoArtigo.CurrentRow.Cells ["Id"].Value;
                textBoxNome.Text = textBoxNome.Text = dataGridViewTipoArtigo.CurrentRow.Cells["Nome"].Value.ToString();
                buttonAdicionar.Enabled = true;
                buttonEditar .Enabled = true;
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
