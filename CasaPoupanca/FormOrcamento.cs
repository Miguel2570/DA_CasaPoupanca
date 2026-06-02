using CasaPoupanca.Controllers;
using CasaPoupanca.Helpers;
using CasaPoupanca.models;
using CasaPoupança.database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CasaPoupanca
{
    public partial class FormOrcamento : Form
    {
        private OrcamentoController _controller;
        private int? _orcamentoEditandoId = null;

        public FormOrcamento()
        {
            InitializeComponent();

            // Associar eventos dos botões
            this.buttonAdicionar.Click += new System.EventHandler(this.buttonAdicionar_Click);
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            this.buttonRemover.Click += new System.EventHandler(this.buttonRemover_Click);

            // Associar evento de seleção do DataGridView
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);

            _controller = new OrcamentoController();
            ConfigurarComboBoxes();
            ConfigurarDataGridView();
            CarregarOrcamentos();
            CarregarHistoricoAlteracoes();

            dataGridView1.DataBindingComplete += (s, e) => {
                dataGridView1.ClearSelection();
                LimparCampos();
            };
        }

        private void ConfigurarComboBoxes()
        {
            // ComboBox Mês - já tens valores 1 a 12
            if (comboBoxMes.Items.Count > 0)
            {
                comboBoxMes.SelectedItem = DateTime.Now.Month.ToString();
            }

            // ComboBox Ano
            if (comboBoxAno.Items.Count > 0)
            {
                comboBoxAno.SelectedItem = DateTime.Now.Year.ToString();
            }
        }

        private void ConfigurarDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            // Configurar as colunas
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MesAno",
                HeaderText = "Mês/Ano",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Valor",
                HeaderText = "Orçamento (€)",
                DataPropertyName = "Valor",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C" },
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalGasto",
                HeaderText = "Total Gasto (€)",
                Width = 120
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Saldo",
                HeaderText = "Saldo (€)",
                Width = 120
            });
        }

        private void CarregarOrcamentos()
        {
            var orcamentos = _controller.GetAllOrcamentos();

            var orcamentosComDados = orcamentos.Select(o => new
            {
                o.Id,
                MesAno = $"{ObterNomeMes(o.Mes)} {o.Ano}",
                o.Valor,
                TotalGasto = CalcularTotalGastoMes(o.Mes, o.Ano),
                Saldo = o.Valor - CalcularTotalGastoMes(o.Mes, o.Ano)
            }).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = orcamentosComDados;
        }

        private void CarregarHistoricoAlteracoes()
        {
            // Carregar últimas alterações (podes buscar da BD ou usar lista em memória)
            listBoxAlteracoes.Items.Clear();
            listBoxAlteracoes.Items.Insert(0, $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - Sistema iniciado");
        }

        private decimal CalcularTotalGastoMes(int mes, int ano)
        {
            using (var db = new CasaPoupancaDB())
            {
                var comprasFechadas = db.Compras
                    .Where(c => c.DataCriacao.Month == mes &&
                                c.DataCriacao.Year == ano &&
                                c.IsFechada)
                    .ToList();

                decimal totalGasto = 0;
                foreach (var compra in comprasFechadas)
                {
                    var itens = db.ItensCompra.Where(i => i.CompraId == compra.Id);
                    totalGasto += itens.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
                }
                return totalGasto;
            }
        }

        private string ObterNomeMes(int mes)
        {
            string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
                               "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            return meses[mes - 1];
        }

        private int ObterNumeroMes(string nomeMes)
        {
            string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
                               "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            return Array.IndexOf(meses, nomeMes) + 1;
        }

        private void LimparCampos()
        {
            comboBoxMes.SelectedItem = DateTime.Now.Month.ToString();
            comboBoxAno.SelectedItem = DateTime.Now.Year.ToString();
            textBoxValor.Clear();
            _orcamentoEditandoId = null;
            buttonAdicionar.Enabled = true;
            buttonEditar.Enabled = false;
        }

        private void RegistarAlteracao(string mensagem)
        {
            listBoxAlteracoes.Items.Insert(0, $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {mensagem}");
            if (listBoxAlteracoes.Items.Count > 20)
            {
                listBoxAlteracoes.Items.RemoveAt(listBoxAlteracoes.Items.Count - 1);
            }
        }

        // ==================== EVENTO DO BOTÃO ADICIONAR ====================
        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                int mes = int.Parse(comboBoxMes.SelectedItem.ToString());
                int ano = int.Parse(comboBoxAno.SelectedItem.ToString());

                if (!decimal.TryParse(textBoxValor.Text, out decimal valor) || valor <= 0)
                {
                    MessageBox.Show("Insira um valor válido!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var novoOrcamento = new Orcamento
                {
                    Mes = mes,
                    Ano = ano,
                    Valor = valor,
                    CriadoPorId = Session.UtilizadorId,
                    DataCriacao = DateTime.Now
                };

                if (_controller.AddOrcamento(novoOrcamento))
                {
                    MessageBox.Show("Orçamento adicionado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarOrcamentos();
                    RegistarAlteracao($"Adicionado orçamento de {valor:C} para {ObterNomeMes(mes)} {ano}");
                }
                else
                {
                    MessageBox.Show("Já existe um orçamento para este mês/ano!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== EVENTO DO BOTÃO EDITAR ====================
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_orcamentoEditandoId == null)
                {
                    MessageBox.Show("Selecione um orçamento para editar.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBoxValor.Text, out decimal valor) || valor <= 0)
                {
                    MessageBox.Show("Insira um valor válido!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var orcamento = new Orcamento
                {
                    Id = _orcamentoEditandoId.Value,
                    Valor = valor,
                    AlteradoPorId = Session.UtilizadorId,
                    DataAlteracao = DateTime.Now
                };

                if (_controller.UpdateOrcamento(orcamento))
                {
                    MessageBox.Show("Orçamento atualizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarOrcamentos();
                    RegistarAlteracao($"Editado orçamento para {valor:C}");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar orçamento!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== EVENTO DO BOTÃO REMOVER ====================
        private void buttonRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (_orcamentoEditandoId == null && dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um orçamento para remover.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = _orcamentoEditandoId ?? (int)dataGridView1.CurrentRow.Cells["Id"].Value;

                DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover este orçamento?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    if (_controller.DeleteOrcamento(id))
                    {
                        MessageBox.Show("Orçamento removido!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarOrcamentos();
                        RegistarAlteracao("Orçamento removido");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao remover orçamento!", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== EVENTO DE SELEÇÃO DO DATAGRIDVIEW ====================
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells["MesAno"].Value != null)
            {
                _orcamentoEditandoId = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

                string mesAno = dataGridView1.CurrentRow.Cells["MesAno"].Value.ToString();
                string[] partes = mesAno.Split(' ');
                string nomeMes = partes[0];
                int ano = int.Parse(partes[1]);
                int mes = ObterNumeroMes(nomeMes);

                comboBoxMes.SelectedItem = mes.ToString();
                comboBoxAno.SelectedItem = ano.ToString();
                textBoxValor.Text = dataGridView1.CurrentRow.Cells["Valor"].Value?.ToString();

                buttonAdicionar.Enabled = false;
                buttonEditar.Enabled = true;
            }
        }

        // ==================== EVENTOS VAZIOS DO DESIGNER ====================
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // ==================== BOTÃO VOLTAR ====================
        private void buttonVoltar_Click(object sender, EventArgs e)
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