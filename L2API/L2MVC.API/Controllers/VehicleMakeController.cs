using L2API.Service.Models;
using L2API.Service.Models.Interfaces;
using L2API.Service.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L2MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        private IVehicleMakeService Service;

        public VehicleMakeController(IVehicleMakeService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleMake>> GetAllMakers() => await Service.GetVehicleMakesAsync();


        [HttpGet("id")]
        [ActionName(nameof(GetMaker))]
        [ProducesResponseType(typeof(VehicleMake), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMaker(Guid id)
        {
            var maker = await Service.GetVehicleMakesAsync(id);
            return maker == null ? NotFound() : Ok(maker);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(VehicleMake make)
        {
            return await Service.InsertVehicleMakeAsync(make) ? CreatedAtAction(nameof(GetMaker), new { id = make.Id }, make) : BadRequest();
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, VehicleMake make)
        {
            if (id != make.Id) return BadRequest();
            
            return await Service.UpdateVehicleMakeAsync(make) ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await Service.DeleteVehicleMakeAsync(id) ? NoContent() : NotFound();
        }
    }
}
