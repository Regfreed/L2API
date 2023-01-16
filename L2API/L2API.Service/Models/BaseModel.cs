
using L2API.Service.Models.Interfaces;

namespace L2API.Service.Models
{
    public class BaseModel : IBaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
