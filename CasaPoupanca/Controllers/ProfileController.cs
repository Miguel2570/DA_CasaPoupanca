using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupanca.Controllers
{
    public class ProfileController
    {
        public Utilizador GetUtilizador(int utilizadorId)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Utilizadores.Find(utilizadorId);
            }
        }

        public int GetTotalCompras(int utilizadorId)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Compras.Count(c => c.CriadoPorId == utilizadorId);
            }
        }

        public decimal GetTotalGasto(int utilizadorId)
        {
            using (var db = new CasaPoupancaDB())
            {
                var comprasFechadas = db.Compras
                    .Where(c => c.CriadoPorId == utilizadorId && c.IsFechada)
                    .ToList();

                decimal totalGasto = 0;
                foreach (var compra in comprasFechadas)
                {
                    totalGasto += db.ItensCompra
                        .Where(i => i.CompraId == compra.Id)
                        .Sum(i => (decimal?)(i.QuantidadeAdquirida * i.PrecoUnitario)) ?? 0;
                }
                return totalGasto;
            }
        }

        public DateTime? GetDataUltimaCompra(int utilizadorId)
        {
            using (var db = new CasaPoupancaDB())
            {
                var ultimaCompra = db.Compras
                    .Where(c => c.CriadoPorId == utilizadorId)
                    .OrderByDescending(c => c.DataCriacao)
                    .FirstOrDefault();

                return ultimaCompra?.DataCriacao;
            }
        }
    }
}
