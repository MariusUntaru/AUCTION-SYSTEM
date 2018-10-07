namespace AuctionSystem.Api.Models.Item
{
    using AuctionSystem.Api.Infrastructure.Mappings;
    using Data.Models;

    public class ItemsDetailResponseModel : IMapFrom<Item>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public decimal CurrentPrice { get; set; }

        public string SellerId { get; set; }

        public string ImageUrl { get; set; }

        public bool Expired { get; set; }

        public string EndDate { get; set; }
    }
}