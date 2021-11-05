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
                optionsBuilder.UseMySql("server=localhost;database=EntityFrameworkComunidade;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidosDbContexto).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
