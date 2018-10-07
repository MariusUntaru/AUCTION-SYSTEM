namespace AuctionSystem.Services
{
    using System;
    using System.Linq;

    using AuctionSystem.Common.Constants;
    using AuctionSystem.Data;
    using AuctionSystem.Data.Models;
    using AuctionSystem.Services.Contracts;

    public class UserService : IUserService
    {
        private readonly IRepository<Bid> bids;
        private readonly IRepository<Item> items;
        private readonly IRepository<User> users;

        public UserService(IRepository<Bid> bidsRepo, IRepository<Item> itemsRepo, IRepository<User> usersRepo)
        {
            this.bids = bidsRepo;
            this.items = itemsRepo;
            this.users = usersRepo;
        }

        public IQueryable<User> AllUsers(int page = 1, int pageSIze = GlobalConstants.DefaultPageSize)
        {
            // TODO change to items sold instead of all listed items
            return this.users
                .All()
                .OrderByDescending(u => u.Items.Count)
                .Skip((page - 1) * pageSIze)
                .Take(pageSIze);
        }

        // get all previous bids
        public IQueryable<Bid> GetAllBids(string currentUserId)
        { 
            return this.bids
                .All()
                .Where(b => b.UserId == currentUserId)
                .OrderBy(b => b.Item.Name);
        }

        public IQueryable<Item> GetAllWonAuctions(string currentUserId)
        {
            throw new NotImplementedException();
        }

        // get all items for sale
        public IQueryable<Item> GetAllItems(string currentUserId)
        {
            return this.items
                .All()
                .Where(i => i.SellerId == currentUserId)
                .OrderBy(i => i.Name);
        }
    }
}
