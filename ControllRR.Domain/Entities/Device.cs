using System.ComponentModel.DataAnnotations;

namespace ControllRR.Domain.Entities;

public class Device
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Identifier { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public string Description { get; set; }

    public int SectorId { get; set; }
    public Sector? Sector { get; set; }
    public ICollection<Maintenance>? Maintenances { get; set; }

    public Device()
    {
        Maintenances = new List<Maintenance>();
    }

    public Device(int id, string type, string identifier, string model, Sector sector, string serialNumber, string description)
    {
        Id = id;
        Type = type;
        Identifier = identifier;
        Model = model;
        Sector = sector;
        SerialNumber = serialNumber;
        Description = description;
    }

}