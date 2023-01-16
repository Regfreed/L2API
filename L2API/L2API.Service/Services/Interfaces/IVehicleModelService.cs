using L2API.Service.Models;

namespace L2API.Service.Services.Interfaces
{
    public interface IVehicleModelService
    {
        Task<bool> DeleteVehicleModelAsync(Guid id);
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync();
        Task<VehicleModel> GetVehicleModelsAsync(Guid id);
        Task<bool> InsertVehicleModelAsync(VehicleModel vehicleModel);
        Task<bool> UpdateVehicleModelAsync(VehicleModel vehicleModel);
    }
}