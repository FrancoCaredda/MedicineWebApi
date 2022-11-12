using System.Text.RegularExpressions;

namespace LearnWebApi.Model.DTO.Validator
{
    public class MedicineValidator : IValidator
    {
        public string Message { get; set; }

        private MedicineDTO _dto;

        public MedicineValidator(MedicineDTO medicine)
        {
            _dto = medicine;
        }

        private bool ValidateString(string str)
        {
            Regex regex = new Regex("^[a-zA-Z]*$");

            return regex.IsMatch(str) && str.Length != 0;
        }

        public bool Validate()
        {
            if (!ValidateString(_dto.Name))
            {
                Message = "The name's format is wrong";
                return false;
            }

            if (!ValidateString(_dto.Type))
            {
                Message = "The type's format is wrong";
                return false;
            }

            Message = "No validation error";
            return true;
        }
    }
}
