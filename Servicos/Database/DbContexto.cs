using System;
using entity_framework.Models;
using Microsoft.EntityFrameworkCore;

namespace entity_framework.Servicos.Database
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }
        
        public DbSet<Endereco> enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidosProdutos { get; set; }
    }
}