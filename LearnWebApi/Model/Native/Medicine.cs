using System.ComponentModel.DataAnnotations;

namespace LearnWebApi.Model.Native
{
    public class Medicine
    {
        [Key]
        public int MedicineId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Type { get; set; } = "Unknown";

        public virtual ICollection<Order> Orders { get; set; }
    }
}
