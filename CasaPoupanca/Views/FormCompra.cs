using CasaPoupanca.Controllers;
using CasaPoupanca.models;
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
            buttonAdicionar.Click += buttonAdicionar_Click;
            buttonEditar.Click += buttonEditar_Click;
            buttonRemover.Click += buttonRemover_Click;
            buttonVoltar.Click += buttonVoltar_Click;
            buttonCriarLista.Click += buttonCriarLista_Click;
            buttonApagarLista.Click += buttonApagarLista_Click;
            buttonGuardar.Click += buttonGuardar_Click;
            listBoxListaDeCompras.SelectedIndexChanged += ListBoxListaDeCompras_SelectedIndexChanged;
            listBoxArtigosDisponiveis.SelectedIndexChanged += ListBoxArtigosDisponiveis_SelectedIndexChanged;
            listBoxListaDeArtigos.SelectedIndexChanged += ListBoxListaDeArtigos_SelectedIndexChanged;
            numericUpDownMes.ValueChanged += numericUpDownMes_ValueChanged;
            numericUpDownQuantidade.ValueChanged += numericUpDownMes_ValueChanged;
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
            buttonGuardar.Enabled = false;
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
                    MessageBox.Show("Item adicionado à compra com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CarregarItensDaCompra(_compraSelecionadaId.Value);
                numericUpDownQuantidade.Value = 1;
                buttonGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                buttonGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    // Verificar se ainda há itens
                    var itens = _compraController.GetItensPrevistos(_compraSelecionadaId.Value);
                    if (!itens.Any())
                    {
                        buttonGuardar.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover item: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                    buttonGuardar.Enabled = false;
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

                    // Verificar se tem itens para ativar o botão Guardar
                    var itens = _compraController.GetItensPrevistos(compra.Id);
                    buttonGuardar.Enabled = itens.Any();
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

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (listBoxArtigosDisponiveis.SelectedItem != null && _compraSelecionadaId.HasValue && !_isReadOnly)
            {
                AdicionarItemCompra();
                return;
            }

            // Caso contrário, cria nova compra (apenas nome, sem itens)
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
                MessageBox.Show("Compra criada com sucesso! Adicione itens e clique em Guardar.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarListasDeCompras();

                // Selecionar a nova compra automaticamente
                var compras = _compraController.GetComprasAbertasPorUtilizador(Session.UtilizadorId);
                var ultimaCompra = compras.FirstOrDefault();
                if (ultimaCompra != null)
                {
                    _compraSelecionadaId = ultimaCompra.Id;
                    textBoxNomeCompra.Text = ultimaCompra.Nome;
                    buttonGuardar.Enabled = true;
                    buttonAdicionar.Enabled = true;
                    buttonEditar.Enabled = true;
                    buttonRemover.Enabled = true;
                }

                LimparCamposCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar compra: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
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

        private void buttonEditar_Click(object sender, EventArgs e)
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

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!_compraSelecionadaId.HasValue)
            {
                MessageBox.Show("Nenhuma compra para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var itens = _compraController.GetItensPrevistos(_compraSelecionadaId.Value);
            if (!itens.Any())
            {
                MessageBox.Show("A compra não tem itens. Adicione itens antes de guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var compra = _compraController.GetCompraById(_compraSelecionadaId.Value);
                if (compra != null && !compra.IsFechada)
                {
                    MessageBox.Show($"Compra '{compra.Nome}' guardada com sucesso!\n\nTotal de itens: {itens.Count}",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recarregar a lista de compras
                    CarregarListasDeCompras();
                    buttonGuardar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar compra: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCriarLista_Click(object sender, EventArgs e)
        {
            string nome = textBoxNomeCompra.Text.Trim();
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Por favor, insira o nome da compra antes de criar a lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_compraSelecionadaId.HasValue)
            {
                buttonAdicionar_Click(sender, e);
                CarregarListasDeCompras();
            }
        }

        private void buttonApagarLista_Click(object sender, EventArgs e)
        {
            buttonRemover_Click(sender, e);
        }

        private void numericUpDownMes_ValueChanged(object sender, EventArgs e)
        {
            AtualizarOrcamento();
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}