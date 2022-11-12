using LearnWebApi.Model.DTO.Validator;
using LearnWebApi.Model.DTO;

namespace LearnWebApi.Tests
{
    [TestClass]
    public class MedicineValidatorTest
    {
        [TestMethod]
        public void ValidateString_MedicineDTONameWithoutNumbers_ReturnsTrue()
        {
            MedicineDTO _dto = new MedicineDTO()
            {
                Name = "Aspiryn",
                Type = "Toothache",
                Price = 100
            };

            MedicineValidator _validator = new MedicineValidator(_dto);

            Assert.IsTrue(_validator.Validate());
        }

        [TestMethod]
        public void ValidateString_MedicineDTONameWithNumbers_ReturnsFalse()
        {
            MedicineDTO _dto = new MedicineDTO()
            {
                Name = "Aspiryn123",
                Type = "Toothache",
                Price = 100
            };

            MedicineValidator _validator = new MedicineValidator(_dto);

            Assert.IsFalse(_validator.Validate());
        }

        [TestMethod]
        public void ValidateString_MedicineDTONameEmpty_ReturnsFalse()
        {
            MedicineDTO _dto = new MedicineDTO()
            {
                Name = "",
                Type = "Toothache",
                Price = 100
            };

            MedicineValidator _validator = new MedicineValidator(_dto);

            Assert.IsFalse(_validator.Validate());
        }
        
        [TestMethod]
        public void ValidateString_MedicineDTONameStartsWithLowerCase_ReturnsTrue()
        {
            MedicineDTO _dto = new MedicineDTO()
            {
                Name = "aspirin",
                Type = "Toothache",
                Price = 100
            };

            MedicineValidator _validator = new MedicineValidator(_dto);

            Assert.IsTrue(_validator.Validate());
        }
    }
}