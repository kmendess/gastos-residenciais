using GastosResidenciais.Application.Models;

namespace GastosResidenciais.Application.Interfaces
{
    public interface ICategoriaService
    {
        ResultViewModel<List<CategoriaViewModel>> GetAll();
        ResultViewModel<CategoriaViewModel?> GetById(int id);
        ResultViewModel<CategoriaViewModel> Create(CategoriaCreateViewModel model);
        ResultViewModel Update(int id, CategoriaUpdateViewModel model);
        ResultViewModel Delete(int id);
        ResultViewModel<List<EnumViewModel>> GetFinalidades();
        ResultViewModel<List<CategoriaViewModel>> GetByFinalidade(int finalidade);
    }
}
