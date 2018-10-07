namespace AuctionSystem.Api.Models.Category
{
    using AuctionSystem.Api.Infrastructure.Mappings;
    using AuctionSystem.Data.Models;

    public class CategoryResponseModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}