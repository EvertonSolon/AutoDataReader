using AutoDataReader.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutoDataReader.Context
{
    /// <summary>
    /// Source: https://docs.microsoft.com/en-US/ef/core/miscellaneous/cli/dbcontext-creation
    /// </summary>
    public class AutoDataReaderContextFactory : IDesignTimeDbContextFactory<AutoDataReaderContext>
    {
        public AutoDataReaderContext CreateDbContext(string[] args)
        {
            //var dbPathFile = DbPathFile.GetLocation();

            var optionsBuilder = new DbContextOptionsBuilder<AutoDataReaderContext>();
            optionsBuilder.UseSqlite("Data Source=Context\\DataBase.db");
            
            //optionsBuilder.UseSqlite($"Data Source = {dbPathFile}"); <-- It doesn't work.

            var context = new AutoDataReaderContext(optionsBuilder.Options);

            return context;
        }
    }
}