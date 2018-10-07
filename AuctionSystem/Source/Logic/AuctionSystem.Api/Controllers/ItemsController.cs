namespace AuctionSystem.Api.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Web.Http;

    using AuctionSystem.Api.Models.Item;
    using AuctionSystem.Common.Constants;
    using AuctionSystem.Services.Contracts;

    using AutoMapper.QueryableExtensions;

    public class ItemsController : ApiController
    {
        private readonly IItemsService items;

        public ItemsController(IItemsService itemsService)
        {
            this.items = itemsService;
        }

        // [EnableCors("*", "*", "*")]

        // GET api/items
        public IHttpActionResult Get()
        {
            // Mapper.CreateMap<Item, ItemsDetailResponseModel>();
            var result = this.items
                .All()
                .ProjectTo<ItemsDetailResponseModel>()
                .ToList();

            return this.Ok(result);
        }


        public IHttpActionResult Get(int id)
        {
            var result = this.items
                .All()
                .ProjectTo<ItemsDetailResponseModel>()
                .FirstOrDefault(i => i.Id == id);

            return this.Ok(result);
        }

        // GET api/items?page=x?pageSize=y
        [Route("api/items/all")]
        // ReSharper disable once StyleCop.SA1404
        [SuppressMessage("ReSharper", "MethodOverloadWithOptionalParameter")]
        public IHttpActionResult Get(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            var result = this.items
                .All(page, pageSize)
                .ProjectTo<ItemsDetailResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return this.BadRequest("Item name cannot be empty");
            }

            var result = this.items
                .All()
                .ProjectTo<ItemsDetailResponseModel>()
                .FirstOrDefault(i => i.Name == name);

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [Route("api/categories/{id}")]
        public IHttpActionResult GetItemsByCategoryId(int id)
        {
            var result = this.items
                .All()
                .Where(i => i.CategoryId == id)
                .ProjectTo<ItemsDetailResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        // POST api/items
        [Authorize]
        public IHttpActionResult Post(SaveItemRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var createdItemId = this.items.Add(
                model.Name,
                model.Description,
                model.InitialPrice,
                this.User.Identity.Name,
                model.ImageUrl,
                model.EndDate,
                model.CategoryId);

            return this.Ok(createdItemId);
        }

        // [Authorize]
        // public IHttpActionResult Delete(int id)
        // {
        // var item = this.items;
        // }
    }
}