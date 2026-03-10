using GastosResidenciais.Domain.Enums;

namespace GastosResidenciais.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public string Descricao { get; set; } = string.Empty;

        public FinalidadeCategoria Finalidade { get; set; }
    }
}
