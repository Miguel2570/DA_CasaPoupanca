using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupanca.models
{
    internal class Compra
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CriadoPorId { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? AlteradoPorId { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool IsFechada { get; set; }
        public int? FechadaPorId { get; set; }
        public DateTime? DataFecho { get; set; }

        public virtual Utilizador CriadoPor { get; set; }
        public virtual Utilizador AlteradoPor { get; set; }
        public virtual Utilizador FechadaPor { get; set; }
        public virtual ICollection<ItemCompra> Itens { get; set; }

        public Compra()
        {
            Itens = new List<ItemCompra>();
        }
    }
}
