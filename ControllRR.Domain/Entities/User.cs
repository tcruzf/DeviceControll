using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNetCore.Identity;

namespace ControllRR.Domain.Entities;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }

    public double Register { get; set; }

     public ICollection<Maintenance>? Maintenances {get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public User()
    {

    }
    public User(int id, string name, string phone, double register, DateTime createdAt)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Register = register;
        CreatedAt = createdAt;
    }
}