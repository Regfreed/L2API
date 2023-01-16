using L2API.Service.Models;
using L2API.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace L2MVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private IVehicleModelService Service;

        public VehicleModelController(IVehicleModelService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleModel>> GetAllModels() => await Service.GetVehicleModelsAsync();


        [HttpGet("id")]
        [ActionName(nameof(GetModel))]
        [ProducesResponseType(typeof(VehicleModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetModel(Guid id)
        {
            var vehicle = await Service.GetVehicleModelsAsync(id);
            return vehicle == null ? NotFound() : Ok(vehicle);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(VehicleModel vehicle)
        {
            return await Service.InsertVehicleModelAsync(vehicle) ? CreatedAtAction(nameof(GetModel), new { id = vehicle.Id }, vehicle) : BadRequest();
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, VehicleModel vehicle)
        {
            if (id != vehicle.Id) return BadRequest();

            return await Service.UpdateVehicleModelAsync(vehicle) ? NoContent() : BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await Service.DeleteVehicleModelAsync(id) ? NoContent() : NotFound();
        }
    }

}
