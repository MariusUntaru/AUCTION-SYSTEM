namespace AuctionSystem.Services.Contracts
{
    using System.Linq;

    using AuctionSystem.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> All();
        IQueryable<Item> GetItems(string categoryName);

        int Add(string name);
    }
}