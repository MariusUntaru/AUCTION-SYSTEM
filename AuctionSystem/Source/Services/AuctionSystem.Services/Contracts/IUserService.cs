namespace AuctionSystem.Services.Contracts
{
    using System.Linq;

    using AuctionSystem.Common.Constants;
    using AuctionSystem.Data.Models;

    public interface IUserService
    {
        IQueryable<Bid> GetAllBids(string currentUserId);

        IQueryable<Item> GetAllWonAuctions(string currentUserId);

        IQueryable<Item> GetAllItems(string currentUserId);

        IQueryable<User> AllUsers(int page = 1, int pageSIze = GlobalConstants.DefaultPageSize);
    }
}