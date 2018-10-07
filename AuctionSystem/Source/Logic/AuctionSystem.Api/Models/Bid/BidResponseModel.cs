namespace AuctionSystem.Api.Models.Bid
{
    using AuctionSystem.Api.Infrastructure.Mappings;

    public class BidResponseModel : IMapFrom<Data.Models.Bid>
    {
        public int Id { get; set; }
        
        public int ItemId { get; set; }


        public decimal Amount { get; set; }

        public decimal MinBid { get; set; }
        
    }
}