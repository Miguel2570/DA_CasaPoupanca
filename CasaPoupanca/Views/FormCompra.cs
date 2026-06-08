using CasaPoupanca.Controllers;
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
        private OrcamentoController _orcamentoController;
        private int? _compraSelecionadaId = null;
        private bool _isReadOnly = false;

        public FormCompra()
        {
            InitializeComponent();
            _compraController = new CompraController();
            _artigoController = new ArtigoController();
            _orcamentoController = new OrcamentoController();
            InicializarForm();
        }

        public FormCompra(int compraId) : this()
        {
            _compraSelecionadaId = compraId;
            CarregarDadosCompra(compraId);
        }

        private void InicializarForm()
        {
            try
            {
                CarregarListasDeCompras();
                CarregarArtigosDisponiveis();

                if (!_compraSelecionadaId.HasValue)
                {
                    LimparCamposCompra();
                }

                AtualizarOrcamentoRestante();
                AtualizarTotalItens();

                // Ligar eventos
                buttonAdicionar.Click += buttonAdicionar_Click;
                buttonRemover.Click += buttonRemover_Click;
                buttonEditar.Click += buttonEditar_Click;
                buttonVoltar.Click += buttonVoltar_Click;
                buttonCriarLista.Click += buttonCriarLista_Click;
                buttonApagarLista.Click += buttonApagarLista_Click;
                buttonGuardar.Click += buttonGuardar_Click;
                listBoxListaDeCompras.SelectedIndexChanged += listBoxListaDeCompras_SelectedIndexChanged;
                listBoxListaDeArtigos.SelectedIndexChanged += listBoxListaDeArtigos_SelectedIndexChanged;
                listBoxArtigosDisponiveis.SelectedIndexChanged += listBoxArtigosDisponiveis_SelectedIndexChanged;
                numericUpDownMes.ValueChanged += numericUpDownMes_ValueChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar formulário: {ex.Message}");
            }
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
            AtualizarTotalItens();
        }

        private void CarregarDadosCompra(int compraId)
        {
            try
            {
                var compra = _compraController.GetCompraById(compraId);
                if (compra != null)
                {
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
                    }
                    else
                    {
                        _isReadOnly = false;
                        buttonAdicionar.Enabled = true;
                        buttonEditar.Enabled = true;
                        buttonRemover.Enabled = true;
                        buttonCriarLista.Enabled = true;
                        buttonApagarLista.Enabled = true;

                        var itens = _compraController.GetItensPrevistos(compraId);
                        buttonGuardar.Enabled = itens.Any();
                    }

                    CarregarItensDaCompra(compraId);

                    // Selecionar a compra na lista
                    for (int i = 0; i < listBoxListaDeCompras.Items.Count; i++)
                    {
                        var item = listBoxListaDeCompras.Items[i];
                        var idProp = item.GetType().GetProperty("Id");
                        if (idProp != null && (int)idProp.GetValue(item) == compraId)
                        {
                            listBoxListaDeCompras.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar compra: {ex.Message}");
            }
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
            labelTotal.Text = "Total: €0,00";
        }

        private void AtualizarOrcamentoRestante()
        {
            if (labelOrcamento == null) return;

            int mes = (int)numericUpDownMes.Value;
            int ano = DateTime.Now.Year;

            var orcamento = _orcamentoController.GetOrcamentoPorMesAno(mes, ano);
            decimal orcamentoMensal = orcamento?.Valor ?? 0;
            decimal totalGasto = _orcamentoController.CalcularTotalGastoMes(mes, ano);
            decimal saldoRestante = orcamentoMensal - totalGasto;

            labelOrcamento.Text = $"Orçamento: €{saldoRestante:F2}";
            labelOrcamento.ForeColor = saldoRestante < 0 ? System.Drawing.Color.Red : System.Drawing.Color.Green;
        }

        private void AtualizarTotalItens()
        {
            if (!_compraSelecionadaId.HasValue)
            {
                labelTotal.Text = "Total: €0,00";
                return;
            }

            var itens = _compraController.GetItensPrevistos(_compraSelecionadaId.Value);
            decimal total = itens.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
            labelTotal.Text = $"Total: €{total:F2}";
        }

        private void AdicionarItemCompra()
        {
            if (!_compraSelecionadaId.HasValue)
            {
                MessageBox.Show("Selecione uma compra primeiro.");
                return;
            }

            var artigo = listBoxArtigosDisponiveis.SelectedItem as Artigo;
            if (artigo == null)
            {
                MessageBox.Show("Selecione um artigo disponível.");
                return;
            }

            int quantidade = (int)numericUpDownQuantidade.Value;
            if (quantidade <= 0)
            {
                MessageBox.Show("Quantidade deve ser maior que zero.");
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
                    MessageBox.Show("Quantidade atualizada com sucesso!");
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
                    MessageBox.Show("Item adicionado à compra com sucesso!");
                }

                CarregarItensDaCompra(_compraSelecionadaId.Value);
                numericUpDownQuantidade.Value = 1;
                buttonGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar item: {ex.Message}");
            }
        }

        private void EditarItemCompra()
        {
            var item = listBoxListaDeArtigos.SelectedItem as ItemCompra;
            if (item == null) return;

            int novaQuantidade = (int)numericUpDownQuantidade.Value;
            if (novaQuantidade <= 0)
            {
                MessageBox.Show("Quantidade deve ser maior que zero.");
                return;
            }

            try
            {
                item.QuantidadeAdquirida = novaQuantidade;
                _compraController.UpdateItemPrevisto(item);
                MessageBox.Show("Item editado com sucesso!");
                CarregarItensDaCompra(_compraSelecionadaId.Value);
                buttonGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar item: {ex.Message}");
            }
        }

        private void RemoverItemCompra()
        {
            var item = listBoxListaDeArtigos.SelectedItem as ItemCompra;
            if (item == null) return;

            DialogResult resultado = MessageBox.Show("Remover este item da compra?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    _compraController.RemoveItemPrevisto(item.Id);
                    MessageBox.Show("Item removido com sucesso!");
                    CarregarItensDaCompra(_compraSelecionadaId.Value);

                    var itens = _compraController.GetItensPrevistos(_compraSelecionadaId.Value);
                    if (!itens.Any())
                    {
                        buttonGuardar.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover item: {ex.Message}");
                }
            }
        }

        // ==================== EVENTOS ====================

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            if (listBoxArtigosDisponiveis.SelectedItem != null && _compraSelecionadaId.HasValue && !_isReadOnly)
            {
                AdicionarItemCompra();
                return;
            }

            string nome = textBoxNomeCompra.Text.Trim();
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Por favor, insira o nome da compra.");
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
                MessageBox.Show("Compra criada com sucesso!");
                CarregarListasDeCompras();

                // Selecionar a nova compra
                var compras = _compraController.GetComprasAbertasPorUtilizador(Session.UtilizadorId);
                var ultimaCompra = compras.FirstOrDefault();
                if (ultimaCompra != null)
                {
                    _compraSelecionadaId = ultimaCompra.Id;
                    textBoxNomeCompra.Text = ultimaCompra.Nome;
                    buttonGuardar.Enabled = true;
                }

                LimparCamposCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar compra: {ex.Message}");
            }
        }

        private void buttonRemover_Click(object sender, EventArgs e)
        {
            if (listBoxListaDeArtigos.SelectedItem != null && _compraSelecionadaId.HasValue && !_isReadOnly)
            {
                RemoverItemCompra();
                return;
            }

            if (!_compraSelecionadaId.HasValue)
            {
                MessageBox.Show("Selecione uma compra para remover.");
                return;
            }

            try
            {
                var compra = _compraController.GetCompraById(_compraSelecionadaId.Value);
                if (compra.IsFechada)
                {
                    MessageBox.Show("Não pode remover uma compra já fechada.");
                    return;
                }

                DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover esta compra?", "Confirmar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    if (_compraController.DeleteCompra(compra.Id))
                    {
                        MessageBox.Show("Compra removida com sucesso!");
                        CarregarListasDeCompras();
                        LimparCamposCompra();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover compra: {ex.Message}");
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (listBoxListaDeArtigos.SelectedItem != null && _compraSelecionadaId.HasValue && !_isReadOnly)
            {
                EditarItemCompra();
                return;
            }

            if (!_compraSelecionadaId.HasValue)
            {
                MessageBox.Show("Nenhuma compra selecionada.");
                return;
            }

            string nome = textBoxNomeCompra.Text.Trim();
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Por favor, insira o nome da compra.");
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
                    MessageBox.Show("Compra editada com sucesso!");
                    CarregarListasDeCompras();
                    LimparCamposCompra();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar compra: {ex.Message}");
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (!_compraSelecionadaId.HasValue)
            {
                MessageBox.Show("Nenhuma compra para guardar.");
                return;
            }

            var itens = _compraController.GetItensPrevistos(_compraSelecionadaId.Value);
            if (!itens.Any())
            {
                MessageBox.Show("A compra não tem itens. Adicione itens antes de guardar.");
                return;
            }

            try
            {
                var compra = _compraController.GetCompraById(_compraSelecionadaId.Value);
                if (compra != null && !compra.IsFechada)
                {
                    MessageBox.Show($"Compra '{compra.Nome}' guardada com sucesso!");
                    buttonGuardar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao guardar compra: {ex.Message}");
            }
        }

        private void buttonCriarLista_Click(object sender, EventArgs e)
        {
            string nome = textBoxNomeCompra.Text.Trim();
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Por favor, insira o nome da compra.");
                return;
            }

            if (!_compraSelecionadaId.HasValue)
            {
                buttonAdicionar_Click(sender, e);
            }
        }

        private void buttonApagarLista_Click(object sender, EventArgs e)
        {
            buttonRemover_Click(sender, e);
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDownMes_ValueChanged(object sender, EventArgs e)
        {
            AtualizarOrcamentoRestante();
        }

        private void listBoxListaDeCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxListaDeCompras.SelectedItem != null)
            {
                var compra = listBoxListaDeCompras.SelectedItem;
                var idProp = compra.GetType().GetProperty("Id");
                var nomeProp = compra.GetType().GetProperty("Nome");
                var isFechadaProp = compra.GetType().GetProperty("IsFechada");

                if (idProp != null && nomeProp != null)
                {
                    _compraSelecionadaId = (int)idProp.GetValue(compra);
                    textBoxNomeCompra.Text = nomeProp.GetValue(compra)?.ToString();

                    if (isFechadaProp != null && (bool)isFechadaProp.GetValue(compra))
                    {
                        _isReadOnly = true;
                        buttonAdicionar.Enabled = false;
                        buttonEditar.Enabled = false;
                        buttonRemover.Enabled = false;
                        buttonCriarLista.Enabled = false;
                        buttonApagarLista.Enabled = false;
                        buttonGuardar.Enabled = false;
                        MessageBox.Show("Esta compra está fechada.");
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

                    CarregarItensDaCompra(_compraSelecionadaId.Value);
                }
            }
        }

        private void listBoxListaDeArtigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxListaDeArtigos.SelectedItem is ItemCompra item && !_isReadOnly)
            {
                numericUpDownQuantidade.Value = item.QuantidadeAdquirida;
            }
        }

        private void listBoxArtigosDisponiveis_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evento vazio
        }
    }
}