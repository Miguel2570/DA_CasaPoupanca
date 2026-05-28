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
    public partial class FormModoCompra : Form
    {
        private int _compraId;
        private decimal _orcamentoDisponivel;
        public FormModoCompra(int compraId)
        {
            InitializeComponent();
            _compraId = compraId;
            ConfigurarDataGridViews();
            CarregarDadosCompra();
            CarregarOrcamento();
            CarregarItensPrevistos();
            CarregarItensNaoPrevistos();
        }

        private void ConfigurarDataGridViews()
        {
            // ========== DataGridView Itens Previstos ==========
            dataGridViewItensPrevistos.AutoGenerateColumns = false;
            dataGridViewItensPrevistos.Columns.Clear();

            dataGridViewItensPrevistos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            dataGridViewItensPrevistos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Artigo",
                HeaderText = "Artigo",
                DataPropertyName = "Artigo.Nome",
                Width = 150
            });

            dataGridViewItensPrevistos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "QuantidadePrevista",
                HeaderText = "Quantidade",
                DataPropertyName = "QuantidadePrevista",
                Width = 80
            });

            DataGridViewTextBoxColumn colQtdAdquirir = new DataGridViewTextBoxColumn
            {
                Name = "QuantidadeAdquirir",
                HeaderText = "Adquirir",
                Width = 80
            };
            dataGridViewItensPrevistos.Columns.Add(colQtdAdquirir);

            DataGridViewTextBoxColumn colPreco = new DataGridViewTextBoxColumn
            {
                Name = "PrecoUnitario",
                HeaderText = "Preço (€)",
                Width = 80
            };
            dataGridViewItensPrevistos.Columns.Add(colPreco);

            dataGridViewItensPrevistos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal (€)",
                Width = 80,
                ReadOnly = true
            });

            dataGridViewItensNaoPrevistos.AutoGenerateColumns = false;
            dataGridViewItensNaoPrevistos.Columns.Clear();

            dataGridViewItensNaoPrevistos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            dataGridViewItensNaoPrevistos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Artigo",
                HeaderText = "Artigo",
                DataPropertyName = "Observacao",
                Width = 120
            });

            dataGridViewItensNaoPrevistos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantidade",
                HeaderText = "Quantidade",
                DataPropertyName = "QuantidadeAdquirida",
                Width = 80
            });

            dataGridViewItensNaoPrevistos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Preco",
                HeaderText = "Preço (€)",
                DataPropertyName = "PrecoUnitario",
                Width = 80
            });

            dataGridViewItensNaoPrevistos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Subtotal",
                HeaderText = "Subtotal (€)",
                Width = 80,
                ReadOnly = true
            });

            DataGridViewButtonColumn btnRemover = new DataGridViewButtonColumn
            {
                Name = "Remover",
                HeaderText = "Ações",
                Text = "Remover",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dataGridViewItensNaoPrevistos.Columns.Add(btnRemover);

            dataGridViewItensPrevistos.CellEndEdit += dataGridViewItensPrevistos_CellEndEdit;
            dataGridViewItensNaoPrevistos.CellClick += dataGridViewItensNaoPrevistos_CellClick;
        }
        private void CarregarItensPrevistos()
        {
            using (var db = new CasaPoupancaDB())
            {
                var itens = db.ItensCompra
                    .Where(i => i.CompraId == _compraId && i.IsPrevisto)
                    .ToList();

                dataGridViewItensPrevistos.DataSource = null;
                dataGridViewItensPrevistos.DataSource = itens;
            }
        }

        private void CarregarDadosCompra()
        {
            using (var db = new CasaPoupancaDB())
            {
                var compra = db.Compras.Find(_compraId);
                if (compra != null)
                {
                    this.Text = $"Modo Compra - {compra.Nome}";
                }
            }
        }

        private void CarregarOrcamento()
        {
            using (var db = new CasaPoupancaDB())
            {
                int mesAtual = DateTime.Now.Month;
                int anoAtual = DateTime.Now.Year;

                var orcamento = db.Orcamentos
                    .FirstOrDefault(o => o.Mes == mesAtual && o.Ano == anoAtual);

                decimal valorOrcamento = orcamento?.Valor ?? 0;

                var comprasFechadas = db.Compras
                    .Where(c => c.DataCriacao.Month == mesAtual &&
                                c.DataCriacao.Year == anoAtual &&
                                c.IsFechada)
                    .ToList();

                decimal totalGasto = 0;
                foreach (var compra in comprasFechadas)
                {
                    var itens = db.ItensCompra.Where(i => i.CompraId == compra.Id);
                    totalGasto += itens.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
                }

                var itensAtuais = db.ItensCompra.Where(i => i.CompraId == _compraId);
                decimal gastoAtual = itensAtuais.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);

                _orcamentoDisponivel = valorOrcamento - totalGasto - gastoAtual;
                labelOrcamentoDisponivel.Text = $"Orçamento Disponível: {_orcamentoDisponivel:C}";

                if (_orcamentoDisponivel < 0)
                {
                    labelOrcamentoDisponivel.ForeColor = Color.Red;
                    labelAviso.Text = "ATENÇÃO: Orçamento ultrapassado!";
                }
                else
                {
                    labelOrcamentoDisponivel.ForeColor = Color.Green;
                    labelAviso.Text = "";
                }
            }
        }

        private void CarregarItensNaoPrevistos()
        {
            using (var db = new CasaPoupancaDB())
            {
                var itens = db.ItensCompra
                    .Where(i => i.CompraId == _compraId && !i.IsPrevisto)
                    .ToList();

                dataGridViewItensNaoPrevistos.DataSource = null;
                dataGridViewItensNaoPrevistos.DataSource = itens;
            }
        }
        private void AtualizarSubtotaisPrevistos()
        {
            foreach (DataGridViewRow row in dataGridViewItensPrevistos.Rows)
            {
                if (row.Cells["QuantidadeAdquirir"].Value != null && row.Cells["PrecoUnitario"].Value != null)
                {
                    int qtd;
                    decimal preco;
                    if (int.TryParse(row.Cells["QuantidadeAdquirir"].Value.ToString(), out qtd) &&
                        decimal.TryParse(row.Cells["PrecoUnitario"].Value.ToString(), out preco))
                    {
                        decimal subtotal = qtd * preco;
                        row.Cells["Subtotal"].Value = subtotal.ToString("C");
                    }
                }
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddItemNaoPrevisto_Click(object sender, EventArgs e)
        {
            using (var form = new FormItemNaoPrevisto(_compraId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CarregarOrcamento();
                    CarregarItensNaoPrevistos();
                }
            }
        }

        private void buttonFecharCompra_Click(object sender, EventArgs e)
        {
            using (var db = new CasaPoupancaDB())
            {
                var itensNaoAdquiridos = db.ItensCompra
                    .Where(i => i.CompraId == _compraId && i.IsPrevisto && i.QuantidadeAdquirida == 0)
                    .ToList();

                if (itensNaoAdquiridos.Any())
                {
                    DialogResult resultado = MessageBox.Show(
                        $"Ainda existem {itensNaoAdquiridos.Count} itens previstos não adquiridos.\n\nDeseja fechar a compra mesmo assim?",
                        "Aviso", MessageBoxButtons.YesNo);
                    if (resultado != DialogResult.Yes)
                        return;
                }
            }

            DialogResult resultadoFinal = MessageBox.Show(
                "Tem certeza que deseja fechar esta compra?\n\nApós fechada, não poderá mais ser alterada!",
                "Confirmar", MessageBoxButtons.YesNo);

            if (resultadoFinal == DialogResult.Yes)
            {
                using (var db = new CasaPoupancaDB())
                {
                    var compra = db.Compras.Find(_compraId);
                    if (compra != null)
                    {
                        compra.IsFechada = true;
                        compra.FechadaPorId = Session.UtilizadorId;
                        compra.DataFecho = DateTime.Now;
                        db.SaveChanges();
                    }
                }
                MessageBox.Show("Compra fechada com sucesso!");
                this.Close();
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            CarregarOrcamento();
            CarregarItensPrevistos();
            CarregarItensNaoPrevistos();
            MessageBox.Show("Progresso salvo com sucesso!");
        }

        private void buttonAdquirirItensPrevistos_Click(object sender, EventArgs e)
        {
            if (dataGridViewItensPrevistos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um item para adquirir.");
                return;
            }

            var item = (ItemCompra)dataGridViewItensPrevistos.CurrentRow.DataBoundItem;
            int rowIndex = dataGridViewItensPrevistos.CurrentRow.Index;

            int quantidadeAdquirir;
            decimal precoUnitario;

            if (!int.TryParse(dataGridViewItensPrevistos.Rows[rowIndex].Cells["QuantidadeAdquirir"].Value?.ToString(), out quantidadeAdquirir) || quantidadeAdquirir <= 0)
            {
                MessageBox.Show("Insira uma quantidade válida!");
                return;
            }

            if (!decimal.TryParse(dataGridViewItensPrevistos.Rows[rowIndex].Cells["PrecoUnitario"].Value?.ToString(), out precoUnitario) || precoUnitario <= 0)
            {
                MessageBox.Show("Insira um preço válido!", "Aviso");
                return;
            }

            if (quantidadeAdquirir > item.QuantidadePrevista)
            {
                DialogResult resultado = MessageBox.Show(
                    $"A quantidade a adquirir ({quantidadeAdquirir}) é maior que a quantidade prevista ({item.QuantidadePrevista}).\n\nDeseja continuar?",
                    "Aviso", MessageBoxButtons.YesNo);
                if (resultado != DialogResult.Yes)
                    return;
            }

            decimal subtotal = quantidadeAdquirir * precoUnitario;

            if (subtotal > _orcamentoDisponivel && _orcamentoDisponivel >= 0)
            {
                DialogResult resultado = MessageBox.Show(
                    $"Este item custa {subtotal:C}. Orçamento disponível: {_orcamentoDisponivel:C}\n\nDeseja continuar mesmo assim?",
                    "Aviso de Orçamento", MessageBoxButtons.YesNo);
                if (resultado != DialogResult.Yes)
                    return;
            }

            using (var db = new CasaPoupancaDB())
            {
                var itemDb = db.ItensCompra.Find(item.Id);
                if (itemDb != null)
                {
                    itemDb.QuantidadeAdquirida = quantidadeAdquirir;
                    itemDb.PrecoUnitario = precoUnitario;
                    db.SaveChanges();
                }
            }

            MessageBox.Show($"Item adquirido: {quantidadeAdquirir} x {precoUnitario:C} = {subtotal:C}");

            CarregarOrcamento();
            CarregarItensPrevistos();
        }

        private void dataGridViewItensPrevistos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            AtualizarSubtotaisPrevistos();
        }

        private void dataGridViewItensNaoPrevistos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridViewItensNaoPrevistos.Columns[e.ColumnIndex].Name == "Remover")
            {
                var item = (ItemCompra)dataGridViewItensNaoPrevistos.Rows[e.RowIndex].DataBoundItem;

                DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover este item não previsto?",
                    "Confirmar", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    using (var db = new CasaPoupancaDB())
                    {
                        var itemDb = db.ItensCompra.Find(item.Id);
                        if (itemDb != null)
                        {
                            db.ItensCompra.Remove(itemDb);
                            db.SaveChanges();
                        }
                    }
                    CarregarOrcamento();
                    CarregarItensNaoPrevistos();
                }
            }
        }
    }
}
