using Class_Web.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Class_Web.BLL.Services;
using Class_Web.BLL.Interfaces;

namespace Class_Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _service;

        public EventController(IEventRepository service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ev = await _service.GetByIdAsync(id);
            return ev == null ? NotFound() : Ok(ev);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EventDetails ev)
        {
            await _service.AddAsync(ev);
            return CreatedAtAction(nameof(Get), new { id = ev.EventId }, ev);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EventDetails ev)
        {
            await _service.UpdateAsync(ev);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

}
