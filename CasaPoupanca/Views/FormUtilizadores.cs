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
    public partial class FormUtilizadores : Form
    {
        private int? _utilizadorEditandoId = null;
        public FormUtilizadores()
        {
            InitializeComponent();
            ConfigurarListBox();
            CarregarUtilizadores();

            LimparCampos();
        }

        private void ConfigurarListBox()
        {
            // Configurar o ListBox para mostrar os utilizadores formatados
            listBoxUtilizadores.DisplayMember = "DisplayText";
            listBoxUtilizadores.ValueMember = "Id";
            listBoxUtilizadores.DrawMode = DrawMode.OwnerDrawFixed;
            listBoxUtilizadores.DrawItem += ListBoxUtilizadores_DrawItem;
            listBoxUtilizadores.SelectedIndexChanged += listBoxUtilizadores_SelectedIndexChanged;
        }

        private void ListBoxUtilizadores_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            if (listBoxUtilizadores.Items[e.Index] is UtilizadorDisplay item)
            {
                // Formatar o texto com ID,Nome, Username e Data de Registo
                string texto = $"{item.Id} - {item.Nome} - {item.Username} | Registo: {item.DataRegisto:dd/MM/yyyy}";

                using (var brush = new SolidBrush(e.ForeColor))
                {
                    e.Graphics.DrawString(texto, e.Font, brush, e.Bounds);
                }
            }

            e.DrawFocusRectangle();
        }

        private void CarregarUtilizadores()
        {
            using (var db = new CasaPoupancaDB())
            {
                var utilizadores = db.Utilizadores
                    .OrderBy(u => u.Id)
                    .Select(u => new UtilizadorDisplay
                    {
                        Id = u.Id,
                        Nome = u.Nome,
                        Username = u.Username,
                        DataRegisto = u.DataRegisto
                    })
                    .ToList();

                listBoxUtilizadores.DataSource = null;
                listBoxUtilizadores.DataSource = utilizadores;

                if (utilizadores.Any())
                {
                    listBoxUtilizadores.SelectedIndex = -1; // Nenhum selecionado inicialmente
                }
            }
        }

        private void LimparCampos()
        {
            textBoxNome.Clear();
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            _utilizadorEditandoId = null;

            if (listBoxUtilizadores.SelectedIndex != -1)
            {
                listBoxUtilizadores.SelectedIndex = -1;
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (_utilizadorEditandoId == null && listBoxUtilizadores.SelectedItem == null)
            {
                MessageBox.Show("Selecione um utilizador para remover.");
                return;
            }

            int id = _utilizadorEditandoId ?? ((UtilizadorDisplay)listBoxUtilizadores.SelectedItem).Id;

            if (id == Session.UtilizadorId)
            {
                MessageBox.Show("Não pode remover o utilizador atualmente logado.");
                return;
            }

            DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover este utilizador?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                using (var db = new CasaPoupancaDB())
                {
                    var utilizador = db.Utilizadores.Find(id);
                    if (utilizador != null)
                    {
                        db.Utilizadores.Remove(utilizador);
                        db.SaveChanges();
                        MessageBox.Show("Utilizador removido com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Utilizador não encontrado.");
                    }
                }
                CarregarUtilizadores();
                LimparCampos();
            }
        }

        private void listBoxUtilizadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUtilizadores.SelectedItem != null)
            {
                var utilizadorSelecionado = (UtilizadorDisplay)listBoxUtilizadores.SelectedItem;
                _utilizadorEditandoId = utilizadorSelecionado.Id;
                textBoxNome.Text = utilizadorSelecionado.Nome;
                textBoxUsername.Text = utilizadorSelecionado.Username;
                textBoxPassword.Clear(); // Password não é carregada por segurança
            }
            else
            {
                LimparCampos();
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (_utilizadorEditandoId == null)
            {
                MessageBox.Show("Selecione um utilizador para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar campos
            string nome = textBoxNome.Text.Trim();
            string username = textBoxUsername.Text.Trim();

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Preencha o nome do utilizador.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNome.Focus();
                return;
            }

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Preencha o username.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxUsername.Focus();
                return;
            }

            try
            {
                using (var db = new CasaPoupancaDB())
                {
                    // Verificar se o username já existe (exceto o próprio utilizador)
                    bool usernameExiste = db.Utilizadores.Any(u => u.Username == username && u.Id != _utilizadorEditandoId.Value);

                    if (usernameExiste)
                    {
                        MessageBox.Show("Este username já está em uso. Escolha outro.", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxUsername.Focus();
                        return;
                    }

                    var utilizador = db.Utilizadores.Find(_utilizadorEditandoId.Value);

                    if (utilizador == null)
                    {
                        MessageBox.Show("Utilizador não encontrado.", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimparCampos();
                        CarregarUtilizadores();
                        return;
                    }

                    // Atualizar os dados
                    utilizador.Nome = nome;
                    utilizador.Username = username;

                    // Se a password foi preenchida, aplicar o HASH antes de guardar
                    string password = textBoxPassword.Text.Trim();
                    if (!string.IsNullOrEmpty(password))
                    {
                        if (password.Length < 4)
                        {
                            MessageBox.Show("A password deve ter pelo menos 6 caracteres.", "Validação",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxPassword.Focus();
                            return;
                        }

                        // APLICAR O HASH À PASSWORD (igual ao AuthController)
                        utilizador.Password = AuthController.HashPassword(password);
                    }

                    db.SaveChanges();

                    MessageBox.Show("Utilizador editado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recarregar a lista e limpar campos
                    CarregarUtilizadores();
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar utilizador: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
