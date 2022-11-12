using System.ComponentModel.DataAnnotations;

namespace LearnWebApi.Model.Native
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MedicineId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
