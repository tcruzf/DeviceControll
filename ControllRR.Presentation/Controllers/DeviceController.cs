using ControllRR.Application.Interfaces;
using ControllRR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Mvc;
namespace ControllRR.Presentation.Controllers;

public class DevicesController : Controller
{
    private readonly IDeviceService _deviceService;
    private readonly ISectorService _sectorService;

    private readonly ControllRRContext _controllRRContext;

    public  DevicesController(IDeviceService deviceService, ISectorService sectorService, ControllRRContext controllRRContext)
    {
        _deviceService = deviceService;
        _sectorService = sectorService;
        _controllRRContext = controllRRContext;

    }
    public async Task<IActionResult> Index()
    {
        var device = await _deviceService.GetAllAsync();
        return View(device);
    }

    [HttpGet]
    public async Task<IActionResult> Search(string term)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return Json(new List<object>());
        }

        var devices = await _controllRRContext.Devices
            .Where(d => d.Model.Contains(term) || d.SerialNumber.Contains(term) || d.Type.Contains(term) || d.Identifier.Contains(term))
            .Select(d => new { d.Id, d.Model, d.SerialNumber, d.Type, d.Identifier })
            .ToListAsync();

        return Json(devices);
    }
}