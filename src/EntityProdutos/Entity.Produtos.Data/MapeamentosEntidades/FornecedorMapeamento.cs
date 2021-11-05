using Entity.Produtos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Produtos.Data.MapeamentosEntidades
{
    public class FornecedorMapeamento : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("fornecedores");

            builder.HasKey(f => f.Id)
                .HasName("PK_fornecedores");

            builder.HasIndex(f => f.Id, "IX_forcedores_fornecedorid");

            builder.HasIndex(f => f.EnderecoId, "IX_fornecedores_enderecos_id");

            builder.Property(f => f.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(f => f.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(f => f.DocumentoIdentificacao)
                .HasColumnName("documento_identificacao")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(f => f.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("tinyint(1)")
                .IsRequired();

            builder.Property(f => f.TipoFornecedor)
                .HasColumnName("tipo_fornecedor")
                .HasConversion<int>()
                .IsRequired();

            builder.Property(f => f.EnderecoId)
                .HasColumnName("endereco_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(f => f.Endereco)
                .WithMany(e => e.Fornecedores)
                .HasForeignKey(f => f.EnderecoId)
                .HasConstraintName("FK_fornecedores_enderecos_endereco_id")
                .OnDelete(DeleteBehavior.ClientSetNull);

            
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);
        }
    }
}