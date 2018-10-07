namespace AuctionSystem.Data.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        private ICollection<Bid> bids;

        // items for sale
        private ICollection<Item> items;

        public User()
        {
            this.bids = new HashSet<Bid>();
            this.items = new HashSet<Item>();

        }

        // [MaxLength(25)]
        // public string FirstName { get; set; }

        // [MaxLength(25)]
        // public string LastName { get; set; }
        public double Coins { get; set; }


        public virtual ICollection<Bid> Bids
        {
            get { return this.bids; }
            set { this.bids = value; }
        }

        public virtual ICollection<Item> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }

}
