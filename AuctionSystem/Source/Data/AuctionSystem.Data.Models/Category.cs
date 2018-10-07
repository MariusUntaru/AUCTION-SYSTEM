namespace AuctionSystem.Data.Models
{
    using System.Collections.Generic;

    public class Category
    {
        private ICollection<Item> items;

        public Category()
        {
            this.items = new HashSet<Item>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Item> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
    }
}