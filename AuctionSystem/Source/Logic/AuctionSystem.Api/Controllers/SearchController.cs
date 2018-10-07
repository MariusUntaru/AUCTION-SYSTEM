namespace AuctionSystem.Api.Controllers
{
    using System.Web.Http;

    using AuctionSystem.Services.Contracts;

    public class SearchController : ApiController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public IHttpActionResult Get(string name)
        {
            var items = this.searchService
                .GetItemByName(name);

            if (items == null)
            {
                return this.BadRequest("Could not find item with this name");
            }

            return this.Ok(items);
        }
    }
}