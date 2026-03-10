using GastosResidenciais.Domain.Entities;

namespace GastosResidenciais.Application.Models
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int Finalidade { get; set; }

        public static CategoriaViewModel FromEntity(Categoria entity)
        {
            return new CategoriaViewModel
            {
                Id = entity.Id,
                Descricao = entity.Descricao,
                Finalidade = (int)entity.Finalidade
            };
        }
    }
}
