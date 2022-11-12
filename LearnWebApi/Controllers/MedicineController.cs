using LearnWebApi.Model.DTO;
using LearnWebApi.Model.DTO.Validator;
using LearnWebApi.Model.Mapper;
using LearnWebApi.Model.Native;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly MedicineDbContext _context;
        
        public MedicineController(MedicineDbContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody]MedicineDTO dto)
        {
            try
            {
                var validator = new MedicineValidator(dto);

                if (!validator.Validate())
                {
                    return BadRequest(validator.Message);
                }

                var medicine = _context.Medicines.Where(m => m.MedicineId == id)
                                                      .First();


                medicine.Name = dto.Name;
                medicine.Price = dto.Price;
                medicine.Type = dto.Type;

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            { 
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MedicineDTO dto)
        {
            var validator = new MedicineValidator(dto);

            if (!validator.Validate())
            {
                return BadRequest(validator.Message);
            }

            var medicineMapper = new MedicineMapper();
            var medicine = medicineMapper.Unmap(dto);

            _context.Medicines.Add(medicine);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var medicine = _context.Medicines.Where(m => m.MedicineId == id).ToArray();

            if (medicine == null)
            {
                return BadRequest();
            }

            _context.Medicines.RemoveRange(medicine);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]MedicineDTO dto)
        {
            var medicine = _context.Medicines.Where(m => m.Name == dto.Name).ToArray();

            if (medicine == null)
            {
                return BadRequest();
            }

            _context.Medicines.RemoveRange(medicine);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var medicine = _context.Medicines.Where(m => m.MedicineId == id).First();
                var mapper = new MedicineMapper();
                var dto = mapper.Map(medicine);

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            MedicineMapper medicineMapper = new MedicineMapper();

            IEnumerable<MedicineDTO> medicines = _context.Medicines
                                                 .Select(m => medicineMapper.Map(m));

            return Ok(new ActionResult<IEnumerable<MedicineDTO>>(medicines));
        }
    }
}
