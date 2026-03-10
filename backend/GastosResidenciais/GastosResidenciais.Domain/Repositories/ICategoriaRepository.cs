using GastosResidenciais.Domain.Entities;
using GastosResidenciais.Domain.Enums;

namespace GastosResidenciais.Domain.Repositories
{
    public interface ICategoriaRepository
    {
        List<Categoria> GetAll();
        Categoria? GetById(int id);
        Categoria Create(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(Categoria categoria);
        List<Categoria> GetByFinalidades(List<FinalidadeCategoria> finalidades);
    }
}
