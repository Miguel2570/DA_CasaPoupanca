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
    public partial class FormItemNaoPrevisto : Form
    {
        private int _compraId;
        private ModoCompraController _controller;
        public FormItemNaoPrevisto(int compraId)
        {
            InitializeComponent();
            _compraId = compraId;
            _controller = new ModoCompraController();
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxArtigo.Text))
            {
                MessageBox.Show("Preencha o nome do artigo!");
                return;
            }

            int quantidade = (int)numericUpDownQuantidade.Value;
            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero!");
                return;
            }

            decimal precoUnitario = numericUpDownPrecoUnitario.Value;
            if (precoUnitario <= 0)
            {
                MessageBox.Show("O preço deve ser maior que zero!");
                return;
            }

            var novoItem = new ItemCompra
            {
                CompraId = _compraId,
                ArtigoId = 0,
                QuantidadePrevista = 0,
                QuantidadeAdquirida = quantidade,
                PrecoUnitario = precoUnitario,
                IsPrevisto = false,
                Observacao = textBoxObservacao.Text.Trim()
            };

            _controller.AddItemNaoPrevisto(novoItem);

            MessageBox.Show("Item não previsto adicionado com sucesso!");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _controller?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
