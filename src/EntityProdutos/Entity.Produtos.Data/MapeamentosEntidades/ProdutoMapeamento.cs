using Entity.Produtos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Produtos.Data.MapeamentosEntidades
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produtos");

            builder.HasKey(p => p.Id)
                .HasName("PK_produtos");

            builder.HasIndex(p => p.Id, "IX_PK_produtos");

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.UrlImagem)
                .HasColumnName("url_imagem")
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Valor)
                .HasColumnName("valor")
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(p => p.CategoriaId)
                .HasColumnName("categoria_id")
                .HasColumnType("int")
                .IsRequired();
            
            builder.Property(p => p.FornecedorId)
                .HasColumnName("fornecedor_id")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId)
                .HasConstraintName("FK_produtos_categorias_categoria_id");

            builder.HasOne(p => p.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(p => p.FornecedorId)
                .HasConstraintName("FK_produtos_fornecedores_fornecedor_id");
        }
    }
}