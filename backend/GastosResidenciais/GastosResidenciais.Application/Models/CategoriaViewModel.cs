using GastosResidenciais.Domain.Entities;

namespace GastosResidenciais.Application.Models
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public EnumViewModel Finalidade { get; set; } = null!;

        public static CategoriaViewModel FromEntity(Categoria entity)
        {
            return new CategoriaViewModel
            {
                Id = entity.Id,
                Descricao = entity.Descricao,
                Finalidade = new EnumViewModel()
                {
                    Id = (int)entity.Finalidade,
                    Descricao = entity.Finalidade.ToString()
                }
            };
        }
    }
}
