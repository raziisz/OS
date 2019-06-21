using Microsoft.EntityFrameworkCore;
using OrdemServico.API.Modelos;
namespace OrdemServico.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}