using System.Text.RegularExpressions;

namespace LearnWebApi.Model.DTO.Validator
{
    public class UserValidator : IValidator
    {
        private readonly UserDTO _dto;

        public string Message { get; set; }

        private int _minAge = 18;

        public UserValidator(UserDTO dto)
        {
            _dto = dto;
        }

        public bool ValidateEmail()
        {
            Regex regex = new Regex("^(([A-Za-z0-9\\.-_]+)@([a-z]+))\\.([a-z]+)(\\.([a-z]+))?");

            return regex.IsMatch(_dto.Email);
        }

        public bool ValidateName()
        {
            Regex regex = new Regex("^[a-zA-Z]*$");

            return regex.IsMatch(_dto.Name);
        }

        public bool ValidateAge()
        {
            return _dto.Age >= _minAge;
        }

        public bool Validate()
        {
            if (!ValidateEmail())
            {
                Message = "The email's format is wrong!";
                return false;
            }

            if (!ValidateName())
            {
                Message = "The name's format is wrong";
                return false;
            }

            if (!ValidateAge())
            {
                Message = "The age must be from 18";
                return false;
            }

            Message = "No validation error";
            return true;
        }
    }
}
