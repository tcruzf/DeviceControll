using System.ComponentModel.DataAnnotations;
using ControllRR.Domain.Entities;

namespace ControllRR.Application.DTOs;

public class SectorDto
{
    public int Id { get; set; }

    [Display(Name = "Setor")]
    public string Name { get; set; }

    [Display(Name = "Local")]
    public string Location { get; set; }

    [Display(Name = "Solicitante")]
    public string RequesterName { get; set; }

    [Display(Name = "Dispositivos")]
    public ICollection<DeviceDto>? Devices { get; set; } = new List<DeviceDto>();
}