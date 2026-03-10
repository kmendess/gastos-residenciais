namespace GastosResidenciais.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime? EditadoEm { get; private set; }
    }
}
