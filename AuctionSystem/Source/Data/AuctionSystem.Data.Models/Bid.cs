namespace AuctionSystem.Data.Models
{
    public class Bid
    {
        public int Id { get; set; }

        public virtual User User { get; set; }

        public string UserId { get; set; }

        public virtual Item Item { get; set; }

        public int ItemId { get; set; }

        public decimal Amount { get; set; }

        public decimal MinBid { get; set; }

    }
}
