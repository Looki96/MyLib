using System.ComponentModel.DataAnnotations;

namespace MyLib.DataModels.Models.Dtos
{
    public class LoginDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
