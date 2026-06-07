using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CasaPoupanca.Controllers
{
    public class ModoCompraController
    {
        public Compra GetCompraById(int id)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Compras.Find(id);
            }
        }

        // Items

        public List<ItemCompra> GetItensPrevistos(int compraId)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.ItensCompra
                    .Where(i => i.CompraId == compraId && i.IsPrevisto)
                    .Include("Artigo")
                    .Include("Artigo.TipoArtigo")
                    .ToList();
            }
        }

        public List<ItemCompra> GetItensNaoPrevistos(int compraId)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.ItensCompra
                    .Where(i => i.CompraId == compraId && !i.IsPrevisto)
                    .Include(i => i.Artigo)
                    .Include(i => i.Artigo.TipoArtigo)
                    .ToList();
            }
        }
        public decimal GetTotalGastoCompra(int compraId)
        {
            using (var db = new CasaPoupancaDB())
            {
                var total = db.ItensCompra
                    .Where(i => i.CompraId == compraId)
                    .Sum(i => (decimal?)i.QuantidadeAdquirida * i.PrecoUnitario);

                return total ?? 0;
            }
        }

        public int CountItensNaoAdquiridos(int compraId)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.ItensCompra
                    .Where(i => i.CompraId == compraId && i.QuantidadeAdquirida < i.QuantidadePrevista)
                    .Count();
            }
        }

        public bool AddItemNaoPrevisto(ItemCompra item)
        {
            using (var db = new CasaPoupancaDB())
            {
                db.ItensCompra.Add(item);
                db.SaveChanges();
                return true;
            }
        }

        public bool RemoverItemNaoPrevisto(int itemId)
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

        public void AdquirirItemPrevisto(int itemId, int quantidade, decimal precoUnitario)
        {
            using (var db = new CasaPoupancaDB())
            {
                var item = db.ItensCompra.Find(itemId);
                if (item == null)
                    throw new Exception("Item não encontrado.");

                if (!item.IsPrevisto)
                    throw new Exception("Este não é um item previsto.");

                item.QuantidadeAdquirida = quantidade;
                item.PrecoUnitario = precoUnitario;
                db.SaveChanges();
            }
        }

        public void AdquirirItemNaoPrevisto(int itemId, int quantidade, decimal precoUnitario)
        {
            using (var db = new CasaPoupancaDB())
            {
                var item = db.ItensCompra.Find(itemId);
                if (item == null)
                    throw new Exception("Item não encontrado.");

                if (item.IsPrevisto)
                    throw new Exception("Este método é apenas para itens não previstos.");

                // Atualiza quantidade e preço
                item.QuantidadeAdquirida = quantidade;
                item.PrecoUnitario = precoUnitario;

                db.SaveChanges();
            }
        }

        public void FecharCompra(int compraId, int utilizadorId)
        {
            using (var db = new CasaPoupancaDB())
            {
                var compra = db.Compras.Find(compraId);
                if (compra != null)
                {
                    compra.IsFechada = true;
                    compra.FechadaPorId = utilizadorId;
                    compra.DataFecho = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

        public decimal GetOrcamentoDisponivel(int utilizadorId)
        {
            using (var db = new CasaPoupancaDB())
            {
                var hoje = DateTime.Now;

                var orcamento = db.Orcamentos
                    .FirstOrDefault(o => o.CriadoPorId == utilizadorId && o.Mes == hoje.Month && o.Ano == hoje.Year);

                if (orcamento == null) return 0;

                var totalGasto = (from c in db.Compras
                                  join i in db.ItensCompra on c.Id equals i.CompraId
                                  where c.CriadoPorId == utilizadorId
                                     && c.IsFechada
                                     && c.DataCriacao.Year == hoje.Year
                                     && c.DataCriacao.Month == hoje.Month
                                  select (decimal?)i.QuantidadeAdquirida * i.PrecoUnitario)
                                  .DefaultIfEmpty(0)
                                  .Sum() ?? 0;

                return orcamento.Valor - totalGasto;
            }
        }
    }
}