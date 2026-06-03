using CasaPoupanca.Controllers;
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
    public partial class FormItemNaoPrevisto : Form
    {
        private int _compraId;
        private ModoCompraController _controller;
        private decimal _orcamentoDisponivel;
        public FormItemNaoPrevisto(int compraId)
        {
            InitializeComponent();
            _compraId = compraId;
            _controller = new ModoCompraController();

            try
            {
                CarregarItensNaoPrevistos();
                CarregarOrcamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar itens: {ex.Message}");
            }
        }

        private void CarregarItensNaoPrevistos()
        {
            var itens = _controller.GetItensNaoPrevistos(_compraId);
            listBoxItensNaoPrevistos.DataSource = null;
            listBoxItensNaoPrevistos.DataSource = itens;
            listBoxItensNaoPrevistos.DisplayMember = "DisplayText";
            listBoxItensNaoPrevistos.ValueMember = "Id";
        }

        private void CarregarOrcamento()
        {
            _orcamentoDisponivel = _controller.GetOrcamentoDisponivel(Session.UtilizadorId);
            labelOrcamentoDisponivel.Text = $"Orçamento Disponível: {_orcamentoDisponivel:C}";

            if (_orcamentoDisponivel < 0)
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void LimparCampos()
        {
            textBoxArtigo.Clear();
            textBoxObservacao.Clear();
            numericUpDownQuantidade.Value = 1;
            numericUpDownPrecoUnitario.Value = 0;
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

            try
            {
                var novoItem = new ItemCompra
                {
                    CompraId = _compraId,
                    ArtigoId = 0,
                    QuantidadePrevista = 0,
                    QuantidadeAdquirida = quantidade,
                    PrecoUnitario = precoUnitario,
                    IsPrevisto = false,
                    Observacao = textBoxArtigo.Text.Trim()
                };

                _controller.AddItemNaoPrevisto(novoItem);
                MessageBox.Show("Item não previsto adicionado com sucesso!");

                CarregarItensNaoPrevistos();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar item: {ex.Message}");
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (listBoxItensNaoPrevistos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item para remover!");
                return;
            }

            if (MessageBox.Show("Tem certeza que deseja remover este item?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var item = (ItemCompra)listBoxItensNaoPrevistos.SelectedItem;
                    _controller.RemoverItemNaoPrevisto(item.Id);

                    MessageBox.Show("Item removido!");
                    CarregarItensNaoPrevistos();
                    LimparCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover item: {ex.Message}");
                }
            }
        }

        private void listBoxItensNaoPrevistos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItensNaoPrevistos.SelectedItem is ItemCompra item)
            {
                textBoxArtigo.Text = item.Observacao;
                numericUpDownQuantidade.Value = item.QuantidadeAdquirida;
                numericUpDownPrecoUnitario.Value = item.PrecoUnitario;
            }
        }
    }
}
