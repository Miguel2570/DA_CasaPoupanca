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

                comboBoxTipo.SelectedIndexChanged += ComboBoxTipo_SelectedIndexChanged;
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

            // Opcional: Permitir que o utilizador use setas para aumentar/diminuir de 0.01 em 0.01
            numericUpDownPreco.Increment = 0.01M;
        }

        private void CarregarTiposComboBox()
        {
            var tipos = _controller.GetTiposComTodos();
            comboBoxTipo.DataSource = null;
            comboBoxTipo.DataSource = tipos;
            comboBoxTipo.DisplayMember = "Nome";
            comboBoxTipo.ValueMember = "Id";
        }

        private void CarregarArtigos()
        {
            try
            {
                _isLoading = true;

                // Mostra feedback visual
                Cursor = Cursors.WaitCursor;
                listBoxArtigos.Enabled = false;

                int? filtroId = null;
                if (comboBoxTipo.SelectedValue != null && comboBoxTipo.SelectedValue is int)
                {
                    int id = (int)comboBoxTipo.SelectedValue;
                    if (id > 0)
                    {
                        filtroId = id;
                    }
                }

                _artigos = _controller.GetArtigosFiltrados(filtroId).ToList();

                listBoxArtigos.DataSource = null;
                listBoxArtigos.DataSource = _artigos;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar artigos: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ComboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
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

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            // VALIDAÇÕES
            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("Preencha o nome!", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNome.Focus();
                return;
            }

            if (comboBoxTipo.SelectedValue == null || (int)comboBoxTipo.SelectedValue == 0)
            {
                MessageBox.Show("Selecione um tipo!", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxTipo.Focus();
                return;
            }

            // VALIDAÇÃO DO PREÇO
            decimal preco = numericUpDownPreco.Value;

            if (preco <= 0)
            {
                MessageBox.Show("O preço deve ser maior que zero (0)!", "Valor Inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Adicionado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarArtigos();
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro: Não foi possível adicionar.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um artigo!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxNome.Text))
            {
                MessageBox.Show("Preencha o nome!", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNome.Focus();
                return;
            }

            if (comboBoxTipo.SelectedValue == null || (int)comboBoxTipo.SelectedValue == 0)
            {
                MessageBox.Show("Selecione um tipo!", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxTipo.Focus();
                return;
            }

            decimal preco = numericUpDownPreco.Value;

            if (preco <= 0)
            {
                MessageBox.Show("O preço deve ser maior que zero (0)!", "Valor Inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Atualizado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarArtigos();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um artigo!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Remover este artigo?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var artigo = (Artigo)listBoxArtigos.SelectedItem;
                    _controller.DeleteArtigo(artigo.Id);
                    MessageBox.Show("Removido com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarArtigos();
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERRO: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBoxArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxArtigos.SelectedItem is Artigo artigo)
            {
                textBoxNome.Text = artigo.Nome;
                numericUpDownPreco.Value = artigo.PrecoUnitario;  // Agora aceita valores grandes
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