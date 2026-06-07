using CasaPoupança.database;
using CasaPoupanca.Helpers;
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
        public FormProfile()
        {
            InitializeComponent();
            CarregarDadosPerfil();
        }

        private void CarregarDadosPerfil()
        {
            using (var db = new CasaPoupancaDB())
            {
                var utilizador = db.Utilizadores.Find(Session.UtilizadorId);
                if (utilizador != null)
                {
                    label1.Text = utilizador.Username;
                    
                    // Estatísticas
                    labelDataRegistoValor.Text = utilizador.DataRegisto.ToString("dd/MM/yyyy");

                    var compras = db.Compras.Where(c => c.CriadoPorId == Session.UtilizadorId).ToList();
                    labelTotalComprasValor.Text = compras.Count.ToString();

                    decimal totalGasto = 0;
                    var comprasFechadas = compras.Where(c => c.IsFechada).ToList();
                    foreach (var compra in comprasFechadas)
                    {
                        var itens = db.ItensCompra.Where(i => i.CompraId == compra.Id);
                        totalGasto += itens.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
                    }
                    labelTotalGastoValor.Text = totalGasto.ToString("C");

                    var ultimaCompra = compras.OrderByDescending(c => c.DataCriacao).FirstOrDefault();
                    labelUltimaCompraValor.Text = ultimaCompra != null ? ultimaCompra.DataCriacao.ToString("dd/MM/yyyy") : "Sem compras";
                }
            }
        }

       
            private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
}
