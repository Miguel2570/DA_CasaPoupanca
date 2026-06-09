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

        public ItemCompra GetItemCompraById(int id)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.ItensCompra
                    .Include(i => i.Artigo)
                    .FirstOrDefault(i => i.Id == id);
            }
        }

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

        // CORRIGIDO: Método com apenas 1 argumento
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
                    .Count(i => i.CompraId == compraId && i.IsPrevisto && i.QuantidadeAdquirida == 0);
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

        public decimal GetOrcamentoDisponivel(int utilizadorId, int mes, int ano)
        {
            using (var db = new CasaPoupancaDB())
            {
                var orcamento = db.Orcamentos
                    .FirstOrDefault(o => o.CriadoPorId == utilizadorId && o.Mes == mes && o.Ano == ano);

                decimal valorOrcamento = orcamento?.Valor ?? 0;

                var totalGasto = db.Compras
                    .Where(c => c.CriadoPorId == utilizadorId &&
                                c.DataCriacao.Year == ano &&
                                c.DataCriacao.Month == mes &&
                                c.IsFechada)
                    .SelectMany(c => db.ItensCompra.Where(i => i.CompraId == c.Id))
                    .Sum(i => (decimal?)i.QuantidadeAdquirida * i.PrecoUnitario) ?? 0;

                return valorOrcamento - totalGasto;
            }
        }

        public bool RemoverItemPrevisto(int itemId)
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

        public void AdquirirItemNaoPrevisto(int itemId, int quantidade, decimal precoUnitario)
        {
            using (var db = new CasaPoupancaDB())
            {
                var item = db.ItensCompra.Find(itemId);
                if (item == null)
                    throw new Exception("Item não encontrado.");

                item.QuantidadeAdquirida = quantidade;
                item.PrecoUnitario = precoUnitario;
                db.SaveChanges();
            }
        }
        public bool UpdateItemNaoPrevisto(ItemCompra item)
        {
            using (var db = new CasaPoupancaDB())
            {
                var existing = db.ItensCompra.Find(item.Id);
                if (existing == null)
                    return false;

                existing.ArtigoId = item.ArtigoId;
                existing.QuantidadePrevista = item.QuantidadePrevista;
                existing.PrecoUnitario = item.PrecoUnitario;
                existing.Observacao = item.Observacao;

                db.SaveChanges();
                return true;
            }
        }

        public decimal GetOrcamentoTotal(int utilizadorId, int mes, int ano)
        {
            using (var db = new CasaPoupancaDB())
            {
                var orcamento = db.Orcamentos
                    .FirstOrDefault(o => o.CriadoPorId == utilizadorId && o.Mes == mes && o.Ano == ano);

                return orcamento?.Valor ?? 0;
            }
        }
    }
}