using CasaPoupanca.Controllers;
using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CasaPoupanca
{
    public partial class FormItemNaoPrevisto : Form
    {
        private int _compraId;
        private ModoCompraController _controller;
        private ArtigoController _artigoController;
        private decimal _orcamentoDisponivel;

        public FormItemNaoPrevisto(int compraId)
        {
            InitializeComponent();
            _compraId = compraId;
            _controller = new ModoCompraController();
            _artigoController = new ArtigoController();

            try
            {
                CarregarTiposArtigo();
                CarregarItensNaoPrevistos();
                CarregarOrcamento();
                ConfigurarEventos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar itens: {ex.Message}");
            }
        }

        private void ConfigurarEventos()
        {
            // Os eventos já estão configurados no designer
            // Apenas garantir que os métodos existem
        }

        private void CarregarTiposArtigo()
        {
            var tipos = _artigoController.GetTiposComTodos();
            comboBoxTipoDeArtigo.DataSource = tipos;
            comboBoxTipoDeArtigo.DisplayMember = "Nome";
            comboBoxTipoDeArtigo.ValueMember = "Id";
            comboBoxTipoDeArtigo.SelectedIndex = -1;

            comboBoxArtigo.DataSource = null;
            comboBoxArtigo.DisplayMember = "Nome";
            comboBoxArtigo.ValueMember = "Id";
        }

        private void CarregarArtigosPorTipo(int tipoId)
        {
            if (tipoId > 0)
            {
                var artigos = _artigoController.GetArtigosFiltrados(tipoId);
                comboBoxArtigo.DataSource = artigos;
                comboBoxArtigo.DisplayMember = "Nome";
                comboBoxArtigo.ValueMember = "Id";
                comboBoxArtigo.SelectedIndex = -1;
            }
            else
            {
                comboBoxArtigo.DataSource = null;
            }
        }

        private void comboBoxTipoDeArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoDeArtigo.SelectedValue != null)
            {
                int tipoId = 0;
                if (int.TryParse(comboBoxTipoDeArtigo.SelectedValue.ToString(), out tipoId) && tipoId > 0)
                {
                    CarregarArtigosPorTipo(tipoId);
                }
                else
                {
                    comboBoxArtigo.DataSource = null;
                }
            }
        }

        private void comboBoxArtigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxArtigo.SelectedItem is Artigo artigo)
            {
                numericUpDownPrecoUnitario.Value = artigo.PrecoUnitario;
                textBoxObservacao.Clear();
                numericUpDownQuantidade.Focus();
            }
        }

        private void CarregarItensNaoPrevistos()
        {
            var itens = _controller.GetItensNaoPrevistos(_compraId);
            listBoxItensNaoPrevistos.DataSource = null;
            listBoxItensNaoPrevistos.DataSource = itens;
            listBoxItensNaoPrevistos.DisplayMember = "DisplayName";
            listBoxItensNaoPrevistos.ValueMember = "Id";
        }

        private void CarregarOrcamento()
        {
            var dataAtual = DateTime.Now;
            _orcamentoDisponivel = _controller.GetOrcamentoDisponivel(Session.UtilizadorId, dataAtual.Month, dataAtual.Year);
            labelOrcamentoDisponivel.Text = $"Orçamento Disponível: {_orcamentoDisponivel:C2}";

            if (_orcamentoDisponivel < 0)
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Red;
                labelAviso.ForeColor = System.Drawing.Color.Red;
                labelAviso.Text = "Atenção! Orçamento ultrapassado!";
            }
            else
            {
                labelOrcamentoDisponivel.ForeColor = System.Drawing.Color.Green;
                labelAviso.ForeColor = System.Drawing.Color.Black;
                labelAviso.Text = "(Alerta vermelho se ultrapassar)";
            }
        }

        private void LimparCampos()
        {
            comboBoxTipoDeArtigo.SelectedIndex = -1;
            comboBoxArtigo.DataSource = null;
            textBoxObservacao.Clear();
            numericUpDownQuantidade.Value = 1;
            numericUpDownPrecoUnitario.Value = 0;
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (comboBoxArtigo.SelectedItem == null)
            {
                MessageBox.Show("Selecione um artigo disponível!");
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

            var artigo = (Artigo)comboBoxArtigo.SelectedItem;
            decimal totalItem = quantidade * precoUnitario;

            if (totalItem > _orcamentoDisponivel && _orcamentoDisponivel > 0)
            {
                DialogResult resultado = MessageBox.Show(
                    $"Este item custa {totalItem:C2} mas só tem {_orcamentoDisponivel:C2} de orçamento.\n\nDeseja continuar mesmo assim?",
                    "Atenção! Orçamento insuficiente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultado != DialogResult.Yes)
                    return;
            }

            try
            {
                var novoItem = new ItemCompra
                {
                    CompraId = _compraId,
                    ArtigoId = artigo.Id,
                    QuantidadePrevista = quantidade,
                    QuantidadeAdquirida = 0,
                    PrecoUnitario = precoUnitario,
                    IsPrevisto = false,
                    Observacao = textBoxObservacao.Text.Trim()
                };

                _controller.AddItemNaoPrevisto(novoItem);
                MessageBox.Show("Item não previsto adicionado com sucesso!");

                CarregarItensNaoPrevistos();
                LimparCampos();
                CarregarOrcamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar item: {ex.Message}");
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (listBoxItensNaoPrevistos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item para remover!");
                return;
            }

            if (MessageBox.Show("Tem certeza que deseja remover este item?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var item = (ItemCompra)listBoxItensNaoPrevistos.SelectedItem;
                    _controller.RemoverItemNaoPrevisto(item.Id);

                    MessageBox.Show("Item removido com sucesso!");
                    CarregarItensNaoPrevistos();
                    LimparCampos();
                    CarregarOrcamento();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover item: {ex.Message}");
                }
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxItensNaoPrevistos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxItensNaoPrevistos.SelectedItem is ItemCompra item)
            {
                
                numericUpDownQuantidade.Value = item.QuantidadeAdquirida;
                numericUpDownPrecoUnitario.Value = item.PrecoUnitario;
                textBoxObservacao.Text = item.Observacao;

                
            }
        }
    }
}