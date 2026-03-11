using GastosResidenciais.Application.Models;

namespace GastosResidenciais.Application.Interfaces
{
    public interface ITransacaoService
    {
        ResultViewModel<List<TransacaoViewModel>> GetAll();
        ResultViewModel<TransacaoViewModel?> GetById(int id);
        ResultViewModel<TransacaoViewModel> Create(TransacaoCreateViewModel model);
        ResultViewModel Update(int id, TransacaoUpdateViewModel model);
        ResultViewModel Delete(int id);
        ResultViewModel<List<EnumViewModel>> GetTipos();
    }
}
