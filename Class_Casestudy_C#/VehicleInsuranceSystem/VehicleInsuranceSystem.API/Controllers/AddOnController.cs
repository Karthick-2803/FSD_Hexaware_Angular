using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleInsuranceSystem.DAL.Models;
using VehicleInsuranceSystem.DAL.Repositories.Interfaces;

namespace VehicleInsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddOnController : ControllerBase
    {
        private readonly IGenericRepository<AddOn> _addOnRepo;

        public AddOnController(IGenericRepository<AddOn> addOnRepo)
        {
            _addOnRepo = addOnRepo;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAddOns()
        {
            var addons = await _addOnRepo.GetAllAsync();
            return Ok(addons);
        }
    }

}
