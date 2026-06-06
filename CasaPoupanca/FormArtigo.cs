using CasaPoupanca.Controllers;
using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                comboBoxTipo.SelectedIndexChanged += ComboBoxTipo_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }

        private void CarregarTiposComboBox()
        {
            var tipos = _controller.GetTiposComTodos();
            comboBoxTipo.DataSource = tipos;
            comboBoxTipo.DisplayMember = "Nome";
            comboBoxTipo.ValueMember = "Id";
        }

        private void CarregarArtigos()
        {
            int filtroId = (int)comboBoxTipo.SelectedValue;
            _artigos = _controller.GetArtigosFiltrados(filtroId > 0 ? filtroId : (int?)null).ToList();

            listBoxArtigos.DataSource = null;
            listBoxArtigos.DataSource = _artigos;

            // Usar o evento Format para mostrar Nome e Preço
            listBoxArtigos.Format -= ListBoxArtigos_Format; // Remove evento anterior se existir
            listBoxArtigos.Format += ListBoxArtigos_Format; // Adiciona o evento
        }

        // Evento para formatar como aparece na ListBox
        private void ListBoxArtigos_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Artigo artigo)
            {
                if (artigo.PrecoUnitario > 0)
                    e.Value = $"{artigo.Nome} - €{artigo.PrecoUnitario:F2}";
                else
                    e.Value = artigo.Nome;
            }
        }

        private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedValue != null)
            {
                CarregarArtigos();
                LimparCampos();
            }
        }

        private void LimparCampos()
        {
            textBoxNome.Clear();
            textBoxPreco.Clear();
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            // VALIDAÇÕES
            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("Preencha o nome!");
                return;
            }

            if (comboBoxTipo.SelectedValue == null || (int)comboBoxTipo.SelectedValue == 0)
            {
                MessageBox.Show("Selecione um tipo!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPreco.Text))
            {
                MessageBox.Show("Preencha o preço!");
                return;
            }

            decimal preco;
            if (!decimal.TryParse(textBoxPreco.Text, out preco))
            {
                MessageBox.Show("Preço inválido!");
                return;
            }

            if (preco <= 0)
            {
                MessageBox.Show("Preço deve ser maior que zero!");
                return;
            }

            // CRIA O ARTIGO
            var novoArtigo = new Artigo
            {
                Nome = textBoxNome.Text.Trim(),
                TipoArtigoId = (int)comboBoxTipo.SelectedValue,
                PrecoUnitario = preco
            };

            // TENTA ADICIONAR
            try
            {
                bool resultado = _controller.AddArtigo(novoArtigo);

                if (resultado)
                {
                    MessageBox.Show("Adicionado com sucesso!");
                    CarregarArtigos();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro: Não foi possível adicionar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}");
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um artigo!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("Preencha o nome!");
                return;
            }

            if (comboBoxTipo.SelectedValue == null || (int)comboBoxTipo.SelectedValue == 0)
            {
                MessageBox.Show("Selecione um tipo!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPreco.Text))
            {
                MessageBox.Show("Preencha o preço!");
                return;
            }

            decimal preco;
            if (!decimal.TryParse(textBoxPreco.Text, out preco))
            {
                MessageBox.Show("Preço inválido!");
                return;
            }

            if (preco <= 0)
            {
                MessageBox.Show("Preço deve ser maior que zero!");
                return;
            }

            try
            {
                var artigo = (Artigo)listBoxArtigos.SelectedItem;
                artigo.Nome = textBoxNome.Text.Trim();
                artigo.TipoArtigoId = (int)comboBoxTipo.SelectedValue;
                artigo.PrecoUnitario = preco;

                _controller.UpdateArtigo(artigo);
                MessageBox.Show("Atualizado com sucesso!");
                CarregarArtigos();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}");
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um artigo!");
                return;
            }

            if (MessageBox.Show("Remover este artigo?", "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var artigo = (Artigo)listBoxArtigos.SelectedItem;
                    _controller.DeleteArtigo(artigo.Id);
                    MessageBox.Show("Removido com sucesso!");
                    CarregarArtigos();
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERRO: {ex.Message}");
                }
            }
        }

        private void listBoxArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem is Artigo artigo)
            {
                textBoxNome.Text = artigo.Nome;
                textBoxPreco.Text = artigo.PrecoUnitario.ToString("F2");
                comboBoxTipo.SelectedValue = artigo.TipoArtigoId;
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