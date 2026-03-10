using GastosResidenciais.Domain.Entities;
using GastosResidenciais.Domain.Enums;
using GastosResidenciais.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GastosResidenciais.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Categoria> GetAll()
        {
            var categorias = _context.Categorias
                .AsNoTracking()
                .ToList();

            return categorias;
        }

        public Categoria? GetById(int id)
        {
            var categoria = _context.Categorias
                .SingleOrDefault(p => p.Id == id);

            return categoria;
        }

        public Categoria Create(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();

            return categoria;
        }

        public void Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public void Delete(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
        }

        public List<Categoria> GetByFinalidades(List<FinalidadeCategoria> finalidades)
        {
            return _context.Categorias
                .AsNoTracking()
                .Where(c => finalidades.Contains(c.Finalidade))
                .ToList();
        }
    }
}
