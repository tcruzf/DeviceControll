using ControllRR.Application.DTOs;
using ControllRR.Domain.Entities;

namespace ControllRR.Application.Interfaces;

public interface IUserService
{
    
    Task<UserDto> GetByIdAsync(int id);
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task AddAsync(UserDto user);
    Task UpdateAsync(UserDto user);
    Task DeleteAsync(int id);
}