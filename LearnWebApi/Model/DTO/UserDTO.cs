using System.ComponentModel.DataAnnotations;

namespace LearnWebApi.Model.DTO
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; } = 18;
    }
}
