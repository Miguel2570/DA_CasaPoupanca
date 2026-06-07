using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CasaPoupanca.Controllers
{
    public class ArtigoController
    {
        // Tipo de Artigo

        public List<TipoArtigo> GetAllTipos()
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.TiposArtigo.OrderBy(t => t.Nome).ToList();
            }
        }

        public List<TipoArtigo> GetTiposComTodos()
        {
            var tipos = GetAllTipos();
            tipos.Insert(0, new TipoArtigo { Id = 0, Nome = "Todos" });
            return tipos;
        }

        // ARTIGOS 

        public List<Artigo> GetAllArtigos()
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Artigos.Include("TipoArtigo").OrderBy(a => a.Nome).ToList();
            }
        }

        public List<Artigo> GetArtigosFiltrados(int? tipoId = null)
        {
            using (var db = new CasaPoupancaDB())
            {
                var query = db.Artigos.Include("TipoArtigo").AsQueryable();

                if (tipoId.HasValue && tipoId > 0)
                {
                    query = query.Where(a => a.TipoArtigoId == tipoId);
                }

                return query.OrderBy(a => a.Nome).ToList();
            }
        }

        public Artigo GetArtigoById(int id)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Artigos.Find(id);
            }
        }

        public bool ArtigoExiste(string nome, int tipoId, int? ignorarId = null)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.Artigos.Any(a => a.Nome == nome && a.TipoArtigoId == tipoId && (!ignorarId.HasValue || a.Id != ignorarId.Value));
            }
        }

        public bool AddArtigo(Artigo artigo)
        {
            using (var db = new CasaPoupancaDB())
            {
                if (ArtigoExiste(artigo.Nome, artigo.TipoArtigoId))
                    return false;

                db.Artigos.Add(artigo);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateArtigo(Artigo artigo)
        {
            using (var db = new CasaPoupancaDB())
            {
                var existing = db.Artigos.Find(artigo.Id);
                if (existing == null)
                    return false;

                if (ArtigoExiste(artigo.Nome, artigo.TipoArtigoId, artigo.Id))
                    return false;

                existing.Nome = artigo.Nome;
                existing.TipoArtigoId = artigo.TipoArtigoId;
                existing.PrecoUnitario = artigo.PrecoUnitario;
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteArtigo(int id)
        {
            using (var db = new CasaPoupancaDB())
            {
                var artigo = db.Artigos.Find(id);
                if (artigo == null)
                    return false;

                db.Artigos.Remove(artigo);
                db.SaveChanges();
                return true;
            }
        }

        // ==================== TIPOS (CRUD) ====================

        public bool TipoExiste(string nome, int? ignorarId = null)
        {
            using (var db = new CasaPoupancaDB())
            {
                return db.TiposArtigo.Any(t => t.Nome == nome && (!ignorarId.HasValue || t.Id != ignorarId.Value));
            }
        }

        public bool AddTipo(TipoArtigo tipo)
        {
            using (var db = new CasaPoupancaDB())
            {
                if (TipoExiste(tipo.Nome))
                    return false;

                db.TiposArtigo.Add(tipo);
                db.SaveChanges();
                return true;
            }
        }

        public bool UpdateTipo(TipoArtigo tipo)
        {
            using (var db = new CasaPoupancaDB())
            {
                var existing = db.TiposArtigo.Find(tipo.Id);
                if (existing == null)
                    return false;

                if (TipoExiste(tipo.Nome, tipo.Id))
                    return false;

                existing.Nome = tipo.Nome;
                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteTipo(int id)
        {
            using (var db = new CasaPoupancaDB())
            {
                var tipo = db.TiposArtigo.Find(id);
                if (tipo == null)
                    return false;

                db.TiposArtigo.Remove(tipo);
                db.SaveChanges();
                return true;
            }
        }
    }
}