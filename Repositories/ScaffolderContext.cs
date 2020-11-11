using Scaffolder.Models;
using Microsoft.EntityFrameworkCore;

namespace Scaffolder.Repositories
{
    public class ScaffolderContext : DbContext
    {
        public ScaffolderContext(DbContextOptions<ScaffolderContext> opt) : base(opt)
        {
            
        }

        public DbSet<Scaffold> Scaffold { get; set; }

    }
}