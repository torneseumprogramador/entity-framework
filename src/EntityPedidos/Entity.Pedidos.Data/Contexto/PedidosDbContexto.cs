using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entity.Pedidos.Data;
using Entity.Pedidos.Domain.Entidades;

#nullable disable

namespace Entity.Pedidos.Data.Contexto
{
    public partial class PedidosDbContexto : DbContext
    {
        public PedidosDbContexto()
        {
        }

        public PedidosDbContexto(DbContextOptions<PedidosDbContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoItem> PedidoItems { get; set; }
        public virtual DbSet<CupomDesconto> CupomDescontos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=EntityFrameworkComunidade;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("enderecos", t => t.ExcludeFromMigrations());

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("cidade");

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("complemento");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("estado");

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("logradouro");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("numero");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("pedidos", t => t.ExcludeFromMigrations());

                entity.HasIndex(e => e.ClienteId, "IX_pedidos_cliente_id");

                entity.HasIndex(e => e.EnderecoId, "IX_pedidos_endereco_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.Data)
                    .HasMaxLength(6)
                    .HasColumnName("data");

                entity.Property(e => e.EnderecoId).HasColumnName("endereco_id");

                entity.Property(e => e.ValorTotal).HasColumnName("valor_total");

                entity.HasOne(d => d.Endereco)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.EnderecoId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
