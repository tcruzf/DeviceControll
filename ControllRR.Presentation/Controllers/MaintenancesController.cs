using ControllRR.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControllRR.Presentation.Controllers;

public class MaintenancesController : Controller
{

    private readonly IMaintenanceService _maintenanceService;
    private readonly IDeviceService _deviceService;
    public MaintenancesController(IMaintenanceService maintenanceService, IDeviceService deviceService)
    {
        _maintenanceService = maintenanceService;
        _deviceService = deviceService;
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
    [HttpGet ]
    public async Task<IActionResult> MaintenanceList()
    {
        return View();
    }
    [HttpPost]
    public async Task<JsonResult> AllMaintenances()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
        var length = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "10");
        var searchValue = Request.Form["search[value]"].FirstOrDefault()?.ToLower();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][data]"].FirstOrDefault();
        var sortDirection = Request.Form["order[0][dir]"].FirstOrDefault();

        var result = await _maintenanceService.GetMaintenanceDataTableAsync(
            start, length, searchValue, sortColumn, sortDirection);

        return Json(result);
    } // Fim do método
}