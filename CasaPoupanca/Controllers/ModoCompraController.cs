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
                    .ToList();
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

        public bool AdquirirItem(int itemId, int quantidade, decimal precoUnitario)
        {
            using (var db = new CasaPoupancaDB())
            {
                var item = db.ItensCompra.Find(itemId);
                if (item == null)
                    return false;

                item.QuantidadeAdquirida = quantidade;
                item.PrecoUnitario = precoUnitario;
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

        public bool AddItemPrevisto(ItemCompra item)
        {
            using (var db = new CasaPoupancaDB())
            {
                db.ItensCompra.Add(item);
                db.SaveChanges();
                return true;
            }
        }

        public int CountItensNaoAdquiridos(int compraId)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.ItensCompra
                    .Count(i => i.CompraId == compraId && i.IsPrevisto && i.QuantidadeAdquirida == 0);
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
                int mesAtual = DateTime.Now.Month;
                int anoAtual = DateTime.Now.Year;

                // Busca o orçamento do mês atual
                var orcamento = db.Orcamentos
                    .FirstOrDefault(o => o.Mes == mesAtual && o.Ano == anoAtual);

                if (orcamento == null)
                    return 0;

                // Calcula o total gasto no mês atual (todas as compras fechadas)
                var comprasFechadas = db.Compras
                    .Where(c => c.IsFechada && c.DataFecho.HasValue &&
                                c.DataFecho.Value.Month == mesAtual &&
                                c.DataFecho.Value.Year == anoAtual)
                    .ToList();

                decimal totalGasto = 0;
                foreach (var compra in comprasFechadas)
                {
                    var itens = db.ItensCompra.Where(i => i.CompraId == compra.Id);
                    totalGasto += itens.Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
                }

                return orcamento.Valor - totalGasto;
            }
        }
    }
}