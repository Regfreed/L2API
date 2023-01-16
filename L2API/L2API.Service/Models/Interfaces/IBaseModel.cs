namespace L2API.Service.Models.Interfaces
{
    public interface IBaseModel
    {
        string Abrv { get; set; }
        Guid Id { get; set; }
        string Name { get; set; }
    }
}