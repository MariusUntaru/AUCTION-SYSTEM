namespace AuctionSystem.Data
{
    using System.Data.Entity;
    using AuctionSystem.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class AuctionSystemDbContext : IdentityDbContext<User>, IAuctionSystemDbContext
    {
        public AuctionSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuctionSystemDbContext, Configuration>());
        }

        public virtual IDbSet<Item> Items { get; set; }

        public virtual IDbSet<Bid> Bids { get; set; }

        // public virtual IDbSet<AuctionSale> AuctionSales { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }

        // public virtual IDbSet<Buyer> Buyer { get; set; }
        // public virtual IDbSet<Seller> Seller { get; set; }
        public static AuctionSystemDbContext Create()
        {
            return new AuctionSystemDbContext();
        }
    }
}
