namespace AuctionSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AuctionSystem.Api.Models.Account;
    using AuctionSystem.Api.Models.Bid;
    using AuctionSystem.Api.Models.Item;
    using AuctionSystem.Services.Contracts;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    [RoutePrefix("api/account")]
    public class UserController : ApiController
    {
        private readonly IUserService user;

        public UserController(IUserService userService)
        {
            this.user = userService;
        }

        [Authorize]
        [Route("bids")]
        public IHttpActionResult GetBids()
        {
            var result = this.user
                .GetAllBids(this.User.Identity.GetUserId())
                .ProjectTo<BidResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Authorize]
        [Route("items")]
        public IHttpActionResult GetItemsForSale()
        {
            var result = this.user
                .GetAllItems(this.User.Identity.GetUserId())
                .ProjectTo<ItemsDetailResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        [Route("top")]
        public IHttpActionResult GetTopSellers()
        {
            var result = this.user
                .AllUsers()
                .ProjectTo<UserDetailResponseModel>()
                .ToList();

            return this.Ok(result);
        }
    }
}