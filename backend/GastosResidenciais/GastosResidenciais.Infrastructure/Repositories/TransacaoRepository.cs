using GastosResidenciais.Domain.Entities;
using GastosResidenciais.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GastosResidenciais.Infrastructure.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly AppDbContext _context;

        public TransacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Transacao> GetAll()
        {
            var transacoes = _context.Transacoes
                .AsNoTracking()
                .Include(p => p.Pessoa)
                .Include(p => p.Categoria)
                .ToList();

            return transacoes;
        }

        public Transacao? GetById(int id)
        {
            var transacoes = _context.Transacoes
                .Include(p => p.Pessoa)
                .Include(p => p.Categoria)
                .SingleOrDefault(p => p.Id == id);

            return transacoes;
        }

        public Transacao Create(Transacao transacao)
        {
            _context.Add(transacao);
            _context.SaveChanges();

            return transacao;
        }

        public void Update(Transacao transacao)
        {
            _context.Transacoes.Update(transacao);
            _context.SaveChanges();
        }

        public void Delete(Transacao transacao)
        {
            _context.Transacoes.Remove(transacao);
            _context.SaveChanges();
        }
    }
}
