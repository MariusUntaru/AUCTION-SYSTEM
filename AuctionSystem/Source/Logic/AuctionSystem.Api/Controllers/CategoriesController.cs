namespace AuctionSystem.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using AuctionSystem.Api.Models.Category;
    using AuctionSystem.Services.Contracts;

    using AutoMapper.QueryableExtensions;

    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categories = categoriesService;
        }

        public IHttpActionResult Get()
        {
            var result = this.categories
                .All()
                .ProjectTo<CategoryResponseModel>()
                .ToList();

            return this.Ok(result);
        }

        public IHttpActionResult Post(CategoryRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var category = this.categories.Add(model.Name);

            return this.Ok(category);
        }
    }
}
