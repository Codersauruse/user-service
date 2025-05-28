using user_service.DTO;
using user_service.Enum;
using user_service.Exception;
using user_service.Models;
using user_service.Repository.interfaces;
using user_service.Service.interfaces;

namespace user_service.Service;

public class AppUserService : IAppUserService
{
    private readonly IAppUserRepo _appUserRepo;
    
    public AppUserService(IAppUserRepo appUserRepo)
    {
        _appUserRepo = appUserRepo;
    }
    public async Task<AppUser> GetUserById(int userId)
    {
        var user = await _appUserRepo.findByUserId(userId);
        if (user == null)
        {
            throw new InvalidArgumentException("Invalid user id");
        }
        return user;
        
    }

    public Task<AppUser> Register(AppUserRequest userDetails)
    {
        var user = new AppUser
        {
            email = userDetails.email,
            name = userDetails.name,
            password = userDetails.password,
            role = Role.ROLE_USER
        };
        return _appUserRepo.register(user);
    }
}