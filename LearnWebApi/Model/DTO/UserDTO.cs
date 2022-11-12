using System.ComponentModel.DataAnnotations;

namespace LearnWebApi.Model.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; } = 18;
    }
}
