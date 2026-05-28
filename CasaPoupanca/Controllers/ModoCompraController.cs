using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupanca.Controllers
{
    public class ModoCompraController : IDisposable
    {
        private readonly CasaPoupancaDB _db;

        public ModoCompraController()
        {
            _db = new CasaPoupancaDB();
        }

        public Compra GetCompraById(int id)
        {
            return _db.Compras.Find(id);
        }

        // ==================== ITENS ====================

        public List<ItemCompra> GetItensPrevistos(int compraId)
        {
            return _db.ItensCompra
                .Where(i => i.CompraId == compraId && i.IsPrevisto)
                .Include("Artigo")
                .Include("Artigo.TipoArtigo")
                .ToList();
        }

        public List<ItemCompra> GetItensNaoPrevistos(int compraId)
        {
            return _db.ItensCompra
                .Where(i => i.CompraId == compraId && !i.IsPrevisto)
                .ToList();
        }

        public bool AddItemNaoPrevisto(ItemCompra item)
        {
            _db.ItensCompra.Add(item);
            _db.SaveChanges();
            return true;
        }

        public bool AdquirirItem(int itemId, int quantidade, decimal precoUnitario)
        {
            var item = _db.ItensCompra.Find(itemId);
            if (item == null)
                return false;

            item.QuantidadeAdquirida = quantidade;
            item.PrecoUnitario = precoUnitario;
            _db.SaveChanges();
            return true;
        }

        public bool RemoverItemNaoPrevisto(int itemId)
        {
            var item = _db.ItensCompra.Find(itemId);
            if (item == null)
                return false;

            _db.ItensCompra.Remove(item);
            _db.SaveChanges();
            return true;
        }

        public bool AddItemPrevisto(ItemCompra item)
        {
            _db.ItensCompra.Add(item);
            _db.SaveChanges();
            return true;
        }

        // ==================== ORÇAMENTO ====================

        public decimal GetOrcamentoDisponivel(int utilizadorId, int compraId)
        {
            int mesAtual = DateTime.Now.Month;
            int anoAtual = DateTime.Now.Year;

            var orcamento = _db.Orcamentos
                .FirstOrDefault(o => o.Mes == mesAtual && o.Ano == anoAtual);

            decimal valorOrcamento = orcamento?.Valor ?? 0;

            var comprasFechadas = _db.Compras
                .Where(c => c.DataCriacao.Month == mesAtual &&
                            c.DataCriacao.Year == anoAtual &&
                            c.IsFechada &&
                            c.CriadoPorId == utilizadorId)
                .ToList();

            decimal totalGasto = 0;
            foreach (var compra in comprasFechadas)
            {
                totalGasto += _db.ItensCompra
                    .Where(i => i.CompraId == compra.Id)
                    .Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);
            }

            var gastoAtual = _db.ItensCompra
                .Where(i => i.CompraId == compraId)
                .Sum(i => i.QuantidadeAdquirida * i.PrecoUnitario);

            return valorOrcamento - totalGasto - gastoAtual;
        }

        public int CountItensNaoAdquiridos(int compraId)
        {
            return _db.ItensCompra
                .Count(i => i.CompraId == compraId && i.IsPrevisto && i.QuantidadeAdquirida == 0);
        }

        public void FecharCompra(int compraId, int utilizadorId)
        {
            var compra = _db.Compras.Find(compraId);
            if (compra != null)
            {
                compra.IsFechada = true;
                compra.FechadaPorId = utilizadorId;
                compra.DataFecho = DateTime.Now;
                _db.SaveChanges();
            }
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
