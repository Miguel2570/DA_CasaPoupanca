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
            InitializeComponent();
            _controller = new OrcamentoController();
            ConfigurarComboBoxes();
            CarregarOrcamentos();
            LimparCampos();
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

        private void CarregarOrcamentos()
        {
            var orcamentos = _controller.GetAllOrcamentos();

            var orcamentosFormatados = orcamentos.Select(o => new
            {
                o.Id,
                Display = $"{ObterNomeMes(o.Mes)} {o.Ano} | Orçamento: €{o.Valor:F2} | Gasto: €{_controller.CalcularTotalGastoMes(o.Mes, o.Ano):F2} | Saldo: €{(o.Valor - _controller.CalcularTotalGastoMes(o.Mes, o.Ano)):F2}"
            }).OrderByDescending(o => o.Id).ToList();

            listBoxOrcamentos.DataSource = null;
            listBoxOrcamentos.DisplayMember = "Display";
            listBoxOrcamentos.ValueMember = "Id";
            listBoxOrcamentos.DataSource = orcamentosFormatados;
            listBoxOrcamentos.ClearSelected();
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

                listBoxOrcamentos.ClearSelected();
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
                    MessageBox.Show("Por favor, selecione um orçamento na lista para editar.");
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

        private void buttonVoltar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxOrcamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxOrcamentos.SelectedItem != null)
            {
                var selected = listBoxOrcamentos.SelectedItem;
                var itemId = (int)selected.GetType().GetProperty("Id").GetValue(selected);
                var orcamento = _controller.GetAllOrcamentos().FirstOrDefault(o => o.Id == itemId);

                if (orcamento != null)
                {
                    _orcamentoEditandoId = orcamento.Id;
                    comboBoxMes.SelectedItem = orcamento.Mes;
                    comboBoxAno.SelectedItem = orcamento.Ano;
                    textBoxValor.Text = orcamento.Valor.ToString("F2");

                    buttonAdicionar.Enabled = false;
                    buttonEditar.Enabled = true;
                    buttonRemover.Enabled = true;
                }
            }
            else
            {
                LimparCampos();
            }
        }
    }
}