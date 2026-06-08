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
    }
}