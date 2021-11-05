using System.Collections.Generic;
using Entity.Produtos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Produtos.Data.MapeamentosEntidades
{
    public class CategoriaMapeamento : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categorias");

            builder.HasKey(c => c.Id)
                .HasName("PK_categorias");

            builder.HasIndex(c => c.Id, "IX_categorias_id");

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("int");

            builder.Property(c => c.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("varchar(250)")
                .IsRequired();

            //Definação opcional pois categoria não guarda a chave do relacionamento
            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .HasForeignKey(p => p.CategoriaId);

            builder.HasData(new List<Categoria>
            {
                new Categoria 
                {
                    Id = 1,
                    Descricao = "Alimentos"
                },
                new Categoria
                {
                    Id = 2,
                    Descricao = "Bebidas"
                }
            });
        }
    }
}