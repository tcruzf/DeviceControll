using System.ComponentModel.DataAnnotations;

namespace ControllRR.Domain.Entities;

public class Sector
{
    public int Id { get; set; }


    public string Name { get; set; }
    public string Location { get; set; }
    public string RequesterName { get; set; }
    public string Address { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string Cep { get; set; }
    public ICollection<Device>? Devices { get; set; }

    public Sector()
    {

    }
    public Sector(int id, string name, string location, string address, string number, string neighborhood, string city, string cep, string requesterName)
    {
        Id = id;
        Name = name;
        Location = location;
        Address = address;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        Cep = cep;
        RequesterName = requesterName;

    }
}