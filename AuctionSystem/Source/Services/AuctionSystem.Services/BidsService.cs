using System;

namespace AuctionSystem.Services
{
    using System.Linq;

    using AuctionSystem.Common.Constants;
    using AuctionSystem.Data;
    using AuctionSystem.Data.Models;
    using AuctionSystem.Services.Contracts;

    public class BidsService : IBidsService
    {
        private readonly IRepository<Item> items;
        private readonly IRepository<User> users;
        private readonly IRepository<Bid> bids;

        public BidsService(IRepository<Item> itemsRepo, IRepository<User> usersRepo, IRepository<Bid> bidsRepo)
        {
            this.items = itemsRepo;
            this.users = usersRepo;
            this.bids = bidsRepo;
        }

        public int MakeABid(string bidderId, int itemId, int price)
        {
            // var currentUser = this.users
            // .All()
            // .FirstOrDefault(u => u.UserName == name);

            // this.items.GetById(itemId).CurrentPrice = price;
            // this.items.GetById(itemId).Buyer = users.GetById(bidderId);
            // this.items.GetById(itemId).BuyerId = bidderId;
            // this.items.SaveChanges();

            // Returns -1 and drops the operation if the user does not have enough money.
            var currentUser = this.users.GetById(bidderId);
            if (currentUser.Coins < price)
            {
                return -1;
            }
            
            var newBid = new Bid
            {
                Amount = price,
                MinBid = price + GlobalConstants.MinimumBidIncrease,
                Item = this.items.GetById(itemId),
                ItemId = itemId,
                User = this.users.GetById(bidderId),
                UserId = bidderId,
            };

            // this.items.GetById(itemId).Bids.Add(newBid);
            // this.items.SaveChanges();
            this.bids.Add(newBid);
            this.bids.SaveChanges();

            // var seller = this.users
            //    .All()
            //    .Where();

            var sellerId = this.items
                .All()
                .FirstOrDefault(i => i.Id == itemId)?.SellerId;

            var seller = this.users.GetById(sellerId);

            currentUser.Coins -= price;
            seller.Coins += price;

            this.users.SaveChanges();

            return newBid.Id;
        }

        public bool AuctionExpired(int itemId)
        {
            throw new NotImplementedException();

        }

        public Item GetItemById(int id)
        {
            return this.items.GetById(id);
        }
    }
}