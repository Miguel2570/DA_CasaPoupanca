using CasaPoupanca.Controllers;
using CasaPoupanca.Helpers;
using CasaPoupanca.models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CasaPoupanca
{
    public partial class FormCompra : Form
    {
        private CompraController _compraController;
        private ArtigoController _artigoController;
        private int? _compraSelecionadaId = null;
        private bool _isReadOnly = false;

        public FormCompra()
        {
            InitializeComponent();
            _compraController = new CompraController();
            _artigoController = new ArtigoController();

            InicializarForm();
        }

        private void InicializarForm()
        {
            try
            {
                CarregarListasDeCompras();
                CarregarArtigosDisponiveis();
                ConfigurarEventos();
                LimparCamposCompra();
                AtualizarOrcamento();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar formulário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarEventos()
        {
            buttonAdicionar.Click += ButtonAdicionar_Click;
            buttonEditar.Click += ButtonEditar_Click;
            buttonRemover.Click += ButtonRemover_Click;
            buttonVoltar.Click += ButtonVoltar_Click;
            buttonCriarLista.Click += ButtonCriarLista_Click;
            buttonApagarLista.Click += ButtonApagarLista_Click;
            listBoxListaDeCompras.SelectedIndexChanged += ListBoxListaDeCompras_SelectedIndexChanged;
            listBoxArtigosDisponiveis.SelectedIndexChanged += ListBoxArtigosDisponiveis_SelectedIndexChanged;
            listBoxListaDeArtigos.SelectedIndexChanged += ListBoxListaDeArtigos_SelectedIndexChanged;
            numericUpDownMes.ValueChanged += NumericUpDownMes_ValueChanged;
            numericUpDownQuantidade.ValueChanged += NumericUpDownQuantidade_ValueChanged;
        }

        private void CarregarListasDeCompras()
        {
            var compras = _compraController.GetComprasAbertasPorUtilizador(Session.UtilizadorId);
            listBoxListaDeCompras.DataSource = null;
            listBoxListaDeCompras.DataSource = compras;
            listBoxListaDeCompras.DisplayMember = "Nome";
            listBoxListaDeCompras.ValueMember = "Id";
        }

        private void CarregarArtigosDisponiveis()
        {
            var artigos = _artigoController.GetAllArtigos();
            listBoxArtigosDisponiveis.DataSource = null;
            listBoxArtigosDisponiveis.DataSource = artigos;
            listBoxArtigosDisponiveis.DisplayMember = "Nome";
            listBoxArtigosDisponiveis.ValueMember = "Id";
        }

        private void CarregarItensDaCompra(int compraId)
        {
            var itens = _compraController.GetItensPrevistos(compraId);
            listBoxListaDeArtigos.DataSource = null;
            listBoxListaDeArtigos.DataSource = itens;
            listBoxListaDeArtigos.DisplayMember = "DisplayName";
        }

        private void LimparCamposCompra()
        {
            textBoxNomeCompra.Clear();
            numericUpDownMes.Value = DateTime.Now.Month;
            _compraSelecionadaId = null;
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
            buttonRemover.Enabled = false;
            buttonCriarLista.Enabled = true;
            buttonApagarLista.Enabled = false;
            numericUpDownQuantidade.Value = 1;
            listBoxListaDeArtigos.DataSource = null;
        }

        private void AtualizarOrcamento()
        {
            int mes = (int)numericUpDownMes.Value;
            int ano = DateTime.Now.Year;
            int utilizadorId = Session.UtilizadorId;

            var totalGasto = _compraController.GetTotalGastoComprasFechadas(mes, ano, utilizadorId);
            labelTotal.Text = $"Total: €{totalGasto:F2}";
        }

        private void ButtonAdicionar_Click(object sender, EventArgs e)
        {
            // Se há um artigo selecionado, adiciona à compra
            if (listBoxArtigosDisponiveis.SelectedItem != null && _compraSelecionadaId.HasValue && !_isReadOnly)
            {
                AdicionarItemCompra();
                return;
            }

            // Caso contrário, cria nova compra
            string nome = textBoxNomeCompra.Text.Trim();
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Por favor, insira o nome da compra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var novaCompra = new Compra
                {
                    Nome = nome,
                    DataCriacao = DateTime.Now,
                    CriadoPorId = Session.UtilizadorId,
                    IsFechada = false
                };

                _compraController.AddCompra(novaCompra);
                MessageBox.Show("Compra adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarListasDeCompras();
                LimparCamposCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar compra: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarItemCompra()
        {
            if (!_compraSelecionadaId.HasValue)
            {
                MessageBox.Show("Selecione uma compra primeiro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var artigo = listBoxArtigosDisponiveis.SelectedItem as Artigo;
            if (artigo == null)
            {
                MessageBox.Show("Selecione um artigo disponível.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantidade = (int)numericUpDownQuantidade.Value;
            if (quantidade <= 0)
            {
                MessageBox.Show("Quantidade deve ser maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var itemExistente = _compraController.GetItensPrevistos(_compraSelecionadaId.Value)
                    .FirstOrDefault(i => i.ArtigoId == artigo.Id);

                if (itemExistente != null)
                {
                    itemExistente.QuantidadeAdquirida += quantidade;
                    _compraController.UpdateItemPrevisto(itemExistente);
                    MessageBox.Show("Quantidade atualizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var novoItem = new ItemCompra
                    {
                        CompraId = _compraSelecionadaId.Value,
                        ArtigoId = artigo.Id,
                        QuantidadeAdquirida = quantidade,
                        QuantidadePrevista = quantidade,
                        PrecoUnitario = artigo.PrecoUnitario,
                        IsPrevisto = true
                    };
                    _compraController.AddItemPrevisto(novoItem);
                    MessageBox.Show("Item adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CarregarItensDaCompra(_compraSelecionadaId.Value);
                numericUpDownQuantidade.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonEditar_Click(object sender, EventArgs e)
        {
            // Se há um item selecionado na lista de artigos da compra, edita a quantidade
            if (listBoxListaDeArtigos.SelectedItem != null && _compraSelecionadaId.HasValue && !_isReadOnly)
            {
                EditarItemCompra();
                return;
            }

            // Caso contrário, edita o nome da compra
            if (!_compraSelecionadaId.HasValue)
            {
                MessageBox.Show("Nenhuma compra selecionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nome = textBoxNomeCompra.Text.Trim();
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Por favor, insira o nome da compra.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var compra = new Compra
                {
                    Id = _compraSelecionadaId.Value,
                    Nome = nome,
                    AlteradoPorId = Session.UtilizadorId,
                    DataAlteracao = DateTime.Now
                };

                if (_compraController.UpdateCompra(compra))
                {
                    MessageBox.Show("Compra editada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarListasDeCompras();
                    LimparCamposCompra();
                }
                else
                {
                    MessageBox.Show("Compra não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar compra: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarItemCompra()
        {
            var item = listBoxListaDeArtigos.SelectedItem as ItemCompra;
            if (item == null) return;

            int novaQuantidade = (int)numericUpDownQuantidade.Value;
            if (novaQuantidade <= 0)
            {
                MessageBox.Show("Quantidade deve ser maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                item.QuantidadeAdquirida = novaQuantidade;
                _compraController.UpdateItemPrevisto(item);
                MessageBox.Show("Item editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarItensDaCompra(_compraSelecionadaId.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonRemover_Click(object sender, EventArgs e)
        {
            // Se há um item selecionado na lista de artigos da compra, remove o item
            if (listBoxListaDeArtigos.SelectedItem != null && _compraSelecionadaId.HasValue && !_isReadOnly)
            {
                RemoverItemCompra();
                return;
            }

            // Caso contrário, remove a compra
            if (!_compraSelecionadaId.HasValue)
            {
                MessageBox.Show("Selecione uma compra para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var compra = _compraController.GetCompraById(_compraSelecionadaId.Value);
                if (compra.IsFechada)
                {
                    MessageBox.Show("Não pode remover uma compra já fechada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover esta compra?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    if (_compraController.DeleteCompra(compra.Id))
                    {
                        MessageBox.Show("Compra removida com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarListasDeCompras();
                        LimparCamposCompra();
                    }
                    else
                    {
                        MessageBox.Show("Compra não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover compra: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoverItemCompra()
        {
            var item = listBoxListaDeArtigos.SelectedItem as ItemCompra;
            if (item == null) return;

            DialogResult resultado = MessageBox.Show($"Remover '{item.Artigo?.Nome}' da compra?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _compraController.RemoveItemPrevisto(item.Id);
                    MessageBox.Show("Item removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarItensDaCompra(_compraSelecionadaId.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonCriarLista_Click(object sender, EventArgs e)
        {
            string nome = textBoxNomeCompra.Text.Trim();
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Por favor, insira o nome da compra antes de criar a lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_compraSelecionadaId.HasValue)
            {
                ButtonAdicionar_Click(sender, e);
                CarregarListasDeCompras();
            }
        }

        private void ButtonApagarLista_Click(object sender, EventArgs e)
        {
            ButtonRemover_Click(sender, e);
        }

        private void ListBoxListaDeCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxListaDeCompras.SelectedItem is Compra compra)
            {
                _compraSelecionadaId = compra.Id;
                textBoxNomeCompra.Text = compra.Nome;
                numericUpDownMes.Value = compra.DataCriacao.Month;

                if (compra.IsFechada)
                {
                    _isReadOnly = true;
                    buttonAdicionar.Enabled = false;
                    buttonEditar.Enabled = false;
                    buttonRemover.Enabled = false;
                    buttonCriarLista.Enabled = false;
                    buttonApagarLista.Enabled = false;
                    MessageBox.Show("Esta compra está fechada e está apenas em modo de leitura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _isReadOnly = false;
                    buttonAdicionar.Enabled = true;
                    buttonEditar.Enabled = true;
                    buttonRemover.Enabled = true;
                    buttonCriarLista.Enabled = true;
                    buttonApagarLista.Enabled = true;
                }

                CarregarItensDaCompra(compra.Id);
            }
        }

        private void ListBoxArtigosDisponiveis_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento vazio - apenas para registrar a seleção
        }

        private void ListBoxListaDeArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxListaDeArtigos.SelectedItem is ItemCompra item && !_isReadOnly)
            {
                numericUpDownQuantidade.Value = item.QuantidadeAdquirida;
            }
        }

        private void NumericUpDownMes_ValueChanged(object sender, EventArgs e)
        {
            AtualizarOrcamento();
        }

        private void NumericUpDownQuantidade_ValueChanged(object sender, EventArgs e)
        {
            // Evento opcional
        }

        private void ButtonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void textBoxNomeCompra_TextChanged(object sender, EventArgs e) { }
        private void FormCompra_Load(object sender, EventArgs e) { }
    }
}