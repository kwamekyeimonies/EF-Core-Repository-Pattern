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


    }
}