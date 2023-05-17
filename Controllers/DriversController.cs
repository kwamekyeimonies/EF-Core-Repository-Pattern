using Microsoft.AspNetCore.Mvc;
using Formula.App.Database;
using Formula.App.Models;
using Formula.App.Core;


namespace Formula.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DriversController : ControllerBase
    {

        private readonly IUnitOfWork _unitofwork;
        public DriversController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetDriverByAsync()
        {
            return Ok(await _unitofwork.Driver.AllByAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverByIdAsync(Guid id)
        {
            var driver = await _unitofwork.Driver.GetByIdAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriverByAsync(Driver driver)
        {
            Driver newdriver = new Driver();
            newdriver.Id = Guid.NewGuid();
            newdriver.DriverNumber = Guid.NewGuid();
            newdriver.Name = driver.Name;
            newdriver.Team = driver.Team;

            await _unitofwork.Driver.AddByAsync(newdriver);
            await _unitofwork.CompleteAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDriverByAsync(Guid id)
        {
            var driver = await _unitofwork.Driver.GetByIdAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            await _unitofwork.Driver.DeleteByAsync(driver);
            await _unitofwork.CompleteAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateDriverByAsync(Driver driver)
        {
            var existingDriver = await _unitofwork.Driver.GetByIdAsync(driver.Id);
            if (existingDriver == null)
            {
                return NotFound();
            }

            await _unitofwork.Driver.UpdateByAsync(driver);
            await _unitofwork.CompleteAsync();

            return NoContent();
        }
    }

}