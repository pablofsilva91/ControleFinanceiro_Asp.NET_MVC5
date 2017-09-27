using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Financas.DAO
{
    public class FinancasContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Movimentacao> Movimentacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Movimentacao>().HasRequired(m => m.Usuario);
        }
    }
}