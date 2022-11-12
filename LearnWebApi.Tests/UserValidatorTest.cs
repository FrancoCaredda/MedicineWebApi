using LearnWebApi.Model.DTO.Validator;
using LearnWebApi.Model.DTO;


namespace LearnWebApi.Tests
{
    [TestClass]
    public class UserValidatorTest
    {
        [TestMethod]
        public void ValidateEmail_EmailCorrect_ReturnsTrue()
        {
            UserDTO userDTO = new UserDTO()
            {
                Name = "Franco",
                Email = "franco.caredda12345@gmail.com",
                Age = 19
            };

            UserValidator userValidator = new UserValidator(userDTO);

            Assert.IsTrue(userValidator.ValidateEmail());
        }

        [TestMethod]
        public void ValidateEmail_EmailWithoutDoggy_ReturnsFalse()
        {
            UserDTO userDTO = new UserDTO()
            {
                Name = "Franco",
                Email = "franco.caredda12345gmail.com",
                Age = 19
            };

            UserValidator userValidator = new UserValidator(userDTO);

            Assert.IsFalse(userValidator.ValidateEmail());
        }

        [TestMethod]
        public void ValidateEmail_EmailWithoutDotComEtc_ReturnFalse()
        {
            UserDTO userDTO = new UserDTO()
            {
                Name = "Franco",
                Email = "franco.caredda12345@gmail",
                Age = 19
            };

            UserValidator userValidator = new UserValidator(userDTO);

            Assert.IsFalse(userValidator.ValidateEmail());
        }

        [TestMethod]
        public void ValidateEmail_EmailWithDotComAndUa_ReturnsTrue()
        {
            UserDTO userDTO = new UserDTO()
            {
                Name = "Franco",
                Email = "franco.caredda12345@gmail.com.ua",
                Age = 19
            };

            UserValidator userValidator = new UserValidator(userDTO);

            Assert.IsTrue(userValidator.ValidateEmail());
        }

        [TestMethod]
        public void ValidateEmail_EmailGmailWithNumbers_ReturnsFalse()
        {
            UserDTO userDTO = new UserDTO()
            {
                Name = "Franco",
                Email = "franco.caredda12345@gmail1.com.ua",
                Age = 19
            };

            UserValidator userValidator = new UserValidator(userDTO);

            Assert.IsFalse(userValidator.ValidateEmail());
        }

        [TestMethod]
        public void ValidateName_WithoutNumbers_ReturnsTrue()
        {
            UserDTO userDTO = new UserDTO()
            {
                Name = "Franco",
                Email = "franco.caredda12345@gmail.com.ua",
                Age = 19
            };

            UserValidator userValidator = new UserValidator(userDTO);

            Assert.IsTrue(userValidator.ValidateEmail());
        }

        [TestMethod]
        public void ValidateName_WithNumbers_ReturnsFalse()
        {
            UserDTO userDTO = new UserDTO()
            {
                Name = "Franco1",
                Email = "franco.caredda12345@gmail.com.ua",
                Age = 19
            };

            UserValidator userValidator = new UserValidator(userDTO);

            Assert.IsFalse(userValidator.ValidateName());
        }
    }
}
