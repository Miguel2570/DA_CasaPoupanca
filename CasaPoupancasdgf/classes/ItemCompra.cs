using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupanca.models
{
    internal class ItemCompra
    {
        [Key]
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int ArtigoId { get; set; }
        public int QuantidadePrevista { get; set; }
        public int QuantidadeAdquirida { get; set; }
        public decimal PrecoUnitario { get; set; }
        public bool IsPrevisto { get; set; }
        public string Observacao { get; set; }

        public virtual Compra Compra { get; set; }
        public virtual Artigo Artigo { get; set; }
    }
}
