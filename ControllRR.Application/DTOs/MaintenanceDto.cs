using System.ComponentModel.DataAnnotations;

namespace ControllRR.Application.DTOs;

public class MaintenanceDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "A descrição simples é obrigatória.")]
    [StringLength(100, ErrorMessage = "A descrição simples deve ter no máximo 100 caracteres.")]
    [Display(Name = "Descrição Simples")]
    public string SimpleDesc { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição completa é obrigatória.")]
    [StringLength(500, ErrorMessage = "A descrição completa deve ter no máximo 500 caracteres.")]
    [Display(Name = "Descrição")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Data de Abertura")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime OpenDate { get; set; }

    [Display(Name = "Data de Fechamento")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? CloseDate { get; set; }

    [Required(ErrorMessage = "O status é obrigatório.")]
    [Display(Name = "Status")]
    public string Status { get; set; } = string.Empty; // Ex.: Aberto, Fechado

    [Display(Name = "Usuário")]
    public string UserFullName { get; set; } = string.Empty; // Nome completo do usuário responsável

    [Display(Name = "Dispositivo")]
    public string DeviceName { get; set; } = string.Empty; // Nome ou modelo do dispositivo associado

    [Display(Name = "Setor")]
    public string SectorName { get; set; } = string.Empty; //Nome do setor
}
