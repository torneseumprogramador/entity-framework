using System.Reflection.Metadata.Ecma335;
using System;
using entity_framework.Models;
using Microsoft.EntityFrameworkCore;
using src.Models;

namespace entity_framework.Servicos.Database
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }
        
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidosProdutos { get; set; }
        public DbSet<PedidoItem> PedidoItens {get;set;}
    }
}