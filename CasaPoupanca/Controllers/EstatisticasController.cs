using CasaPoupança.database;
using CasaPoupanca.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CasaPoupanca.Controllers
{
    public class EstatisticasController : IDisposable
    {
        private readonly CasaPoupancaDB _db;

        public EstatisticasController()
        {
            _db = new CasaPoupancaDB();
        }

        public List<Estatisticas.ResumoMensal> GetResumoMensal()
        {
            var orcamentos = _db.Orcamentos.ToList();
            var resultado = new List<Estatisticas.ResumoMensal>();

            foreach (var orcamento in orcamentos)
            {
                decimal totalGasto = CalcularTotalGastoMes(orcamento.Mes, orcamento.Ano);
                resultado.Add(new Estatisticas.ResumoMensal
                {
                    Mes = orcamento.Mes,
                    Ano = orcamento.Ano,
                    MesAno = $"{ObterNomeMes(orcamento.Mes)} {orcamento.Ano}",
                    Orcamento = orcamento.Valor,
                    TotalGasto = totalGasto,
                    Diferenca = orcamento.Valor - totalGasto
                });
            }

            return resultado.OrderByDescending(r => r.Ano).ThenByDescending(r => r.Mes).ToList();
        }

        private decimal CalcularTotalGastoMes(int mes, int ano)
        {
            var comprasFechadas = _db.Compras
                .Where(c => c.DataFecho.HasValue &&
                            c.DataFecho.Value.Month == mes &&
                            c.DataFecho.Value.Year == ano &&
                            c.IsFechada)
                .ToList();

            decimal totalGasto = 0;
            foreach (var compra in comprasFechadas)
            {
                totalGasto += _db.ItensCompra
                    .Where(i => i.CompraId == compra.Id)
                    .Sum(i => (decimal?)i.QuantidadeAdquirida * i.PrecoUnitario) ?? 0;
            }
            return totalGasto;
        }

        public List<Estatisticas.ResumoCompra> GetResumoComprasFechadas()
        {
            var comprasFechadas = _db.Compras.Where(c => c.IsFechada).ToList();
            var resultado = new List<Estatisticas.ResumoCompra>();

            foreach (var compra in comprasFechadas)
            {
                int totalItens = _db.ItensCompra.Count(i => i.CompraId == compra.Id);
                int itensPrevistos = _db.ItensCompra.Count(i => i.CompraId == compra.Id && i.IsPrevisto);
                int itensNaoPrevistos = totalItens - itensPrevistos;

                decimal percentagemPrevistos = totalItens > 0 ? (decimal)itensPrevistos / totalItens * 100 : 0;
                decimal percentagemNaoPrevistos = totalItens > 0 ? (decimal)itensNaoPrevistos / totalItens * 100 : 0;

                resultado.Add(new Estatisticas.ResumoCompra
                {
                    CompraId = compra.Id,
                    NomeCompra = compra.Nome,
                    DataCriacao = compra.DataCriacao,
                    DataFecho = compra.DataFecho ?? DateTime.MinValue,
                    TotalItens = totalItens,
                    ItensPrevistos = itensPrevistos,
                    ItensNaoPrevistos = itensNaoPrevistos,
                    PercentagemPrevistos = Math.Round(percentagemPrevistos, 2),
                    PercentagemNaoPrevistos = Math.Round(percentagemNaoPrevistos, 2)
                });
            }

            return resultado.OrderByDescending(r => r.DataFecho).ToList();
        }

        public decimal SugerirOrcamentoProximoMes()
        {
            int mesAtual = DateTime.Now.Month;
            int anoAtual = DateTime.Now.Year;

            // Buscar orçamentos dos últimos 3 meses
            var orcamentosAnteriores = _db.Orcamentos
                .Where(o => (o.Ano < anoAtual) || (o.Ano == anoAtual && o.Mes < mesAtual))
                .OrderByDescending(o => o.Ano)
                .ThenByDescending(o => o.Mes)
                .Take(3)
                .ToList();

            if (orcamentosAnteriores.Count == 0)
                return 500; // Valor padrão

            return Math.Round(orcamentosAnteriores.Average(o => o.Valor), 2);
        }

        public List<Estatisticas.SugestaoItem> SugerirListaCompras()
        {
            // Determinar a semana atual do mês (1ª, 2ª, 3ª ou 4ª)
            int dia = DateTime.Now.Day;
            int semanaAtual = (int)Math.Ceiling(dia / 7.0);

            // Buscar compras fechadas dos meses anteriores na mesma semana
            var comprasMesmoPeriodo = _db.Compras
                .Where(c => c.IsFechada &&
                            c.DataCriacao < DateTime.Now &&
                            (int)Math.Ceiling(c.DataCriacao.Day / 7.0) == semanaAtual)
                .ToList();

            // Agrupar por artigo e somar quantidades
            var itensAgrupados = new Dictionary<string, int>();

            foreach (var compra in comprasMesmoPeriodo)
            {
                var itens = _db.ItensCompra
                    .Where(i => i.CompraId == compra.Id && i.IsPrevisto)
                    .Include("Artigo")
                    .ToList();

                foreach (var item in itens)
                {
                    string nomeArtigo = item.Artigo?.Nome ?? "Artigo Desconhecido";
                    if (itensAgrupados.ContainsKey(nomeArtigo))
                        itensAgrupados[nomeArtigo] += item.QuantidadePrevista;
                    else
                        itensAgrupados[nomeArtigo] = item.QuantidadePrevista;
                }
            }

            // Ordenar por quantidade (mais comprados primeiro) e top 5
            return itensAgrupados
                .OrderByDescending(i => i.Value)
                .Take(5)
                .Select(i => new Estatisticas.SugestaoItem { NomeArtigo = i.Key, Quantidade = i.Value })
                .ToList();
        }

        private string ObterNomeMes(int mes)
        {
            string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho",
                               "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };
            return meses[mes - 1];
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}