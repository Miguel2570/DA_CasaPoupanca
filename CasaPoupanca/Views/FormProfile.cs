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
    public partial class FormProfile : Form
    {
        private ProfileController _controller;
        public FormProfile()
        {
            InitializeComponent();
            _controller = new ProfileController();
            CarregarDadosPerfil();
        }

        private void CarregarDadosPerfil()
        {
            try
            {
                var utilizador = _controller.GetUtilizador(Session.UtilizadorId);
                if (utilizador != null)
                {
                    label1.Text = utilizador.Username;
                    labelDataRegistoValor.Text = utilizador.DataRegisto.ToString("dd/MM/yyyy");

                    int totalCompras = _controller.GetTotalCompras(Session.UtilizadorId);
                    labelTotalComprasValor.Text = totalCompras.ToString();

                    decimal totalGasto = _controller.GetTotalGasto(Session.UtilizadorId);
                    labelTotalGastoValor.Text = totalGasto.ToString("C");

                    var dataUltimaCompra = _controller.GetDataUltimaCompra(Session.UtilizadorId);
                    labelUltimaCompraValor.Text = dataUltimaCompra.HasValue
                        ? dataUltimaCompra.Value.ToString("dd/MM/yyyy")
                        : "Sem compras";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar perfil: {ex.Message}");
            }
        }
        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
