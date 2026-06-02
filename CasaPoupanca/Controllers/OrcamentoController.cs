using CasaPoupanca.models;
using CasaPoupança.database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CasaPoupanca.Controllers
{
    public class OrcamentoController : IDisposable
    {
        private readonly CasaPoupancaDB _db;

        public OrcamentoController()
        {
            _db = new CasaPoupancaDB();
        }

        public List<Orcamento> GetAllOrcamentos()
        {
            return _db.Orcamentos
                .OrderByDescending(o => o.Ano)
                .ThenByDescending(o => o.Mes)
                .ToList();
        }

        public Orcamento GetOrcamentoPorMesAno(int mes, int ano)
        {
            return _db.Orcamentos
                .FirstOrDefault(o => o.Mes == mes && o.Ano == ano);
        }

        public bool AddOrcamento(Orcamento orcamento)
        {
            // Verificar se já existe orçamento para este mês/ano
            if (_db.Orcamentos.Any(o => o.Mes == orcamento.Mes && o.Ano == orcamento.Ano))
                return false;

            _db.Orcamentos.Add(orcamento);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateOrcamento(Orcamento orcamento)
        {
            var existing = _db.Orcamentos.Find(orcamento.Id);
            if (existing == null)
                return false;

            existing.Valor = orcamento.Valor;
            existing.AlteradoPorId = orcamento.AlteradoPorId;
            existing.DataAlteracao = orcamento.DataAlteracao;
            _db.SaveChanges();
            return true;
        }

        public bool DeleteOrcamento(int id)
        {
            var orcamento = _db.Orcamentos.Find(id);
            if (orcamento == null)
                return false;

            _db.Orcamentos.Remove(orcamento);
            _db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}