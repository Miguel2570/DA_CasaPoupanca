using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupanca.models
{
    internal class Orcamento
    {
        [Key]
        public int Id { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public decimal Valor { get; set; }
        public int CriadoPorId { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? AlteradorPorId { get; set; }
        public int? DataAlteracao { get; set; }
        public virtual Utilizador CriadorPor { get; set; }
        public virtual Utilizador AlteradoPor { get; set; }
    }
}
