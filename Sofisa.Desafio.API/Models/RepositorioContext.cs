using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Sofisa.Desafio.API.Models
{
    public class RepositorioContext : DbContext
    {
        public RepositorioContext(DbContextOptions<RepositorioContext> options) : base(options) { }

        public DbSet<Repositorio> Repositorios { get; set; }
    }
}