using CasaPoupanca.models;
using CasaPoupança.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CasaPoupanca.Controllers
{
    public class OrcamentoController
    {
        public List<Orcamento> GetAllOrcamentos()
        {
            try
            {
                using (var db = new CasaPoupancaDB())
                {
                    return db.Orcamentos
                        .OrderByDescending(o => o.Ano)
                        .ThenByDescending(o => o.Mes)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<Orcamento>();
            }
        }

        public Orcamento GetOrcamentoPorMesAno(int mes, int ano)
        {
            try
            {
                using (var db = new CasaPoupancaDB())
                {
                    return db.Orcamentos
                        .FirstOrDefault(o => o.Mes == mes && o.Ano == ano);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddOrcamento(Orcamento orcamento)
        {
            try
            {
                using (var db = new CasaPoupancaDB())
                {
                    // Verificar se já existe orçamento para este mês/ano
                    if (db.Orcamentos.Any(o => o.Mes == orcamento.Mes && o.Ano == orcamento.Ano))
                    {
                        return false;
                    }

                    db.Orcamentos.Add(orcamento);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateOrcamento(Orcamento orcamento)
        {
            try
            {
                using (var db = new CasaPoupancaDB())
                {
                    var existing = db.Orcamentos.Find(orcamento.Id);
                    if (existing == null)
                    {
                        return false;
                    }

                    // Verificar se já existe outro orçamento com o mesmo mês/ano (exceto o atual)
                    var outroOrcamento = db.Orcamentos
                        .FirstOrDefault(o => o.Mes == orcamento.Mes &&
                                             o.Ano == orcamento.Ano &&
                                             o.Id != orcamento.Id);

                    if (outroOrcamento != null)
                    {
                        return false;
                    }

                    existing.Mes = orcamento.Mes;
                    existing.Ano = orcamento.Ano;
                    existing.Valor = orcamento.Valor;
                    existing.AlteradoPorId = orcamento.AlteradoPorId;
                    existing.DataAlteracao = orcamento.DataAlteracao;

                    int salvos = db.SaveChanges();
                    return salvos > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteOrcamento(int id)
        {
            try
            {
                using (var db = new CasaPoupancaDB())
                {
                    var orcamento = db.Orcamentos.Find(id);
                    if (orcamento == null)
                    {
                        return false;
                    }

                    db.Orcamentos.Remove(orcamento);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Orcamento GetOrcamentoAtual()
        {
            try
            {
                int mesAtual = DateTime.Now.Month;
                int anoAtual = DateTime.Now.Year;
                return GetOrcamentoPorMesAno(mesAtual, anoAtual);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public decimal GetValorOrcamentoAtual()
        {
            try
            {
                var orcamento = GetOrcamentoAtual();
                return orcamento?.Valor ?? 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public decimal CalcularTotalGastoMes(int mes, int ano)
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
                        totalGasto += db.ItensCompra
                            .Where(i => i.CompraId == compra.Id)
                            .Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
                    }
                    return totalGasto;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}