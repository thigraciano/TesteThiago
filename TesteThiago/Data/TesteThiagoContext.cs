using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteThiago.Models;

namespace TesteThiago.Data
{
    public class TesteThiagoContext : DbContext
    {

        public TesteThiagoContext (DbContextOptions<TesteThiagoContext> options)
            : base(options)
        {
        }

        public DbSet<TesteThiago.Models.Produto> Produto { get; set; } = default!;
        public DbSet<TipoUnidade> TipoUnidade { get; set; }

    }
}
