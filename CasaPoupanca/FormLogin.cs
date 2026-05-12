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
    public partial class FormLogin : Form
    {
        public static string UtilizadorAtual { get; private set; } 
        public FormLogin()
        {
            InitializeComponent();
            textBoxPasswordLogin.UseSystemPasswordChar = true; //fica com *
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsernameLogin.Text;
            string password = textBoxPasswordLogin.Text;

            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) )
            {
                MessageBox.Show("Por favor preencha os campos!");
                return;
            }

            using (var db = new CasaPoupancaDB())
            {
                var utilizador = db.Utilizadores.FirstOrDefault(user =>user.Username == username && user.Password == password);
                if (utilizador != null)
                {
                    UtilizadorAtual = utilizador.Username;
                    MessageBox.Show($"Bem vindo, {utilizador.Username}");
                    this.Hide();
                    FormDashboard dashboard = new FormDashboard();
                    dashboard.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Credenciais inválidas. Tente novamente!");
                }
            }
        }

        private void buttonGoRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
        }
    }
}
