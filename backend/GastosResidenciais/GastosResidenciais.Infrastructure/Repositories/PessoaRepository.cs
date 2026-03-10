using GastosResidenciais.Domain.Entities;
using GastosResidenciais.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GastosResidenciais.Infrastructure.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _context;
        
        public PessoaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Pessoa> GetAll()
        {
            var pessoas = _context.Pessoas
                .AsNoTracking()
                .Include(p => p.Transacoes)
                .ToList();

            return pessoas;
        }

        public Pessoa? GetById(int id)
        {
            var pessoa = _context.Pessoas
                .Include(p => p.Transacoes)
                .SingleOrDefault(p => p.Id == id);

            return pessoa;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();

            return pessoa;
        }

        public void Update(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
        }

        public void Delete(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
        }
    }
}
