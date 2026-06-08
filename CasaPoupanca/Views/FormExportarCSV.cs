using CasaPoupanca.Controllers;
using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CasaPoupanca
{
    public partial class FormExportarCSV : Form
    {
        private EstatisticasController _controller;

        public FormExportarCSV()
        {
            InitializeComponent();
            _controller = new EstatisticasController();
            ConfigurarRadioButtons();
        }

        private void ConfigurarRadioButtons()
        {
            radioResumoMensal.Checked = true;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.Title = "Guardar ficheiro CSV";
                sfd.DefaultExt = "csv";
                sfd.AddExtension = true;

                // Nome sugerido com base no tipo selecionado
                if (radioResumoMensal.Checked)
                    sfd.FileName = $"resumo_mensal_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                else if (radioComprasFechadas.Checked)
                    sfd.FileName = $"compras_fechadas_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                else if (radioEstatisticasCompletas.Checked)
                    sfd.FileName = $"estatisticas_completas_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                else if (radioListaCompras.Checked)
                    sfd.FileName = $"lista_compras_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                else if (radioUtilizadores.Checked)
                    sfd.FileName = $"utilizadores_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                else if (radioArtigos.Checked)
                    sfd.FileName = $"artigos_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                else if (radioOrcamentos.Checked)
                    sfd.FileName = $"orcamentos_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Exportar(sfd.FileName);
                }
            }
        }

        private void Exportar(string caminho)
        {
            try
            {
                if (radioResumoMensal.Checked)
                    ExportarResumoMensal(caminho);
                else if (radioComprasFechadas.Checked)
                    ExportarComprasFechadas(caminho);
                else if (radioEstatisticasCompletas.Checked)
                    ExportarEstatisticasCompletas(caminho);
                else if (radioListaCompras.Checked)
                    ExportarListaCompras(caminho);
                else if (radioUtilizadores.Checked)
                    ExportarUtilizadores(caminho);
                else if (radioArtigos.Checked)
                    ExportarArtigos(caminho);
                else if (radioOrcamentos.Checked)
                    ExportarOrcamentos(caminho);

                MessageBox.Show($"Ficheiro exportado com sucesso!\n{caminho}", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar: {ex.Message}");
            }
        }

        // Resumo Mensal
        private void ExportarResumoMensal(string caminho)
        {
            var resumo = _controller.GetResumoMensal();

            using (StreamWriter sw = new StreamWriter(caminho, false, Encoding.UTF8))
            {
                sw.WriteLine("Mês/Ano;Orçamento (€);Total Gasto (€);Diferença (€)");
                foreach (var item in resumo)
                {
                    sw.WriteLine($"{item.MesAno};{item.Orcamento:F2};{item.TotalGasto:F2};{item.Diferenca:F2}");
                }
            }
        }

        // Compras Fechadas (detalhe de itens)
        private void ExportarComprasFechadas(string caminho)
        {
            using (var db = new CasaPoupancaDB())
            {
                var comprasFechadas = db.Compras.Where(c => c.IsFechada).ToList();

                using (StreamWriter sw = new StreamWriter(caminho, false, Encoding.UTF8))
                {
                    sw.WriteLine("NomeCompra;DataCriacao;DataFechada;NomeArtigo;ArtigoPrevisto;ArtigoNaoPrevisto;QuantidadePrevista;QuantidadeAdquirida;PrecoUnitario");

                    foreach (var compra in comprasFechadas)
                    {
                        var itens = db.ItensCompra.Include("Artigo").Where(i => i.CompraId == compra.Id).ToList();

                        foreach (var item in itens)
                        {
                            string artigoPrevisto = item.IsPrevisto ? "Sim" : "Não";
                            string artigoNaoPrevisto = item.IsPrevisto ? "Não" : "Sim";
                            string nomeArtigo = item.Artigo?.Nome ?? "N/A";

                            sw.WriteLine($"{compra.Nome};{compra.DataCriacao:yyyy-MM-dd};{compra.DataFecho:yyyy-MM-dd};{nomeArtigo};{artigoPrevisto};{artigoNaoPrevisto};{item.QuantidadePrevista};{item.QuantidadeAdquirida};{item.PrecoUnitario:F2}");
                        }
                    }
                }
            }
        }

        // Estatísticas Completas
        private void ExportarEstatisticasCompletas(string caminho)
        {
            using (StreamWriter sw = new StreamWriter(caminho, false, Encoding.UTF8))
            {
                // Resumo Mensal
                sw.WriteLine("=== RESUMO MENSAL ===");
                sw.WriteLine("Mês/Ano;Orçamento (€);Total Gasto (€);Diferença (€)");
                var resumo = _controller.GetResumoMensal();
                foreach (var item in resumo)
                {
                    sw.WriteLine($"{item.MesAno};{item.Orcamento:F2};{item.TotalGasto:F2};{item.Diferenca:F2}");
                }

                sw.WriteLine();
                sw.WriteLine("=== COMPRAS FECHADAS ===");
                sw.WriteLine("Compra;Data Fecho;Itens Previstos;Itens Não Previstos;% Previstos;% Não Previstos");
                var compras = _controller.GetResumoComprasFechadas();
                foreach (var item in compras)
                {
                    sw.WriteLine($"{item.NomeCompra};{item.DataFecho:yyyy-MM-dd};{item.ItensPrevistos};{item.ItensNaoPrevistos};{item.PercentagemPrevistos:F2};{item.PercentagemNaoPrevistos:F2}");
                }

                sw.WriteLine();
                sw.WriteLine("=== SUGESTÕES ===");
                sw.WriteLine($"Orçamento sugerido próximo mês;{_controller.SugerirOrcamentoProximoMes():F2}");
                sw.WriteLine("Lista de compras sugerida;");
                var sugestoes = _controller.SugerirListaCompras();
                foreach (var item in sugestoes)
                {
                    sw.WriteLine($";{item.NomeArtigo};{item.Quantidade}");
                }
            }
        }

        // Lista de Compras
        private void ExportarListaCompras(string caminho)
        {
            using (var db = new CasaPoupancaDB())
            {
                var compras = db.Compras
                    .Where(c => c.CriadoPorId == Session.UtilizadorId)
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();

                using (StreamWriter sw = new StreamWriter(caminho, false, Encoding.UTF8))
                {
                    sw.WriteLine("ID;Nome da Compra;Data Criação;Estado");
                    foreach (var compra in compras)
                    {
                        string estado = compra.IsFechada ? "Fechada" : "Aberta";
                        sw.WriteLine($"{compra.Id};{compra.Nome};{compra.DataCriacao:yyyy-MM-dd HH:mm};{estado}");
                    }
                }
            }
        }

        // Utilizadores
        private void ExportarUtilizadores(string caminho)
        {
            using (var db = new CasaPoupancaDB())
            {
                var utilizadores = db.Utilizadores.OrderBy(u => u.Username).ToList();

                using (StreamWriter sw = new StreamWriter(caminho, false, Encoding.UTF8))
                {
                    sw.WriteLine("ID;Username;Nome;DataRegisto");
                    foreach (var user in utilizadores)
                    {
                        sw.WriteLine($"{user.Id};{user.Username};{user.DataRegisto:yyyy-MM-dd}");
                    }
                }
            }
        }

        // Artigos
        private void ExportarArtigos(string caminho)
        {
            using (var db = new CasaPoupancaDB())
            {
                var artigos = db.Artigos.Include("TipoArtigo").OrderBy(a => a.Nome).ToList();

                using (StreamWriter sw = new StreamWriter(caminho, false, Encoding.UTF8))
                {
                    sw.WriteLine("ID;Nome do Artigo;Tipo");
                    foreach (var artigo in artigos)
                    {
                        sw.WriteLine($"{artigo.Id};{artigo.Nome};{artigo.TipoArtigo?.Nome ?? "Sem tipo"}");
                    }
                }
            }
        }

        // Orçamentos
        private void ExportarOrcamentos(string caminho)
        {
            using (var db = new CasaPoupancaDB())
            {
                var orcamentos = db.Orcamentos.OrderByDescending(o => o.Ano).ThenByDescending(o => o.Mes).ToList();

                using (StreamWriter sw = new StreamWriter(caminho, false, Encoding.UTF8))
                {
                    sw.WriteLine("ID;Mês;Ano;Valor (€);Data Criação;Criado Por;Data Alteração;Alterado Por");
                    foreach (var orc in orcamentos)
                    {
                        string nomeMes = ObterNomeMes(orc.Mes);
                        string criadoPor = orc.CriadoPor?.Username ?? "N/A";
                        string alteradoPor = orc.AlteradoPor?.Username ?? "N/A";
                        sw.WriteLine($"{orc.Id};{nomeMes};{orc.Ano};{orc.Valor:F2};{orc.DataCriacao:yyyy-MM-dd};{criadoPor};{orc.DataAlteracao:yyyy-MM-dd};{alteradoPor}");
                    }
                }
            }
        }

        private string ObterNomeMes(int mes)
        {
            string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
                               "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            return meses[mes - 1];
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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