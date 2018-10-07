namespace AuctionSystem.Services.Contracts
{
    using AuctionSystem.Data.Models;

    public interface IBidsService
    {
        int MakeABid(string bidderId, int itemId, int price);

        bool AuctionExpired(int itemId);

        Item GetItemById(int id);
    }
}