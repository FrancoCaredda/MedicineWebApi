using LearnWebApi.Model.Native;
using LearnWebApi.Model.DTO;

namespace LearnWebApi.Model.Mapper
{
    public class UserMapper : IMapper<User, UserDTO>
    {
        public UserDTO Map(User data)
        {
            return new UserDTO()
            {
                Name = data.Name,
                Email = data.Email,
                Age = data.Age
            };
        }

        public User Unmap(UserDTO data)
        {
            return new User()
            {
                Name = data.Name,
                Email = data.Email,
                Age = data.Age
            };
        }
    }
}
