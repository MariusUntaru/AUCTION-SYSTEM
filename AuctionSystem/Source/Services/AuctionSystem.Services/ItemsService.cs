namespace AuctionSystem.Services
{
    using System.Linq;

    using AuctionSystem.Common.Constants;
    using AuctionSystem.Data;
    using AuctionSystem.Data.Models;
    using AuctionSystem.Services.Contracts;

    public class ItemsService : IItemsService
    {
        private readonly IRepository<Item> items;
        private readonly IRepository<User> users;

        public ItemsService(IRepository<Item> itemsRepo, IRepository<User> usersRepo)
        {
            this.items = itemsRepo;
            this.users = usersRepo;
        }

        public IQueryable<Item> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            return this.items
                    .All()
                    .OrderBy(i => i.Name)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
        }

        public int Add(
            string name, 
            string description, 
            decimal initialPrice, 
            string seller, 
            string imageUrl, 
            string endDate, 
            int categoryId)
        {
            var currentUser = this.users
                  .All()
                  .FirstOrDefault(u => u.UserName == seller);

            var newItem = new Item
            {
                Name = name,
                CategoryId = categoryId,
                Description = description,
                InitialPrice = initialPrice,
                Seller = currentUser,
                ImageUrl = imageUrl,
                Expired = false
            };

            this.items.Add(newItem);
            this.items.SaveChanges();

            return newItem.Id;
        }
    }
}