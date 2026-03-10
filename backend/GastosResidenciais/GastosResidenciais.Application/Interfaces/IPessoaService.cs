using GastosResidenciais.Application.Models;

namespace GastosResidenciais.Application.Interfaces
{
    public interface IPessoaService
    {
        ResultViewModel<List<PessoaViewModel>> GetAll();
        ResultViewModel<PessoaViewModel?> GetById(int id);
        ResultViewModel<PessoaViewModel> Create(CreatePessoaViewModel model);
        ResultViewModel Update(int id, UpdatePessoaViewModel model);
        ResultViewModel Delete(int id);
    }
}
