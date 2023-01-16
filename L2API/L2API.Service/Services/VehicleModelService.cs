using L2API.Service.Models;
using L2API.Service.Models.Interfaces;
using L2API.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace L2API.Service.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private DatabaseContext DatabaseContext;

        public VehicleModelService(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }


        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync()
        {
            var vehicle = await DatabaseContext.VehicleModels.ToArrayAsync();
            foreach (var vehicleModel in vehicle)
            {
                if (vehicleModel.MakeId != default)
                {
                    vehicleModel.Make = await DatabaseContext.VehicleMakes.FindAsync(vehicleModel.MakeId);
                }
            }
            return vehicle;
        }

        public async Task<VehicleModel> GetVehicleModelsAsync(Guid id)
        {
            var vehicle = await DatabaseContext.VehicleModels.FindAsync(id);
            if (vehicle.MakeId != default)
            {
                vehicle.Make = await DatabaseContext.VehicleMakes.FindAsync(vehicle.MakeId);
            }
            return vehicle;
        }

        public async Task<Boolean> InsertVehicleModelAsync(VehicleModel vehicleModel)
        {
            DatabaseContext.VehicleModels.FirstOrDefault(x => x.Name == vehicleModel.Name && x.MakeId == vehicleModel.MakeId);


            if (DatabaseContext.VehicleModels.FirstOrDefault(x => x.Name == vehicleModel.Name && x.MakeId == vehicleModel.MakeId) == null && DatabaseContext.VehicleMakes.FirstOrDefault(x => x.Id == vehicleModel.MakeId) != null)
            {
                vehicleModel.Make = null;
                await DatabaseContext.VehicleModels.AddAsync(vehicleModel);
                await DatabaseContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Boolean> DeleteVehicleModelAsync(Guid id)
        {
            var vehicle = await DatabaseContext.VehicleModels.FindAsync(id);

            if (vehicle != null)
            {
                DatabaseContext.VehicleModels.Remove(vehicle);
                await DatabaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Boolean> UpdateVehicleModelAsync(VehicleModel vehicleModel)
        {
            if (DatabaseContext.VehicleModels.FirstOrDefault(x => x.Name == vehicleModel.Name && x.MakeId == vehicleModel.MakeId) == null)
            {
                DatabaseContext.Entry(vehicleModel).State = EntityState.Modified;
                await DatabaseContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}