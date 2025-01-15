using ControllRR.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControllRR.Presentation.Controllers;

public class MaintenancesController : Controller
{

    private readonly IMaintenanceService _maintenanceService;
    public MaintenancesController(IMaintenanceService maintenanceService)
    {
        _maintenanceService = maintenanceService;
    }

    public async Task<IActionResult> Index()
    {
        var maintenances = await _maintenanceService.GetAllAsync();
        return View(maintenances);

    }

    public async Task<IActionResult> Details(int id)
    {
        var maintenance = await _maintenanceService.GetByIdAsync(id);
        return View(maintenance);
        
    }
}