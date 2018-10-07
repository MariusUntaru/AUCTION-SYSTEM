namespace AuctionSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AuctionSystem.Common.Constants;

    public class Item
    {
        private ICollection<Bid> bids;
        private ICollection<Category> categories;
        private decimal currentPrice;
        private string buyerId;
        private int categoryId;

        public Item()
        {
            this.bids = new HashSet<Bid>();
            this.categories = new HashSet<Category>();
            this.StartDate = DateTime.Now.ToString(Formatters.SqlFormattedDate);
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxItemName)]
        public string Name { get; set; }

        [MaxLength(ValidationConstants.MaxItemDescription)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal InitialPrice { get; set; }

        public decimal CurrentPrice
        {
            get
            {
                var lastBid = this.bids
                    .Select(b => b.Amount)
                    .LastOrDefault();

                return lastBid + GlobalConstants.MinimumBidIncrease;
            }

            set
            {
                this.currentPrice = value;
                this.currentPrice = this.bids.Select(b => b.Amount).LastOrDefault() + 10;
            }
        }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public bool Expired { get; set; }



        public virtual User Seller { get; set; }

        [Required]
        public string SellerId { get; set; }


        public virtual User Buyer { get; set; }

        public string BuyerId
        {
            get
            {
                return this.bids
                    .Select(b => b.UserId)
                    .LastOrDefault();
            }

            set
            {
                this.buyerId = value;
            }
        }

        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }


        //public int? CategoryId
        //{
        //    get
        //    {
        //        return this.categories
        //            .Select(c => c.Id)
        //            .FirstOrDefault();
        //    }

        //    set
        //    {
        //        this.categoryId = (int)value;
        //    }
        //}

        [Required]
        public virtual ICollection<Bid> Bids
        {
            get { return this.bids; }
            set { this.bids = value; }
        }

    }
}
