using CasaPoupanca.models;
using CasaPoupança.database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CasaPoupanca.Controllers
{
    public class OrcamentoController
    {
        public List<Orcamento> GetAllOrcamentos()
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Orcamentos
                    .OrderByDescending(o => o.Ano)
                    .ThenByDescending(o => o.Mes)
                    .ToList();
            }
        }

        public Orcamento GetOrcamentoPorMesAno(int mes, int ano)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Orcamentos
                    .FirstOrDefault(o => o.Mes == mes && o.Ano == ano);
            }
        }

        public bool AddOrcamento(Orcamento orcamento)
        {
            using (var db = new CasaPoupancaDB())
            {
                // Verificar se já existe orçamento para este mês/ano
                if (db.Orcamentos.Any(o => o.Mes == orcamento.Mes && o.Ano == orcamento.Ano))
                    return false;

                db.Orcamentos.Add(orcamento);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateOrcamento(Orcamento orcamento)
        {
            using (var db = new CasaPoupancaDB())
            {
                var existing = db.Orcamentos.Find(orcamento.Id);
                if (existing == null)
                    return false;

                existing.Valor = orcamento.Valor;
                existing.AlteradoPorId = orcamento.AlteradoPorId;
                existing.DataAlteracao = orcamento.DataAlteracao;
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteOrcamento(int id)
        {
            using (var db = new CasaPoupancaDB())
            {
                var orcamento = db.Orcamentos.Find(id);
                if (orcamento == null)
                    return false;

                db.Orcamentos.Remove(orcamento);
                db.SaveChanges();
                return true;
            }
        }

        public Orcamento GetOrcamentoAtual()
        {
            int mesAtual = DateTime.Now.Month;
            int anoAtual = DateTime.Now.Year;
            return GetOrcamentoPorMesAno(mesAtual, anoAtual);
        }

        public decimal GetValorOrcamentoAtual()
        {
            var orcamento = GetOrcamentoAtual();
            return orcamento?.Valor ?? 0;
        }
    }
}