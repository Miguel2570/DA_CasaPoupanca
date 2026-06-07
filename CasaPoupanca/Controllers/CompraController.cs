using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CasaPoupanca.Controllers
{
    public class CompraController
    {
        public List<Compra> GetComprasByUtilizador(int utilizadorId)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Compras
                    .Where(c => c.CriadoPorId == utilizadorId)
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();
            }
        }

        public List<Compra> GetComprasPorUtilizador(int utilizadorId)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Compras
                    .Where(c => c.CriadoPorId == utilizadorId)
                    .OrderByDescending(c => c.DataCriacao)
                    .ToList();
            }
        }

        public Compra GetCompraById(int id)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Compras.Find(id);
            }
        }

        public bool AddCompra(Compra compra)
        {
            using (var db = new CasaPoupancaDB())
            {
                db.Compras.Add(compra);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateCompra(Compra compra)
        {
            using (var db = new CasaPoupancaDB())
            {
                var existing = db.Compras.Find(compra.Id);
                if (existing == null)
                    return false;

                existing.Nome = compra.Nome;
                existing.AlteradoPorId = compra.AlteradoPorId;
                existing.DataAlteracao = compra.DataAlteracao;
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteCompra(int id)
        {
            using (var db = new CasaPoupancaDB())
            {
                var compra = db.Compras.Find(id);
                if (compra == null)
                    return false;

                if (compra.IsFechada)
                    return false;

                db.Compras.Remove(compra);
                db.SaveChanges();
                return true;
            }
        }

        public List<Compra> GetComprasFechadasPorMes(int mes, int ano, int utilizadorId)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Compras
                    .Where(c => c.DataCriacao.Month == mes &&
                                c.DataCriacao.Year == ano &&
                                c.IsFechada &&
                                c.CriadoPorId == utilizadorId)
                    .ToList();
            }
        }

        public decimal GetTotalGastoComprasFechadas(int mes, int ano, int utilizadorId)
        {
            using (var db = new CasaPoupancaDB())
            {
                var totalGasto = db.Compras
                    .Where(c => c.DataCriacao.Month == mes &&
                                c.DataCriacao.Year == ano &&
                                c.IsFechada &&
                                c.CriadoPorId == utilizadorId)
                    .SelectMany(c => db.ItensCompra.Where(i => i.CompraId == c.Id))
                    .Sum(i => (decimal?)i.QuantidadeAdquirida * i.PrecoUnitario) ?? 0;

                return totalGasto;
            }
        }
        // Itens Previstos

        public List<ItemCompra> GetItensPrevistos(int compraId)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.ItensCompra
                    .Where(i => i.CompraId == compraId && i.IsPrevisto)
                    .Include(i => i.Artigo)
                    .Include(i => i.Artigo.TipoArtigo)
                    .ToList();
            }
        }

        public bool AddItemPrevisto(ItemCompra item)
        {
            using (var db = new CasaPoupancaDB())
            {
                db.ItensCompra.Add(item);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateItemPrevisto(ItemCompra item)
        {
            using (var db = new CasaPoupancaDB())
            {
                var existing = db.ItensCompra.Find(item.Id);
                if (existing == null)
                    return false;

                existing.QuantidadeAdquirida = item.QuantidadeAdquirida;
                existing.PrecoUnitario = item.PrecoUnitario;
                existing.Observacao = item.Observacao;
                db.SaveChanges();
                return true;
            }
        }

        public bool RemoveItemPrevisto(int itemId)
        {
            using (var db = new CasaPoupancaDB())
            {
                var item = db.ItensCompra.Find(itemId);
                if (item == null)
                    return false;

                db.ItensCompra.Remove(item);
                db.SaveChanges();
                return true;
            }
        }
    }
}