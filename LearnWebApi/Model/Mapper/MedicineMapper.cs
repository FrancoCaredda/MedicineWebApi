using LearnWebApi.Model.Native;
using LearnWebApi.Model.DTO;

namespace LearnWebApi.Model.Mapper
{
    public class MedicineMapper : IMapper<Medicine, MedicineDTO>
    {
        public MedicineDTO Map(Medicine data)
        {
            return new MedicineDTO()
            {
                Name = data.Name,
                Price = data.Price,
                Type = data.Type
            };
        }

        public Medicine Unmap(MedicineDTO data)
        {
            return new Medicine()
            {
                Name = data.Name,
                Price = data.Price,
                Type = data.Type
            };
        }
    }
}
