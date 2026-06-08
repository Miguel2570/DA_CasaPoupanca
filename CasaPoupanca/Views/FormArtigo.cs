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
        private bool _isLoading = false;

        public FormArtigo()
        {
            InitializeComponent();
            _controller = new ArtigoController();

            try
            {
                ConfigurarNumericUpDown();
                CarregarTiposComboBox();

                comboBoxTipo.SelectedIndexChanged += comboBoxTipo_SelectedIndexChanged_1;
                listBoxArtigos.Format += ListBoxArtigos_Format;

                CarregarArtigos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }

        private void ConfigurarNumericUpDown()
        {
            // Permite valores de 0.01 até 1.000.000
            numericUpDownPreco.Minimum = 0.01M;
            numericUpDownPreco.Maximum = 1000000M;
            numericUpDownPreco.DecimalPlaces = 2;
            numericUpDownPreco.ThousandsSeparator = true;

            numericUpDownPreco.Increment = 0.01M;
        }

        private void CarregarTiposComboBox()
        {
            var tipos = _controller.GetTiposComTodos();
            comboBoxTipo.DataSource = null;
            comboBoxTipo.DisplayMember = "Nome";
            comboBoxTipo.ValueMember = "Id";
            comboBoxTipo.DataSource = tipos;
        }

        private void CarregarArtigos()
        {
            try
            {
                _isLoading = true;
                Cursor = Cursors.WaitCursor;
                listBoxArtigos.Enabled = false;

                int? filtroId = null;
                if (comboBoxTipo.SelectedValue != null && comboBoxTipo.SelectedValue is int id && id > 0)
                    filtroId = id;

                _artigos = _controller.GetArtigosFiltrados(filtroId).ToList();

                listBoxArtigos.DataSource = null;
                listBoxArtigos.DataSource = _artigos;
            }
            finally
            {
                listBoxArtigos.Enabled = true;
                Cursor = Cursors.Default;
                _isLoading = false;
            }
        }

        private void ListBoxArtigos_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Artigo artigo)
            {
                try
                {
                    string tipoNome = artigo.TipoArtigo?.Nome ?? "";

                    if (!string.IsNullOrEmpty(tipoNome))
                    {
                        tipoNome = $" [{tipoNome}]";
                    }

                    if (artigo.PrecoUnitario > 0)
                    {
                        e.Value = $"{artigo.Nome} - €{artigo.PrecoUnitario:F2}";
                    }
                    else
                    {
                        e.Value = $"{artigo.Nome} - Sem preço";
                    }
                }
                catch
                {
                    e.Value = artigo.Nome;
                }
            }
        }

        private void comboBoxTipo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!_isLoading && comboBoxTipo.SelectedValue != null)
            {
                CarregarArtigos();
                LimparCampos();
            }
        }

        private void LimparCampos()
        {
            textBoxNome.Clear();
            numericUpDownPreco.Value = 0.01M;
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
            listBoxArtigos.ClearSelected();
        }

        private void buttonAdicionar_Click_1(object sender, EventArgs e)
        {
            // VALIDAÇÕES
            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("Preencha o nome!");
                textBoxNome.Focus();
                return;
            }

            if (comboBoxTipo.SelectedValue == null || (int)comboBoxTipo.SelectedValue == 0)
            {
                MessageBox.Show("Selecione um tipo!");
                comboBoxTipo.Focus();
                return;
            }

            // VALIDAÇÃO DO PREÇO
            decimal preco = numericUpDownPreco.Value;

            if (preco <= 0)
            {
                MessageBox.Show("O preço deve ser maior que zero (0)!");
                numericUpDownPreco.Focus();
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
                textBoxNome.Focus();
                return;
            }

            if (comboBoxTipo.SelectedValue == null || (int)comboBoxTipo.SelectedValue == 0)
            {
                MessageBox.Show("Selecione um tipo!");
                comboBoxTipo.Focus();
                return;
            }

            decimal preco = numericUpDownPreco.Value;

            if (preco <= 0)
            {
                MessageBox.Show("O preço deve ser maior que zero (0)!");
                numericUpDownPreco.Focus();
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

        private void buttonRemover_Click_1(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um artigo!");
                return;
            }

            if (MessageBox.Show("Remover este artigo?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            if (_isLoading) return;

                if (listBoxArtigos.SelectedItem is Artigo artigo)
            {
                textBoxNome.Text = artigo.Nome;
                numericUpDownPreco.Value = artigo.PrecoUnitario;

                if (!string.IsNullOrEmpty(comboBoxTipo.ValueMember))
                    comboBoxTipo.SelectedValue = artigo.TipoArtigoId;
                else
                {
                    for (int i = 0; i < comboBoxTipo.Items.Count; i++)
                    {
                        if (comboBoxTipo.Items[i] is TipoArtigo t && t.Id == artigo.TipoArtigoId)
                        {
                            comboBoxTipo.SelectedIndex = i;
                            break;
                        }
                    }
                }

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