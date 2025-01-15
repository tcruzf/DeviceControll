using System.ComponentModel.DataAnnotations;
using ControllRR.Domain.Entities;

namespace ControllRR.Application.DTOs;


public class DeviceDto
{
   public int Id { get; set; }
    
    [Display(Name = "Tipo")]
    public string Type { get; set; }

    [Display(Name = "Identificador")]
    public string Identifier { get; set; }

    [Display(Name = "Modelo")]
    public string Model { get; set; }

    [Display(Name = "Nº de Série")]
    public string SerialNumber { get; set; }

    [Display(Name = "Descrição")]
    public string Description { get; set; }

    [Display(Name = "Setor")]
    public string SectorName { get; set; } // Nome simplificado para exibição

    [Display(Name = "Manutenções")]
    public ICollection<MaintenanceDto>? Maintenances { get; set; } = new List<MaintenanceDto>();


}