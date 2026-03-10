using GastosResidenciais.Application.Models;

namespace GastosResidenciais.Application.Interfaces
{
    public interface IPessoaService
    {
        ResultViewModel<List<PessoaViewModel>> GetAll();
        ResultViewModel<PessoaViewModel?> GetById(int id);
        ResultViewModel<PessoaViewModel> Create(PessoaCreateViewModel model);
        ResultViewModel Update(int id, PessoaUpdateViewModel model);
        ResultViewModel Delete(int id);
    }
}
