using user_service.Models;
using user_service.Repository.interfaces;

namespace user_service.Repository;

public class AppUserRepo : IAppUserRepo
{
    private readonly AppDbContext _context;
    
    
    public AppUserRepo(AppDbContext context)
    {
        _context = context;
    }
    public async Task<AppUser> findByUserId(int userId)
    {
        return await _context.AppUsers.FindAsync(userId);
    }

    public  async Task<AppUser> register(AppUser user)
    {
        _context.AppUsers.Add(user);
        _context.SaveChanges();
        return Task.FromResult(user).Result;
    }
}