namespace AuctionSystem.Api.Controllers
{
    using System.Web.Http;

    using AuctionSystem.Api.Models.Bid;
    using AuctionSystem.Services.Contracts;

    using Microsoft.AspNet.Identity;

    public class BidsController : ApiController
    {
        private readonly IBidsService bids;

        public BidsController(IBidsService bidsService)
        {
            this.bids = bidsService;
        }

        // Make a bid on item
        [Authorize]
        public IHttpActionResult Post(BidRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            
            var price = this.bids.GetItemById(model.ItemId).CurrentPrice;
            if (model.Price < price)
            {
                return this.BadRequest("The price you are offering is too low.");
            }

            var bid = this.bids.MakeABid(
                model.BidderId = this.User.Identity.GetUserId(),
                model.ItemId,
                model.Price);

            return this.Ok(bid);
        }
    }
}
