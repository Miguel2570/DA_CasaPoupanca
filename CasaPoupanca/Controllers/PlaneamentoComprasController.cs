using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CasaPoupanca.Controllers
{
    public class PlaneamentoComprasController
    {
        private CompraController _compraController;
        private ModoCompraController _modoCompraController;

        public PlaneamentoComprasController()
        {
            _compraController = new CompraController();
            _modoCompraController = new ModoCompraController();
        }

        public List<Compra> GetComprasByUtilizador(int utilizadorId)
        {
            return _compraController.GetComprasByUtilizador(utilizadorId);
        }

        public List<Compra> FiltrarCompras(int utilizadorId, string filtro)
        {
            var compras = GetComprasByUtilizador(utilizadorId);

            if (string.IsNullOrEmpty(filtro) || filtro == "Todas")
                return compras;

            if (filtro == "Aberta")
                return compras.Where(c => !c.IsFechada).ToList();

            return compras.Where(c => c.IsFechada).ToList();
        }

        // CORRIGIDO: Método com apenas 1 argumento (compraId)
        public decimal GetTotalGasto(int compraId)
        {
            return _modoCompraController.GetTotalGastoCompra(compraId);
        }

        public Compra GetCompraDetalhes(int compraId)
        {
            return _compraController.GetCompraById(compraId);
        }

        public string GetEstadoTexto(bool isFechada)
        {
            return isFechada ? "Fechada" : "Aberta";
        }
    }
}