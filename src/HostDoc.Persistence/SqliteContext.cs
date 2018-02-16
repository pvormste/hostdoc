using HostDoc.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace HostDoc.Persistence
{
    public class SqliteContext : DbContext
    {
        // TODO: Configure Context
        public DbSet<DummyModel> DummyModels { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Configure sqlite path here
        }
    }
}
