using GastosResidenciais.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GastosResidenciais.Infrastructure.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(p => p.Finalidade)
                .HasColumnName("finalidade")
                .IsRequired();

            builder.Property(p => p.CriadoEm)
                .HasColumnName("criado_em")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(p => p.EditadoEm)
                .HasColumnName("editado_em")
                .HasColumnType("timestamptz");
        }
    }
}
