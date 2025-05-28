using user_service.DTO;
using user_service.Models;

namespace user_service.Service.interfaces;

public interface IAppUserService
{
    public  Task<AppUser> GetUserById(int userId);

    public Task<AppUser> Register(AppUserRequest userDetails);
}