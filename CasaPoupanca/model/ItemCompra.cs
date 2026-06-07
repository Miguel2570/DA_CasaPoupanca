using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaPoupanca.models
{
    public class ItemCompra
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

        [NotMapped]
        public string DisplayName
        {
            get
            {
                if (Artigo == null)
                    return $"{QuantidadeAdquirida} x €{PrecoUnitario:F2} = €{QuantidadeAdquirida * PrecoUnitario:F2}";

                return $"{Artigo.Nome} - {QuantidadeAdquirida} x €{PrecoUnitario:F2} = €{QuantidadeAdquirida * PrecoUnitario:F2}";
            }
        }
    }
}