using CasaPoupança.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupança.database
{
    internal class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<TipoArtigo> TiposArtigo { get; set; }
        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ItemCompra> ItensCompra { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Username unico
            modelBuilder.Entity<Utilizador>()
                .HasIndex(user => user.Username)
                .IsUnique();
        }
    }
}
