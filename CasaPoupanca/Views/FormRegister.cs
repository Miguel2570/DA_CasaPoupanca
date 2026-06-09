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
    public partial class FormRegister : Form
    {
        private AuthController _controller;

        public FormRegister()
        {
            InitializeComponent();
            _controller = new AuthController();
            textBoxPasswordRegister.UseSystemPasswordChar = true; //fica com *
            textBoxConfirmarPassword.UseSystemPasswordChar = true; //fica com *
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string name = textBoxNomeRegister.Text;
            string username = textBoxUsernameRegister.Text;
            string password = textBoxPasswordRegister.Text;
            string cofirmarPassword = textBoxConfirmarPassword.Text;
            
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(cofirmarPassword))
            {
                MessageBox.Show("Por favor preencha todos os campos!");
                return;
            }
            if (password.Length < 4)
            {
                MessageBox.Show("A password deve conter pelo menos 4 caracteres!");
                return;
            }
            if (password != cofirmarPassword)
            {
                MessageBox.Show("As passwords não coincidem!");
                return;
            }

            try
            {
                var novoUtilizador = new Utilizador
                {
                    Nome = name,
                    Username = username,
                    Password = password,
                    DataRegisto = DateTime.Now,
                };

                if (_controller.Register(novoUtilizador))
                {
                    MessageBox.Show("Registo bem-sucedido!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username já existe!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }
    }
}
