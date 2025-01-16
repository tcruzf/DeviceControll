using ControllRR.Application.DTOs;
using ControllRR.Domain.Enums;

namespace ControllRR.Presentation.ViewModels;

public class MaintenanceViewModel
{
     public MaintenanceDto Maintenance { get; set; }
    public IEnumerable<UserDto> User { get; set; }
    public IEnumerable<DeviceDto> Device { get; set; }

    public IEnumerable<MaintenanceStatusDto> MaintenanceStatus { get; set; }
}