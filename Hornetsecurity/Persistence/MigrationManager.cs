using Hornetsecurity.Utils;
using Microsoft.EntityFrameworkCore;
using System.IO;


namespace Hornetsecurity.Persistence
{
    internal static class MigrationManager
    {

        public static void ApplyMigrations()
        {
            FileUtils.CreateFile("hashfiles.db");



            var dbContext = new AppDbContext();

            var migrationList = dbContext.Database.GetMigrations();
            var migrationApplayed = dbContext.Database.GetAppliedMigrations();
            var migrationPending = dbContext.Database.GetPendingMigrations();

            Console.WriteLine($"Migration DB; TotalMigrationFile:{migrationList.Count()} - TotalMigrationApplayed:{migrationApplayed.Count()} - TotalMigrationPending:{migrationPending.Count()}", 1);

            // Here is the migration executed
            dbContext.Database.Migrate();

        }
    }
}
