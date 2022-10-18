using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Modesl
{
    public class SignInModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
}
