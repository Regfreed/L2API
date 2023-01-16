using L2API.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace L2API.Service.Services.Interfaces
{
    public interface IDatabaseContext 
    {
        DbSet<VehicleMake> VehicleMakes { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }
    }
}