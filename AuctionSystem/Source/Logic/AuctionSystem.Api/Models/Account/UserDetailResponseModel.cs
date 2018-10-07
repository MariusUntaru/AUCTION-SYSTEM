namespace AuctionSystem.Api.Models.Account
{

    using AuctionSystem.Api.Infrastructure.Mappings;
    using AuctionSystem.Data.Models;

    public class UserDetailResponseModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}