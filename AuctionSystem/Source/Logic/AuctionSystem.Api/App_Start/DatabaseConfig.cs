namespace AuctionSystem.Api
{
    using System.Data.Entity;

    using AuctionSystem.Data;
    using AuctionSystem.Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuctionSystemDbContext, Configuration>());

            AuctionSystemDbContext.Create().Database.Initialize(true);
        }
    }
}