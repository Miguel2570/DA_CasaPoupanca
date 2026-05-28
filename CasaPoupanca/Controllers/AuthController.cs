using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupanca.Controllers
{
    public class AuthController : IDisposable
    {
        private readonly CasaPoupancaDB _db;

        public AuthController()
        {
            _db = new CasaPoupancaDB();
        }

        public Utilizador Login(string username, string password)
        {
            return _db.Utilizadores.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public bool Register(Utilizador utilizador)
        {
            if (_db.Utilizadores.Any(u => u.Username == utilizador.Username))
                return false;

            _db.Utilizadores.Add(utilizador);
            _db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
