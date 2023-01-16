using System.ComponentModel.DataAnnotations.Schema;
using L2API.Service.Models.Interfaces;

namespace L2API.Service.Models
{
    public class VehicleModel : BaseModel, IVehicleModel
    {
        [ForeignKey("MakeId")]
        public Guid MakeId { get; set; }
        public VehicleMake Make { get; set; }
    }
}
