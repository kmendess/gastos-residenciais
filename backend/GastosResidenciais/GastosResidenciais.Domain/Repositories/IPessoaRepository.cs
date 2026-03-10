using GastosResidenciais.Domain.Entities;

namespace GastosResidenciais.Domain.Repositories
{
    public interface IPessoaRepository
    {
        List<Pessoa> GetAll();
        Pessoa? GetById(int id);
        Pessoa Create(Pessoa pessoa);
        void Update(Pessoa pessoa);
        void Delete(Pessoa pessoa);
    }
}
