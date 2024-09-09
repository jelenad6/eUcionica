using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace eUcionica.DBContext
{
    public class SchoolContextFactory : IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            string databasePath = Path.Combine("..", "eUcionica.db"); 
            optionsBuilder.UseSqlite($"Data Source={databasePath}");

            return new SchoolContext(optionsBuilder.Options);
        }
    }
}
