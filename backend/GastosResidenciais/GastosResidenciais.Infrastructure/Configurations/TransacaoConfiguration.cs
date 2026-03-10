using GastosResidenciais.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GastosResidenciais.Infrastructure.Configurations
{
    public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("transacao");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.PessoaId)
                .HasColumnName("pessoa_id")
                .IsRequired();

            builder.Property(p => p.CategoriaId)
                .HasColumnName("categoria_id")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(p => p.Valor)
                .HasColumnName("valor")
                .IsRequired();

            builder.Property(p => p.Tipo)
                .HasColumnName("tipo")
                .IsRequired();

            builder.HasOne(p => p.Pessoa)
                .WithMany(p => p.Transacoes)
                .HasForeignKey(p => p.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.CategoriaId);

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
