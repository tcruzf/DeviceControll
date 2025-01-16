using ControllRR.Application.DTOs;
using ControllRR.Application.Interfaces;
using ControllRR.Domain.Entities;
using ControllRR.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ControllRR.Presentation.Controllers;

public class MaintenancesController : Controller
{

    private readonly IMaintenanceService _maintenanceService;
    private readonly IDeviceService _deviceService;
    private readonly IUserService _userService;
    public MaintenancesController(IMaintenanceService maintenanceService, IDeviceService deviceService, IUserService userService)
    {
        _maintenanceService = maintenanceService;
        _deviceService = deviceService;
        _userService = userService;

    }

    public async Task<IActionResult> Index()
    {
        var maintenances = await _maintenanceService.GetAllAsync();
        return View(maintenances);

    }
    [HttpGet]
    public async Task<IActionResult> NewMaintenance()
    {
        var users = await _userService.GetAllAsync();
        var maintenance = new MaintenanceDto();
        var viewModel = new MaintenanceViewModel { User = users, Maintenance = maintenance };
        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> NewMaintenance(MaintenanceDto maintenanceDto)
    {
        //if (!ModelState.IsValid)
       // {
            
        //}
        await _maintenanceService.AddAsync(maintenanceDto);
        return RedirectToAction(nameof(Index));
        
    }

    public async Task<IActionResult> Details(int id)
    {
        var maintenance = await _maintenanceService.GetByIdAsync(id);
        return View(maintenance);

    }
    [HttpGet]
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