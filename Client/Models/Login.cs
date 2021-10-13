using System;
namespace Client.Models
{
    public class Login
    {

        [Required(ErrorMessage = "Username is required")] // make the field required
        [Display(Name = "username")]  // Set the display name of the field
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "password")]
        public string password { get; set; }
    }
}
