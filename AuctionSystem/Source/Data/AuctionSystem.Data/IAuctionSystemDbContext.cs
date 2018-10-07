namespace AuctionSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using AuctionSystem.Data.Models;

    public interface IAuctionSystemDbContext
    {
        IDbSet<Item> Items { get; set; }

        IDbSet<Bid> Bids { get; set; }

        // IDbSet<AuctionSale> AuctionSales { get; set; }
        IDbSet<Category> Categories { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
