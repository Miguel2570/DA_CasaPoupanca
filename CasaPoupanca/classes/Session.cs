using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupanca.Helpers
{
    public class Session
    {
        public static int UtilizadorId { get; set; }
        public static string Username { get; set; }

        public static void SetUser(int id, string username)
        {
            UtilizadorId = id;
            Username = username;
        }
    }
}
