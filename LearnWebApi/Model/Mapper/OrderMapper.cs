using LearnWebApi.Model.DTO;
using LearnWebApi.Model.Native;

namespace LearnWebApi.Model.Mapper
{
    public class OrderMapper : IMapper<Order, OrderDTO>
    {
        public OrderDTO Map(Order data)
        {
            return new OrderDTO()
            {
                UserId = data.UserId,
                MedicineId = data.MedicineId,
                Count = data.Count,
                Price = data.Price
            };
        }

        public Order Unmap(OrderDTO data)
        {
            return new Order()
            {
                UserId = data.UserId,
                MedicineId = data.MedicineId,
                Count = data.Count,
                Price = data.Price
            };
        }
    }
}
