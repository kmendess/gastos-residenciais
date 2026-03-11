using GastosResidenciais.Domain.Entities;

namespace GastosResidenciais.Domain.Repositories
{
    public interface ITransacaoRepository
    {
        List<Transacao> GetAll();
        Transacao? GetById(int id);
        Transacao Create(Transacao transacao);
        void Update(Transacao transacao);
        void Delete(Transacao transacao);
    }
}
