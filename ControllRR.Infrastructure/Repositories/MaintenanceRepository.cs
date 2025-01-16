using ControllRR.Application.DTOs;
using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace ControllRR.Infrastructure.Repositories;

public class MaintenanceRepository : IMaintenanceRepository
{
    private readonly ControllRRContext _controllRRContext;

    public MaintenanceRepository(ControllRRContext controllRRContext)
    {
        _controllRRContext = controllRRContext;
    }

    public async Task<IEnumerable<Maintenance>> GetAllAsync()
    {
        return await _controllRRContext.Maintenances
        .Include(x => x.User)
        .ToListAsync();
    }

    public async Task<Maintenance?> GetByIdAsync(int id)
    {
      return  await _controllRRContext.Maintenances
      .Include(x => x.User)
      .Include(x => x.Device)
      .Include(x => x.Device.Sector)
      .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task AddAsync(Maintenance maintenance)
    {
        await _controllRRContext.Maintenances.AddAsync(maintenance);
        await _controllRRContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Maintenance maintenance)
    {
        _controllRRContext.Maintenances.Update(maintenance);
        await _controllRRContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var maintenance = await GetByIdAsync(id);
        _controllRRContext.Maintenances.Remove(maintenance);
        await _controllRRContext.SaveChangesAsync();

    }

    public async Task<(IEnumerable<object> Data, int TotalRecords, int FilteredRecords)> GetMaintenancesAsync(
        int start, 
        int length, 
        string searchValue, 
        string sortColumn, 
        string sortDirection)
    {
        var query = _controllRRContext.Maintenances
            .Include(x => x.Device)
            .Include(x => x.User)
            .AsQueryable();

        // Filtragem
        if (!string.IsNullOrEmpty(searchValue))
        {   //Gambiarra para poder fazer uma porrada de tentativa de pegar um ou outro valor(não vou explicar, tô com a cabeça e o estomago doendo e sem paciencia!)
            query = query.Where(x =>
                (x.SimpleDesc != null && x.SimpleDesc.ToLower().Contains(searchValue)) ||
                (x.MaintenanceNumber != null && x.MaintenanceNumber.ToString().ToLower().Contains(searchValue)) ||
                (x.Device.SerialNumber != null && x.Device.SerialNumber.ToString().ToLower().Contains(searchValue)) ||
                (x.Description != null && x.Description.ToLower().Contains(searchValue)) ||
                (x.Device != null && x.Device.Model != null && x.Device.Model.ToLower().Contains(searchValue)) ||
                (x.User != null && x.User.Name != null && x.User.Name.ToLower().Contains(searchValue)) ||
                (x.Device != null && x.Device.Identifier != null && x.Device.Identifier.ToLower().Contains(searchValue)));
        }

        // Contagem após o filtro
        var filteredCount = await query.CountAsync();

        // Ordenação
        if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortDirection))
        {
            query = query.OrderBy($"{sortColumn} {sortDirection}");
        }
        else
        {
            query = query.OrderBy(x => x.Id);
        }

        // Paginação
        var data = await query
            .Skip(start)
            .Take(length)
            .Select(x => new
            {
                Id = x.Id,
                SimpleDesc = x.SimpleDesc,
                Status = x.Status,
                MaintenanceNumber = x.MaintenanceNumber,
                Description = x.Description,
                Device = x.Device.Model,
                User = x.User.Name,
                Identifier = x.Device.Identifier,
                SerialNumber = x.Device.SerialNumber
            })
            .ToListAsync();

        var totalRecords = await _controllRRContext.Maintenances.CountAsync();

        return (data, totalRecords, filteredCount);
    }



}