using System.ComponentModel.DataAnnotations;

namespace ControllRR.Application.DTOs;

public class UserDto
{
   public int Id { get; set; }

    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Display(Name = "Telefone")]
    public string Phone { get; set; }

    [Display(Name = "Matrícula")]
    public double Register { get; set; }

    [Display(Name = "Criado em")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Manutenções")]
    public ICollection<MaintenanceDto>? Maintenances { get; set; } = new List<MaintenanceDto>();
}