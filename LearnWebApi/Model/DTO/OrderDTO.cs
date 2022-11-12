namespace LearnWebApi.Model.DTO
{
    public class OrderDTO
    {
        public int UserId { get; set; }
        public int MedicineId { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
