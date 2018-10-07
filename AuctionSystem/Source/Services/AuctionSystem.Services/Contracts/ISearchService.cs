namespace AuctionSystem.Services.Contracts
{
    using System.Linq;

    using AuctionSystem.Data.Models;

    public interface ISearchService
    {
        IQueryable<Item> GetItemByName(string name);
    }
}