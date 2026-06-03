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
        private ArtigoController _controller;
        private List<Artigo> _artigos;
        public FormArtigo()
        {
            InitializeComponent();
            _controller = new ArtigoController();

            try
            {
                CarregarTiposComboBox();
                CarregarArtigos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados iniciais: {ex.Message}");
            }
        }

        private void CarregarTiposComboBox()
        {
            var tipos = _controller.GetTiposComTodos();
            comboBoxTipo.DataSource = tipos;
            comboBoxTipo.DisplayMember = "Nome";
            comboBoxTipo.ValueMember = "Id";

            comboBoxFiltrar.DataSource = tipos.ToList();
            comboBoxFiltrar.DisplayMember = "Nome";
            comboBoxFiltrar.ValueMember = "Id";
        }

        private void CarregarArtigos()
        {
            int filtroId = (int)comboBoxFiltrar.SelectedValue;
            _artigos = _controller.GetArtigosFiltrados(filtroId > 0 ? filtroId : (int?)null).ToList();

            listBoxArtigos.DataSource = _artigos;
            listBoxArtigos.DisplayMember = "Nome";
            listBoxArtigos.ValueMember = "Id";
        }

        private void LimparCampos()
        {
            textBoxNome.Clear();
            comboBoxTipo.SelectedIndex = 0;
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarArtigos();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar: {ex.Message}");
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("Preencha o nome do artigo!");
                return;
            }
            if ((int)comboBoxTipo.SelectedValue == 0)
            {
                MessageBox.Show("Selecione um tipo de artigo!");
                return;
            }

            try
            {
                var novoArtigo = new Artigo
                {
                    Nome = textBoxNome.Text.Trim(),
                    TipoArtigoId = (int)comboBoxTipo.SelectedValue
                };

                if (_controller.AddArtigo(novoArtigo))
                {
                    MessageBox.Show("Artigo adicionado com sucesso!");
                    CarregarArtigos();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Este artigo já existe!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar: {ex.Message}");
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um artigo para editar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("Preencha o nome do artigo!");
                return;
            }
            if ((int)comboBoxTipo.SelectedValue == 0)
            {
                MessageBox.Show("Selecione um tipo de artigo!");
                return;
            }

            try
            {
                var artigo = (Artigo)listBoxArtigos.SelectedItem;
                artigo.Nome = textBoxNome.Text.Trim();
                artigo.TipoArtigoId = (int)comboBoxTipo.SelectedValue;

                _controller.UpdateArtigo(artigo);
                MessageBox.Show("Artigo atualizado com sucesso!");
                CarregarArtigos();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar: {ex.Message}");
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um artigo para remover.");
                return;
            }

            if (MessageBox.Show("Tem certeza que deseja remover este artigo?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var artigo = (Artigo)listBoxArtigos.SelectedItem;
                    _controller.DeleteArtigo(artigo.Id);
                    MessageBox.Show("Artigo removido!");
                    CarregarArtigos();
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover: {ex.Message}");
                }
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem is Artigo artigo)
            {
                textBoxNome.Text = artigo.Nome;
                comboBoxTipo.SelectedValue = artigo.TipoArtigoId;
                buttonEditar.Enabled = true;
            }
        }
    }
}
