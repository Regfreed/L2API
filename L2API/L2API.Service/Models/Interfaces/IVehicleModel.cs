namespace L2API.Service.Models.Interfaces
{
    public interface IVehicleModel : IBaseModel
    {
        VehicleMake Make { get; set; }
        Guid MakeId { get; set; }
    }
}