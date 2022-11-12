using System.ComponentModel.DataAnnotations;

namespace LearnWebApi.Model.Native
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; } = 18;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
