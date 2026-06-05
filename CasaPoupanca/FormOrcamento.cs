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
            try
            {
                InitializeComponent();
                _controller = new OrcamentoController();
                ConfigurarComboBoxes();
                ConfigurarDataGridView();
                CarregarOrcamentos();
                CarregarHistoricoAlteracoes();

                // Evento para quando o DataGridView terminar de carregar
                dataGridViewOrcamento.DataBindingComplete += (s, e) => {
                    dataGridViewOrcamento.ClearSelection();
                    LimparCampos();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inicializar formulário: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private void ConfigurarComboBoxes()
        {
            try
            {
                // Preencher meses (1 a 12)
                comboBoxMes.Items.Clear();
                for (int i = 1; i <= 12; i++)
                {
                    comboBoxMes.Items.Add(i);
                }

                // Preencher anos (ano atual -5 até ano atual +5)
                comboBoxAno.Items.Clear();
                int anoAtual = DateTime.Now.Year;
                for (int i = anoAtual - 5; i <= anoAtual + 5; i++)
                {
                    comboBoxAno.Items.Add(i);
                }

                if (comboBoxMes.Items.Count > 0)
                {
                    comboBoxMes.SelectedItem = DateTime.Now.Month;
                }

                if (comboBoxAno.Items.Count > 0)
                {
                    comboBoxAno.SelectedItem = DateTime.Now.Year;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao configurar ComboBoxes: {ex.Message}");
            }
        }

        private void ConfigurarDataGridView()
        {
            try
            {
                dataGridViewOrcamento.AutoGenerateColumns = false;
                dataGridViewOrcamento.Columns.Clear();

                // Coluna ID
                dataGridViewOrcamento.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Width = 50,
                    ReadOnly = true
                });

                // Coluna Mês
                dataGridViewOrcamento.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Mes",
                    HeaderText = "Mês",
                    DataPropertyName = "Mes",
                    Width = 60,
                    ReadOnly = true
                });

                // Coluna Ano
                dataGridViewOrcamento.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Ano",
                    HeaderText = "Ano",
                    DataPropertyName = "Ano",
                    Width = 60,
                    ReadOnly = true
                });

                // Coluna Valor do Orçamento
                dataGridViewOrcamento.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Valor",
                    HeaderText = "Orçamento (€)",
                    DataPropertyName = "Valor",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                    Width = 120,
                    ReadOnly = true
                });

                // Coluna Total Gasto
                dataGridViewOrcamento.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TotalGasto",
                    HeaderText = "Total Gasto (€)",
                    DataPropertyName = "TotalGasto",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                    Width = 120,
                    ReadOnly = true
                });

                // Coluna Saldo
                dataGridViewOrcamento.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Saldo",
                    HeaderText = "Saldo (€)",
                    DataPropertyName = "Saldo",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                    Width = 120,
                    ReadOnly = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao configurar DataGridView: {ex.Message}");
            }
        }

        private void CarregarOrcamentos()
        {
            try
            {
                var orcamentos = _controller.GetAllOrcamentos();

                var orcamentosComDados = orcamentos.Select(o => new
                {
                    o.Id,
                    o.Mes,
                    o.Ano,
                    o.Valor,
                    TotalGasto = CalcularTotalGastoMes(o.Mes, o.Ano),
                    Saldo = o.Valor - CalcularTotalGastoMes(o.Mes, o.Ano)
                }).OrderByDescending(o => o.Ano).ThenByDescending(o => o.Mes).ToList();

                dataGridViewOrcamento.DataSource = null;
                dataGridViewOrcamento.DataSource = orcamentosComDados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar orçamentos: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private void CarregarHistoricoAlteracoes()
        {
            try
            {
                listBoxAlteracoes.Items.Clear();
                listBoxAlteracoes.Items.Insert(0, $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - Formulário aberto");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar histórico: {ex.Message}");
            }
        }

        private decimal CalcularTotalGastoMes(int mes, int ano)
        {
            try
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
                        var totalCompra = db.ItensCompra
                            .Where(i => i.CompraId == compra.Id)
                            .Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
                        totalGasto += totalCompra;
                    }
                    return totalGasto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao calcular total gasto: {ex.Message}");
                return 0;
            }
        }

        private string ObterNomeMes(int mes)
        {
            string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
                               "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            return meses[mes - 1];
        }

        private void LimparCampos()
        {
            try
            {
                comboBoxMes.SelectedItem = DateTime.Now.Month;
                comboBoxAno.SelectedItem = DateTime.Now.Year;
                textBoxValor.Clear();
                _orcamentoEditandoId = null;

                // IMPORTANTE: Desativar botões de editar e remover
                buttonAdicionar.Enabled = true;
                buttonEditar.Enabled = false;
                buttonRemover.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao limpar campos: {ex.Message}");
            }
        }

        private void RegistarAlteracao(string mensagem)
        {
            try
            {
                listBoxAlteracoes.Items.Insert(0, $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} - {mensagem}");
                if (listBoxAlteracoes.Items.Count > 20)
                {
                    listBoxAlteracoes.Items.RemoveAt(listBoxAlteracoes.Items.Count - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registar alteração: {ex.Message}");
            }
        }

        // EVENTO PRINCIPAL: Quando selecionar uma linha no DataGridView
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Verificar se há uma linha selecionada
                if (dataGridViewOrcamento.SelectedRows.Count > 0)
                {
                    var row = dataGridViewOrcamento.SelectedRows[0];

                    if (row.Cells["Id"].Value != null)
                    {
                        // Obter os valores da linha selecionada
                        _orcamentoEditandoId = Convert.ToInt32(row.Cells["Id"].Value);
                        int mes = Convert.ToInt32(row.Cells["Mes"].Value);
                        int ano = Convert.ToInt32(row.Cells["Ano"].Value);
                        decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);

                        // Preencher os campos com os valores selecionados
                        comboBoxMes.SelectedItem = mes;
                        comboBoxAno.SelectedItem = ano;
                        textBoxValor.Text = valor.ToString("F2");

                        // ATIVAR os botões de editar e remover
                        buttonAdicionar.Enabled = false;
                        buttonEditar.Enabled = true;
                        buttonRemover.Enabled = true;
                    }
                }
                else
                {
                    // Se nenhuma linha estiver selecionada, desativar os botões
                    buttonAdicionar.Enabled = true;
                    buttonEditar.Enabled = false;
                    buttonRemover.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar orçamento: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        // Também adicionar evento de clique na célula como alternativa
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataGridViewOrcamento.ClearSelection();
                    dataGridViewOrcamento.Rows[e.RowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao clicar na célula: {ex.Message}");
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao fechar formulário: {ex.Message}");
            }
        }

        private void buttonAdicionar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxMes.SelectedItem == null || comboBoxAno.SelectedItem == null)
                {
                    MessageBox.Show("Selecione o mês e ano!");
                    return;
                }

                int mes = (int)comboBoxMes.SelectedItem;
                int ano = (int)comboBoxAno.SelectedItem;

                if (!decimal.TryParse(textBoxValor.Text, out decimal valor) || valor <= 0)
                {
                    MessageBox.Show("Insira um valor válido (maior que zero)!");
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
                    MessageBox.Show("Orçamento adicionado com sucesso!");
                    LimparCampos();
                    CarregarOrcamentos();
                    RegistarAlteracao($"Adicionado orçamento de {valor:C} para {ObterNomeMes(mes)} {ano}");
                }
                else
                {
                    MessageBox.Show("Já existe um orçamento para este mês/ano!", "Erro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar orçamento: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private void buttonEditar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Verificar se existe um orçamento selecionado
                if (_orcamentoEditandoId == null)
                {
                    MessageBox.Show("Por favor, selecione um orçamento na tabela para editar.");
                    return;
                }

                // Verificar se os ComboBoxes têm valores selecionados
                if (comboBoxMes.SelectedItem == null || comboBoxAno.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecione o mês e ano.");
                    return;
                }

                int mes = (int)comboBoxMes.SelectedItem;
                int ano = (int)comboBoxAno.SelectedItem;

                // Verificar se o valor é válido
                if (!decimal.TryParse(textBoxValor.Text, out decimal valor) || valor <= 0)
                {
                    MessageBox.Show("Por favor, insira um valor válido (maior que zero).");
                    return;
                }

                // Confirmar com o usuário
                DialogResult confirmar = MessageBox.Show(
                    $"Deseja atualizar o orçamento para:\n\n" +
                    $"ID: {_orcamentoEditandoId}\n" +
                    $"Mês: {mes} ({ObterNomeMes(mes)})\n" +
                    $"Ano: {ano}\n" +
                    $"Valor: {valor:C}\n\n" +
                    $"Confirmar atualização?",
                    "Confirmar Edição",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmar != DialogResult.Yes)
                    return;

                // Criar objeto com os dados atualizados
                var orcamento = new Orcamento
                {
                    Id = _orcamentoEditandoId.Value,
                    Mes = mes,
                    Ano = ano,
                    Valor = valor,
                    AlteradoPorId = Session.UtilizadorId,
                    DataAlteracao = DateTime.Now
                };

                // Tentar atualizar
                bool resultado = _controller.UpdateOrcamento(orcamento);

                if (resultado)
                {
                    MessageBox.Show("Orçamento atualizado com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarOrcamentos();
                    RegistarAlteracao($"Editado orçamento para {valor:C} ({ObterNomeMes(mes)} {ano})");
                }
                else
                {
                    MessageBox.Show("Falha ao atualizar orçamento. Verifique se já não existe um orçamento para este mês/ano.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro crítico ao editar orçamento:\n\n{ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private void buttonRemover_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_orcamentoEditandoId == null)
                {
                    MessageBox.Show("Selecione um orçamento para remover.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover este orçamento?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    if (_controller.DeleteOrcamento(_orcamentoEditandoId.Value))
                    {
                        MessageBox.Show("Orçamento removido com sucesso!");
                        LimparCampos();
                        CarregarOrcamentos();
                        RegistarAlteracao("Orçamento removido");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao remover orçamento!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover orçamento: {ex.Message}\n\n{ex.StackTrace}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewOrcamento_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há uma linha selecionada
                if (dataGridViewOrcamento.SelectedRows.Count > 0)
                {
                    var row = dataGridViewOrcamento.SelectedRows[0];

                    if (row.Cells["Id"].Value != null)
                    {
                        // Obter os valores da linha selecionada
                        _orcamentoEditandoId = Convert.ToInt32(row.Cells["Id"].Value);
                        int mes = Convert.ToInt32(row.Cells["Mes"].Value);
                        int ano = Convert.ToInt32(row.Cells["Ano"].Value);
                        decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);

                        // Preencher os campos com os valores selecionados
                        comboBoxMes.SelectedItem = mes;
                        comboBoxAno.SelectedItem = ano;
                        textBoxValor.Text = valor.ToString("F2");

                        // ATIVAR os botões de editar e remover
                        buttonAdicionar.Enabled = false;
                        buttonEditar.Enabled = true;
                        buttonRemover.Enabled = true;
                    }
                }
                else
                {
                    // Se nenhuma linha estiver selecionada, desativar os botões
                    buttonAdicionar.Enabled = true;
                    buttonEditar.Enabled = false;
                    buttonRemover.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar orçamento: {ex.Message}\n\n{ex.StackTrace}");
            }
        }
    }
}