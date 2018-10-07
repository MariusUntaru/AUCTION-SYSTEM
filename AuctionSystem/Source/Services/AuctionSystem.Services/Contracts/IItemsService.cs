namespace AuctionSystem.Services.Contracts
{
    using System.Linq;

    using AuctionSystem.Common.Constants;
    using AuctionSystem.Data.Models;

    public interface IItemsService
    {
        IQueryable<Item> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize);

        // Name = model.Name,
        // Category = model.Category,
        // Description = model.Description,
        // InitialPrice = model.InitialPrice,
        // Seller = currentUser,
        int Add(string name, string description, decimal initialPrice, string seller, string imageUrl, string endDate, int categoryId);
   }
}