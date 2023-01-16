using L2API.Service.Models;

namespace L2API.Service.Services.Interfaces
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync();
        Task<VehicleMake> GetVehicleMakesAsync(Guid id);
        Task<Boolean> InsertVehicleMakeAsync(VehicleMake vehicleMake);
        Task<Boolean> DeleteVehicleMakeAsync(Guid id);
        Task<Boolean> UpdateVehicleMakeAsync(VehicleMake vehicleMake);
    }
}