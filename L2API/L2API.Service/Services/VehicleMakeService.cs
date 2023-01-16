using L2API.Service.Models;
using L2API.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace L2API.Service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private DatabaseContext DatabaseContext;

        public VehicleMakeService(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public async Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync()
        {
            var makers = await DatabaseContext.VehicleMakes.ToArrayAsync();
            return makers;
        }

        public async Task<VehicleMake> GetVehicleMakesAsync(Guid id)
        {
            var maker = await DatabaseContext.VehicleMakes.FindAsync(id);
            return maker;
        }

        public async Task<Boolean> InsertVehicleMakeAsync(VehicleMake vehicleMake)
        {
            if (DatabaseContext.VehicleMakes.FirstOrDefault(x => x.Name == vehicleMake.Name) == null)
            {
                await DatabaseContext.VehicleMakes.AddAsync(vehicleMake);
                await DatabaseContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Boolean> DeleteVehicleMakeAsync(Guid id)
        {
            var maker = await DatabaseContext.VehicleMakes.FindAsync(id);

            if (maker != null)
            {
                DatabaseContext.VehicleMakes.Remove(maker);
                await DatabaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Boolean> UpdateVehicleMakeAsync(VehicleMake vehicleMake)
        {
            if (DatabaseContext.VehicleMakes.FirstOrDefault(x => x.Name == vehicleMake.Name) == null)
            {
                DatabaseContext.Entry(vehicleMake).State = EntityState.Modified;
                await DatabaseContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
