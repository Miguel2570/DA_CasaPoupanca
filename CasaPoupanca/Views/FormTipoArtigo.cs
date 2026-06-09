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
            CarregarTiposArtigo();

            LimparCampos();
        }

        private void LimparCampos()
        {
            textBoxNome.Clear();
            _tipoEditandoId = null;
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
            listBoxTiposArtigo.ClearSelected();
        }

        private void CarregarTiposArtigo()
        {
            var tipos = _controller.GetAllTipos().OrderBy(t => t.Id).ToList();

            var tiposFormatados = tipos.Select(t => new
            {
                t.Id,
                Display = $"{t.Id} - {t.Nome}"
            }).ToList();

            listBoxTiposArtigo.DataSource = null;
            listBoxTiposArtigo.DisplayMember = "Display";
            listBoxTiposArtigo.ValueMember = "Id";
            listBoxTiposArtigo.DataSource = tiposFormatados;
            listBoxTiposArtigo.ClearSelected();
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
            if (_tipoEditandoId == null)
            {
                MessageBox.Show("Selecione um tipo de artigo para remover.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "Tem certeza que deseja remover este tipo de artigo?\n\nOs artigos associados também serão removidos.",
                "Confirmar", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                if (_controller.DeleteTipo(_tipoEditandoId.Value))
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

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxTiposArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTiposArtigo.SelectedItem != null)
            {
                var selected = listBoxTiposArtigo.SelectedItem;
                var itemId = (int)selected.GetType().GetProperty("Id").GetValue(selected);
                var tipo = _controller.GetAllTipos().FirstOrDefault(t => t.Id == itemId);

                if (tipo != null)
                {
                    _tipoEditandoId = tipo.Id;
                    textBoxNome.Text = tipo.Nome;

                    buttonAdicionar.Enabled = false;
                    buttonEditar.Enabled = true;
                }
            }
            else
            {
                LimparCampos();
            }
        }
    }
}
