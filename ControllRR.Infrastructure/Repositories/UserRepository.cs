using ControllRR.Domain.Entities;
using ControllRR.Domain.Interfaces;
using ControllRR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControllRR.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ControllRRContext _controllRRContext;
    public UserRepository(ControllRRContext controllRRContext){
        _controllRRContext = controllRRContext;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _controllRRContext.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        
       return await _controllRRContext.Users//.FindAsync(id);
        .Include(x => x.Maintenances).FirstOrDefaultAsync(x => x.Id == id);
        
        
    } 

   public async Task AddAsync(User user) 
   {
    await _controllRRContext.Users.AddAsync(user);
    await _controllRRContext.SaveChangesAsync();

   }

   public async Task UpdateAsync(User user)
   {
    _controllRRContext.Update(user);
    await _controllRRContext.SaveChangesAsync();
   }

   public async Task DeleteAsync(int id)
   {
    var user = await GetByIdAsync(id);
    if(user != null)
    {
        _controllRRContext.Users.Remove(user);
        await _controllRRContext.SaveChangesAsync();
    }
   }

}