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
        public FormItemNaoPrevisto(int compraId)
        {
            InitializeComponent();
            _compraId = compraId;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxArtigo.Text) || string.IsNullOrWhiteSpace(textBoxObservacao.Text) || string.IsNullOrWhiteSpace(textBoxQuantidade.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }

            int quantidade = (int)numericUpDownPrecoUnitario.Value;

            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero.");
                return;
            }

            if (!decimal.TryParse(textBoxQuantidade.Text, out decimal precoUnitario) || precoUnitario <= 0)
            {
                MessageBox.Show("Preço Inválido! Insira um valor válido.");
                return;
            }

            using (var db = new CasaPoupancaDB())
            {
                var novoItem = new ItemCompra
                {
                    CompraId = _compraId,
                    ArtigoId = 0,  // 0 significa que é um artigo não previsto (não está na tabela Artigos)
                    QuantidadePrevista = 0,
                    QuantidadeAdquirida = quantidade,
                    PrecoUnitario = precoUnitario,
                    IsPrevisto = false,
                    Observacao = textBoxObservacao.Text.Trim()
                };
                db.ItensCompra.Add(novoItem);
                db.SaveChanges();
            }
            MessageBox.Show("Item não previsto adicionado com sucesso!");
            this.Close();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
