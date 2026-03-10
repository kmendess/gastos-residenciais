using GastosResidenciais.Domain.Entities;
using GastosResidenciais.Domain.Enums;

namespace GastosResidenciais.Application.Models
{
    public class CategoriaCreateViewModel
    {
        public string Descricao { get; set; } = string.Empty;
        public int Finalidade { get; set; }

        public Categoria ToEntity()
        {
            return new Categoria
            {
                Descricao = Descricao,
                Finalidade = (FinalidadeCategoria)Finalidade
            };
        }
    }
}
