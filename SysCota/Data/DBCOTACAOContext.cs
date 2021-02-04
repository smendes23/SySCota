using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysCota.Models;

namespace SysCota.Data
{
    public class DBCOTACAOContext : DbContext
    {
        public DBCOTACAOContext(DbContextOptions<DBCOTACAOContext> options)
           : base(options)
        {
            Database.SetCommandTimeout(120);
        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
    }
}
