namespace AuctionSystem.Api.Models.Bid
{
    public class BidRequestModel
    {
        public string BidderName { get; set; }

        public string BidderId { get; set; }

        public int ItemId { get; set; }

        public int Price { get; set; }
    }
}