using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CasaPoupanca.Controllers
{
    public class CompraController : IDisposable
    {
        private readonly CasaPoupancaDB _db;

        public CompraController()
        {
            _db = new CasaPoupancaDB();
        }

        public List<Compra> GetComprasByUtilizador(int utilizadorId)
        {
            return _db.Compras
                .Where(c => c.CriadoPorId == utilizadorId)
                .OrderByDescending(c => c.DataCriacao)
                .ToList();
        }

        public Compra GetCompraById(int id)
        {
            return _db.Compras.Find(id);
        }

        public bool AddCompra(Compra compra)
        {
            _db.Compras.Add(compra);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateCompra(Compra compra)
        {
            var existing = _db.Compras.Find(compra.Id);
            if (existing == null)
                return false;

            existing.Nome = compra.Nome;
            existing.AlteradoPorId = compra.AlteradoPorId;
            existing.DataAlteracao = compra.DataAlteracao;
            _db.SaveChanges();
            return true;
        }

        public bool DeleteCompra(int id)
        {
            var compra = _db.Compras.Find(id);
            if (compra == null)
                return false;

            if (compra.IsFechada)
                return false;

            _db.Compras.Remove(compra);
            _db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
