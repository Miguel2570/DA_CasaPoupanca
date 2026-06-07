using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupanca.model
{
    public class Estatisticas
    {
        public class ResumoMensal
        {
            public int Mes { get; set; }
            public int Ano { get; set; }
            public string MesAno { get; set; }
            public decimal Orcamento { get; set; }
            public decimal TotalGasto { get; set; }
            public decimal Diferenca { get; set; }
        }

        public class ResumoCompra
        {
            public int CompraId { get; set; }
            public string NomeCompra { get; set; }
            public DateTime DataCriacao { get; set; }
            public DateTime DataFecho { get; set; }
            public int TotalItens { get; set; }
            public int ItensPrevistos { get; set; }
            public int ItensNaoPrevistos { get; set; }
            public decimal PercentagemPrevistos { get; set; }
            public decimal PercentagemNaoPrevistos { get; set; }
        }

        public class SugestaoItem
        {
            public string NomeArtigo { get; set; }
            public int Quantidade { get; set; }
        }
    }
}
