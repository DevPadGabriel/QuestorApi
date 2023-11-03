using DominioApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace InfraApi.Contexto
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {
        }

        public DbSet<Banco> Banco { get; set; }
        public DbSet<Boleto> Boleto { get; set; }
    }
}
