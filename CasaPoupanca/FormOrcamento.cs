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
           
            listBoxAlteracoes.Items.Clear();
            listBoxAlteracoes.Items.Insert(0, $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}");
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
            listBoxAlteracoes.Items.Insert(0, $"{DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            if (listBoxAlteracoes.Items.Count > 20)
            {
                listBoxAlteracoes.Items.RemoveAt(listBoxAlteracoes.Items.Count - 1);
            }
        }

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

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _controller?.Dispose();
            base.OnFormClosed(e);
        }

        private void buttonAdicionar_Click_1(object sender, EventArgs e)
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
                    MessageBox.Show("Orçamento adicionado com sucesso!");
                    LimparCampos();
                    CarregarOrcamentos();
                    RegistarAlteracao($"Adicionado orçamento de {valor:C} para {ObterNomeMes(mes)} {ano}");
                }
                else
                {
                    MessageBox.Show("Já existe um orçamento para este mês/ano!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void buttonEditar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_orcamentoEditandoId == null)
                {
                    MessageBox.Show("Selecione um orçamento para editar.");
                    return;
                }

                if (!decimal.TryParse(textBoxValor.Text, out decimal valor) || valor <= 0)
                {
                    MessageBox.Show("Insira um valor válido!");
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
                    MessageBox.Show("Orçamento atualizado com sucesso!");
                    LimparCampos();
                    CarregarOrcamentos();
                    RegistarAlteracao($"Editado orçamento para {valor:C}");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar orçamento!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void buttonRemover_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_orcamentoEditandoId == null && dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Selecione um orçamento para remover.");
                    return;
                }

                int id = _orcamentoEditandoId ?? (int)dataGridView1.CurrentRow.Cells["Id"].Value;

                DialogResult resultado = MessageBox.Show("Tem certeza que deseja remover este orçamento?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    if (_controller.DeleteOrcamento(id))
                    {
                        MessageBox.Show("Orçamento removido!");
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
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }

        private void comboBoxAno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}