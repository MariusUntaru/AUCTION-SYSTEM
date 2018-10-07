namespace AuctionSystem.Services
{
    using System.Linq;

    using AuctionSystem.Data;
    using AuctionSystem.Data.Models;
    using AuctionSystem.Services.Contracts;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categories;
        private readonly IRepository<Item> items;

        public CategoriesService(IRepository<Item> itemsRepo, IRepository<Category> categoriesRepo)
        {
            this.items = itemsRepo;
            this.categories = categoriesRepo;
        }

        public IQueryable<Category> All()
        {
            return this.categories.All();
        }

        public IQueryable<Item> GetItems(string categoryName)
        {
            return this.items
                .All()
                .Where(i => i.Category.Name == categoryName);
        }

        public int Add(string name)
        {
            var newCategory = new Category { Name = name };

            this.categories.Add(newCategory);
            this.categories.SaveChanges();

            return newCategory.Id;
        }
    }
}
