namespace AuctionSystem.Services
{
    using System.Linq;

    using AuctionSystem.Data;
    using AuctionSystem.Data.Models;
    using AuctionSystem.Services.Contracts;

    public class SearchService : ISearchService
    {
        private readonly IRepository<Item> items;

        public SearchService(IRepository<Item> itemsRepo)
        {
            this.items = itemsRepo;
        }

        public IQueryable<Item> GetItemByName(string name)
        {
            return this.items
                .All()
                .Where(i => i.Name == name);
        }
    }
}