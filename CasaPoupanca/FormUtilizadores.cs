using CasaPoupança.database;
using CasaPoupanca.Helpers;
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
            ConfigurarDataGridView();
            CarregarUtilizadores();

            dataGridViewUtilizadores.DataBindingComplete += DataGridViewUtilizadores_DataBindingComplete;

            LimparCampos();
        }

        private void DataGridViewUtilizadores_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewUtilizadores.ClearSelection();
            LimparCampos();
        }

        private void LimparCampos()
        {
            textBoxUsername.Clear();
            textBoxPassword.Clear();
            textBoxNome.Clear();
            textBoxEmail.Clear();
            _utilizadorEditandoId = null;
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
        }

        private void ConfigurarDataGridView()
        {
            dataGridViewUtilizadores.AutoGenerateColumns = false;
            dataGridViewUtilizadores.Columns.Clear();

            dataGridViewUtilizadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            dataGridViewUtilizadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Username",
                DataPropertyName = "Username",
                Width = 120
            });

            dataGridViewUtilizadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                Width = 150
            });

            dataGridViewUtilizadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 150
            });

            dataGridViewUtilizadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataRegisto",
                HeaderText = "Data Registo",
                DataPropertyName = "DataRegisto",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 100
            });
        }

        private void CarregarUtilizadores()
        {
            using (var db = new CasaPoupancaDB())
            {
                var utilizadores = db.Utilizadores.OrderBy(u => u.Username).ToList();
                dataGridViewUtilizadores.DataSource = null;
                dataGridViewUtilizadores.DataSource = utilizadores;
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string nome = textBoxNome.Text.Trim();
            string email = textBoxEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            using (var db = new CasaPoupancaDB())
            {
                if (db.Utilizadores.Any(user => user.Username == username))
                {
                    MessageBox.Show("O username já existe. Por favor, escolha outro.", "Erro");
                    return;
                }

                var novoUtilizador = new models.Utilizador
                {
                    Username = username,
                    Password = password,
                    Nome = nome,
                    Email = email,
                    DataRegisto = DateTime.Now
                };
                db.Utilizadores.Add(novoUtilizador);
                db.SaveChanges();
            }
            MessageBox.Show("Utilizador adicionado com sucesso!");

            CarregarUtilizadores();
            LimparCampos();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (_utilizadorEditandoId == null)
            {
                MessageBox.Show("Nenhum utilizador selecionado para edição.");
                return;
            }

            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string nome = textBoxNome.Text.Trim();
            string email = textBoxEmail.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            using (var db = new CasaPoupancaDB())
            {
                var utilizador = db.Utilizadores.Find(_utilizadorEditandoId.Value);
                if (utilizador == null)
                {
                    MessageBox.Show("Utilizador não encontrado.");
                    return;
                }
                if (db.Utilizadores.Any(user => user.Username == username && user.Id != _utilizadorEditandoId.Value))
                {
                    MessageBox.Show("O username já existe. Por favor, escolha outro.");
                    return;
                }
                utilizador.Username = username;
                utilizador.Password = password;
                utilizador.Nome = nome;
                utilizador.Email = email;
                db.SaveChanges();
            }

            MessageBox.Show("Utilizador editado com sucesso!");

            CarregarUtilizadores();
            LimparCampos();
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (_utilizadorEditandoId == null && dataGridViewUtilizadores.CurrentRow == null)
            {
                MessageBox.Show("Selecione um utilizador para remover.");
                return;
            }

            int id = _utilizadorEditandoId ?? (int)dataGridViewUtilizadores.CurrentRow.Cells["Id"].Value;

            if (id == Session.UtilizadorId)
            {
                MessageBox.Show("Não pode remover o utilizador atualmente logado.");
                return;
            }

            DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover este utilizador?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void dataGridViewUtilizadores_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUtilizadores.CurrentRow != null)
            {
                _utilizadorEditandoId = (int)dataGridViewUtilizadores.CurrentRow.Cells["Id"].Value;
                textBoxUsername.Text = dataGridViewUtilizadores.CurrentRow.Cells["Username"].Value?.ToString();
                textBoxNome.Text = dataGridViewUtilizadores.CurrentRow.Cells["Nome"].Value?.ToString();
                textBoxEmail.Text = dataGridViewUtilizadores.CurrentRow.Cells["Email"].Value?.ToString();
                textBoxPassword.Clear(); // Password não é carregada por segurança

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
