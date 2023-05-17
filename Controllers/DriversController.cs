using Microsoft.AspNetCore.Mvc;
using Formula.App.Database;
using Microsoft.EntityFrameworkCore;
using Formula.App.Models;

namespace Formula.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DriversController : ControllerBase
    {

        private readonly ApiDbContext _context;
        public DriversController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDriverByAsync()
        {
            return Ok(await _context.Drivers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverByIdAsync(Guid id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriverByAsync(Driver driver)
        {
            driver.Id = Guid.NewGuid();
            driver.DriverNumber = Guid.NewGuid();
            _context.Drivers.Add(driver);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDriverByAsync(Guid id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(dx => dx.Id.Equals(id));
            if (driver == null)
            {
                return NotFound();
            }

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDriverByAsync(Driver driver)
        {
            var existingDriver = await _context.Drivers.FirstOrDefaultAsync(dx => dx.Id.Equals(driver.Id));
            if (existingDriver == null)
            {
                return NotFound();
            }

            existingDriver.Name = driver.Name;
            existingDriver.Team = driver.Team;
            existingDriver.DriverNumber = driver.DriverNumber;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}