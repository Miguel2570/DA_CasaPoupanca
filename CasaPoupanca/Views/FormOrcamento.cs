using CasaPoupanca.Controllers;
using CasaPoupanca.models;
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

                dataGridViewOrcamento.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Width = 50,
                    ReadOnly = true
                });

                dataGridViewOrcamento.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Mes",
                    HeaderText = "Mês",
                    DataPropertyName = "Mes",
                    Width = 60,
                    ReadOnly = true
                });

                dataGridViewOrcamento.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Ano",
                    HeaderText = "Ano",
                    DataPropertyName = "Ano",
                    Width = 60,
                    ReadOnly = true
                });

                dataGridViewOrcamento.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Valor",
                    HeaderText = "Orçamento (€)",
                    DataPropertyName = "Valor",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                    Width = 120,
                    ReadOnly = true
                });

                dataGridViewOrcamento.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TotalGasto",
                    HeaderText = "Total Gasto (€)",
                    DataPropertyName = "TotalGasto",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" },
                    Width = 120,
                    ReadOnly = true
                });

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
                    TotalGasto = _controller.CalcularTotalGastoMes(o.Mes, o.Ano), // ✅ Usa o controller
                    Saldo = o.Valor - _controller.CalcularTotalGastoMes(o.Mes, o.Ano) // ✅ Usa o controller
                }).OrderByDescending(o => o.Ano).ThenByDescending(o => o.Mes).ToList();

                dataGridViewOrcamento.DataSource = null;
                dataGridViewOrcamento.DataSource = orcamentosComDados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar orçamentos: {ex.Message}");
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

                buttonAdicionar.Enabled = true;
                buttonEditar.Enabled = false;
                buttonRemover.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao limpar campos: {ex.Message}");
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
                }
                else
                {
                    MessageBox.Show("Já existe um orçamento para este mês/ano!");
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
                if (_orcamentoEditandoId == null)
                {
                    MessageBox.Show("Por favor, selecione um orçamento na tabela para editar.");
                    return;
                }

                if (comboBoxMes.SelectedItem == null || comboBoxAno.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecione o mês e ano.");
                    return;
                }

                int mes = (int)comboBoxMes.SelectedItem;
                int ano = (int)comboBoxAno.SelectedItem;

                // Verifica se o valor é válido
                if (!decimal.TryParse(textBoxValor.Text, out decimal valor) || valor <= 0)
                {
                    MessageBox.Show("Por favor, insira um valor válido (maior que zero).");
                    return;
                }

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
                    MessageBox.Show("Orçamento atualizado com sucesso!");
                    LimparCampos();
                    CarregarOrcamentos();
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
                    MessageBox.Show("Selecione um orçamento para remover.");
                    return;
                }

                DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover este orçamento?",
                    "Confirmar", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    if (_controller.DeleteOrcamento(_orcamentoEditandoId.Value))
                    {
                        MessageBox.Show("Orçamento removido com sucesso!");
                        LimparCampos();
                        CarregarOrcamentos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao remover orçamento!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover orçamento: {ex.Message}");
            }
        }

        private void dataGridViewOrcamento_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há linha selecionada
                if (dataGridViewOrcamento.SelectedRows.Count == 0 ||
                    dataGridViewOrcamento.SelectedRows[0].Cells["Id"].Value == null)
                {
                    _orcamentoEditandoId = null;
                    buttonAdicionar.Enabled = true;
                    buttonEditar.Enabled = false;
                    buttonRemover.Enabled = false;
                    return;
                }

                var row = dataGridViewOrcamento.SelectedRows[0];

                _orcamentoEditandoId = Convert.ToInt32(row.Cells["Id"].Value);
                int mes = Convert.ToInt32(row.Cells["Mes"].Value);
                int ano = Convert.ToInt32(row.Cells["Ano"].Value);
                decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);

                comboBoxMes.SelectedItem = mes;
                comboBoxAno.SelectedItem = ano;
                textBoxValor.Text = valor.ToString("F2");

                buttonAdicionar.Enabled = false;
                buttonEditar.Enabled = true;
                buttonRemover.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar orçamento: {ex.Message}");
            }
        }

        private void buttonVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewOrcamento_CellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}