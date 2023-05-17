using Microsoft.AspNetCore.Mvc;
using Formula.App.Models;

namespace Formula.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {

        private readonly List<Driver> _drivers = new List<Driver>(){
            new Driver()
            {
                Id = Guid.NewGuid(),
                Name = "Daniel Tenkorang",
                Team = "Mercedes AMG F1",
                DriverNumber = Guid.NewGuid()
            },
            new Driver()
            {
                Id = Guid.NewGuid(),
                Name = "Faustina Adobea",
                Team = "Mercedes AMG F1",
                DriverNumber = Guid.NewGuid()
            },
            new Driver()
            {
                Id = Guid.NewGuid(),
                Name = "Akyaa Agnes",
                Team = "Mercedes AMG F1",
                DriverNumber = Guid.NewGuid()
            },

        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_drivers);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(Guid id)
        {
            return Ok(_drivers.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult AddDriver(Driver driver)
        {
            _drivers.Add(driver);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(Guid id)
        {
            var driver = _drivers.FirstOrDefault(dv => dv.Id.Equals(id));

            if (driver == null)
            {
                return NotFound();
            }

            _drivers.Remove(driver);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateDriver(Driver driver)
        {
            var existingDriver = _drivers.FirstOrDefault(x => x.Id == driver.Id);

            if (existingDriver == null)
            {
                return NotFound();
            }

            existingDriver.Name = driver.Name;
            existingDriver.Team = driver.Team;
            existingDriver.DriverNumber = driver.DriverNumber;

            return NoContent();
        }


    }
}