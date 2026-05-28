using CasaPoupança.database;
using CasaPoupanca.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPoupanca.Controllers
{
    public class ArtigoController : IDisposable
    {
        private readonly CasaPoupancaDB _db;

        public ArtigoController()
        {
            _db = new CasaPoupancaDB();
        }

        // ==================== TIPOS DE ARTIGO ====================

        public List<TipoArtigo> GetAllTipos()
        {
            return _db.TiposArtigo.OrderBy(t => t.Nome).ToList();
        }

        public List<TipoArtigo> GetTiposComTodos()
        {
            var tipos = GetAllTipos();
            tipos.Insert(0, new TipoArtigo { Id = 0, Nome = "Todos" });
            return tipos;
        }

        // ==================== ARTIGOS ====================

        public List<Artigo> GetAllArtigos()
        {
            return _db.Artigos.Include("TipoArtigo").OrderBy(a => a.Nome).ToList();
        }

        public List<Artigo> GetArtigosFiltrados(int? tipoId = null)
        {
            var query = _db.Artigos.Include("TipoArtigo").AsQueryable();

            if (tipoId.HasValue && tipoId > 0)
            {
                query = query.Where(a => a.TipoArtigoId == tipoId);
            }

            return query.OrderBy(a => a.Nome).ToList();
        }

        public Artigo GetArtigoById(int id)
        {
            return _db.Artigos.Find(id);
        }

        public bool ArtigoExiste(string nome, int tipoId, int? ignorarId = null)
        {
            return _db.Artigos.Any(a => a.Nome == nome && a.TipoArtigoId == tipoId && (!ignorarId.HasValue || a.Id != ignorarId.Value));
        }

        public bool AddArtigo(Artigo artigo)
        {
            if (ArtigoExiste(artigo.Nome, artigo.TipoArtigoId))
                return false;

            _db.Artigos.Add(artigo);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateArtigo(Artigo artigo)
        {
            var existing = _db.Artigos.Find(artigo.Id);
            if (existing == null)
                return false;

            if (ArtigoExiste(artigo.Nome, artigo.TipoArtigoId, artigo.Id))
                return false;

            existing.Nome = artigo.Nome;
            existing.TipoArtigoId = artigo.TipoArtigoId;
            _db.SaveChanges();
            return true;
        }

        public bool DeleteArtigo(int id)
        {
            var artigo = _db.Artigos.Find(id);
            if (artigo == null)
                return false;

            _db.Artigos.Remove(artigo);
            _db.SaveChanges();
            return true;
        }

        // ==================== TIPOS (CRUD) ====================

        public bool TipoExiste(string nome, int? ignorarId = null)
        {
            return _db.TiposArtigo.Any(t => t.Nome == nome && (!ignorarId.HasValue || t.Id != ignorarId.Value));
        }

        public bool AddTipo(TipoArtigo tipo)
        {
            if (TipoExiste(tipo.Nome))
                return false;

            _db.TiposArtigo.Add(tipo);
            _db.SaveChanges();
            return true;
        }

        public bool UpdateTipo(TipoArtigo tipo)
        {
            var existing = _db.TiposArtigo.Find(tipo.Id);
            if (existing == null)
                return false;

            if (TipoExiste(tipo.Nome, tipo.Id))
                return false;

            existing.Nome = tipo.Nome;
            _db.SaveChanges();
            return true;
        }

        public bool DeleteTipo(int id)
        {
            var tipo = _db.TiposArtigo.Find(id);
            if (tipo == null)
                return false;

            _db.TiposArtigo.Remove(tipo);
            _db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
