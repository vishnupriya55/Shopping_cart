using System.ComponentModel.DataAnnotations;

namespace Shopping_cart.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}