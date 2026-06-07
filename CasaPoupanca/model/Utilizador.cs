using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupanca.models
{
    public class Utilizador
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DataRegisto { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
    }

    public class UtilizadorDisplay
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public DateTime DataRegisto { get; set; }

        // Propriedade para exibir no ListBox
        public string DisplayText => $"{Id} - {Username} | Registo: {DataRegisto:dd/MM/yyyy}";
    }
}
