namespace AuctionSystem.Api.Models.Item
{
    using System.ComponentModel.DataAnnotations;

    using AuctionSystem.Common.Constants;

    public class SaveItemRequestModel
    {

        [Required]
        [MaxLength(ValidationConstants.MaxItemName)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [MaxLength(ValidationConstants.MaxItemDescription)]
        public string Description { get; set; }

        public decimal InitialPrice { get; set; }

        public string ImageUrl { get; set; }
        
        public string EndDate { get; set; }

    }
}