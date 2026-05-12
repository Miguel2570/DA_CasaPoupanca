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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            textBoxPasswordRegister.UseSystemPasswordChar = true; //fica com *
            textBoxConfirmarPassword.UseSystemPasswordChar = true; //fica com *
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsernameRegister.Text;
            string password = textBoxPasswordRegister.Text;
            string cofirmarPassword = textBoxConfirmarPassword.Text;
            string email = textBoxEmailRegister.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(cofirmarPassword) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Por favor preencha todos os campos!");
                return;
            }
            if(password.Length < 4)
            {
                MessageBox.Show("A password deve conter pelo menos 4 caracteres!");
                return;
            }
            if (password != cofirmarPassword)
            {
                MessageBox.Show("As passwords não coincidem!");
                return;
            }
            using (var db = new CasaPoupancaDB())
            {
                if (db.Utilizadores.Any(user => user.Username == username)) 
                {
                    MessageBox.Show("O nome de usuário já existe. Por favor, escolha outro.");
                    return;
                }
                var novoUtilizador = new Utilizador
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    DataRegisto = DateTime.Now,
                };
                db.Utilizadores.Add(novoUtilizador);
                db.SaveChanges();
                MessageBox.Show("Registo bem-sucedido!");
                this.Close();
            }
        }
    }
}
