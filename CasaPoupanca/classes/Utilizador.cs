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
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataRegisto { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
    }
}
