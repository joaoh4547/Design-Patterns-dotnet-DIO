using Frotas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frotas.Infra.EF
{
    public class FrotaContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }
        public FrotaContext(DbContextOptions<FrotaContext> options) : base(options) { }
    }
}
