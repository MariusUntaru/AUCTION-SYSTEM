using System.ComponentModel.DataAnnotations;

namespace AuctionSystem.Api.Models.Account
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}