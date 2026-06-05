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
                MessageBox.Show($"Erro ao buscar orçamentos: {ex.Message}");
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
                MessageBox.Show($"Erro ao buscar orçamento: {ex.Message}");
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
                        MessageBox.Show($"Já existe um orçamento para {orcamento.Mes}/{orcamento.Ano}");
                        return false;
                    }

                    db.Orcamentos.Add(orcamento);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar orçamento: {ex.Message}");
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
                        MessageBox.Show($"Orçamento com ID {orcamento.Id} não encontrado!");
                        return false;
                    }

                    // Verificar se já existe outro orçamento com o mesmo mês/ano (exceto o atual)
                    var outroOrcamento = db.Orcamentos
                        .FirstOrDefault(o => o.Mes == orcamento.Mes &&
                                             o.Ano == orcamento.Ano &&
                                             o.Id != orcamento.Id);

                    if (outroOrcamento != null)
                    {
                        MessageBox.Show($"Já existe um orçamento para {orcamento.Mes}/{orcamento.Ano} (ID: {outroOrcamento.Id})");
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
                MessageBox.Show($"Erro detalhado ao atualizar orçamento: {ex.Message}\n\nStack Trace: {ex.StackTrace}");
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
                        MessageBox.Show($"Orçamento com ID {id} não encontrado!");
                        return false;
                    }

                    db.Orcamentos.Remove(orcamento);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover orçamento: {ex.Message}");
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
                MessageBox.Show($"Erro ao buscar orçamento atual: {ex.Message}");
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
                MessageBox.Show($"Erro ao buscar valor do orçamento atual: {ex.Message}");
                return 0;
            }
        }
    }
}