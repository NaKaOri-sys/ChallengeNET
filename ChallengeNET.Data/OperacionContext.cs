using ChallengeNET.DataAccess.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ChallengeNET.DataAccess
{
    public class OperacionContext : DbContext
    {
        public OperacionContext(DbContextOptions<OperacionContext> options) : base(options)
        {

        }

        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
        public DbSet<Retiro> Retiros { get; set; }
        public DbSet<Balance> Balances { get; set; }

    }
}