using LearnWebApi.Model.DTO;
using LearnWebApi.Model.DTO.Validator;
using LearnWebApi.Model.Mapper;
using LearnWebApi.Model.Native;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MedicineDbContext _context;

        public UserController(MedicineDbContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody]UserDTO dto)
        {
            try
            {
                var validator = new UserValidator(dto);

                if (!validator.Validate())
                {
                    return BadRequest(validator.Message);
                }

                var user = _context.Users.Where(u => u.UserId == id).First();
                user.Name = dto.Name;
                user.Email = dto.Email;
                user.Age = dto.Age;

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody]UserDTO dto)
        {
            var users = _context.Users.Where(u => u.Email == dto.Email).ToArray();

            if (users == null)
            {
                return BadRequest();
            }

            _context.Users.RemoveRange(users);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = _context.Users.Where(u => u.UserId == id).First();

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
         
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]UserDTO dto)
        {
            var validator = new UserValidator(dto);

            if (!validator.Validate())
            {
                return BadRequest(validator.Message);
            }

            var mapper = new UserMapper();
            var user = mapper.Unmap(dto);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            try
            {
                var mapper = new UserMapper();
                var user = _context.Users.Where(u => u.UserId == id)
                                         .Select(u => mapper.Map(u)).First();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult Get()
        {
            var mapper = new UserMapper();

            var users = _context.Users.Select(u => mapper.Map(u));

            return Ok(users);
        }
    }
}
