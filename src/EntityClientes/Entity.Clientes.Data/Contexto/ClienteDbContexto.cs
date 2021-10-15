using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entity.Clientes.Domain.Entidades;
using Entity.Clientes.Data.MapeamentoEntidades;

#nullable disable

namespace Entity.Clientes.Data.Contexto
{
    public partial class ClienteDbContexto : DbContext
    {
        public ClienteDbContexto()
        {
        }

        public ClienteDbContexto(DbContextOptions<ClienteDbContexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }

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

            modelBuilder.ApplyConfiguration<Cliente>(new ClienteMapeamento());

            // modelBuilder.Entity<Cliente>(entity =>
            // {
            //     entity.ToTable("clientes");

            //     entity.HasIndex(e => e.EnderecoId, "IX_clientes_endereco_id");

            //     entity.Property(e => e.Id).HasColumnName("id");

            //     entity.Property(e => e.EnderecoId).HasColumnName("endereco_id");

            //     entity.Property(e => e.Nome)
            //         .IsRequired()
            //         .HasMaxLength(150)
            //         .HasColumnName("nome");

            //     entity.Property(e => e.Observacao)
            //         .IsRequired()
            //         .HasColumnType("text")
            //         .HasColumnName("observacao");

            //     entity.HasOne(d => d.Endereco)
            //         .WithMany(p => p.Clientes)
            //         .HasForeignKey(d => d.EnderecoId);
            // });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("enderecos");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
