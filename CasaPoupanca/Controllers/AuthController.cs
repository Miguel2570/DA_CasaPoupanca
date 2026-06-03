using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupanca.Controllers
{
    public class AuthController
    {
        public Utilizador Login(string username, string password)
        {
            using (var db = new CasaPoupancaDB())
            {
                // Encripta a password antes de comparar
                string hashedPassword = HashPassword(password);

                return db.Utilizadores.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);
            }
        }

        public bool Register(Utilizador utilizador)
        {
            using (var db = new CasaPoupancaDB())
            {
                if (db.Utilizadores.Any(u => u.Username == utilizador.Username))
                    return false;

                // Encripta a password antes de guardar
                utilizador.Password = HashPassword(utilizador.Password);

                db.Utilizadores.Add(utilizador);
                db.SaveChanges();
                return true;
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
    }
}