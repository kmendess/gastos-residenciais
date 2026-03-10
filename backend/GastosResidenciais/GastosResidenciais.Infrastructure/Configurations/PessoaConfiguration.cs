using GastosResidenciais.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GastosResidenciais.Infrastructure.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoa");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Idade)
                .HasColumnName("idade")
                .IsRequired();

            builder.HasMany(p => p.Transacoes)
                .WithOne(p => p.Pessoa)
                .HasForeignKey(p => p.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);

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
