using user_service.Models;

namespace user_service.Repository.interfaces;

public interface IAppUserRepo{

Task<AppUser> findByUserId(int userId);
Task<AppUser> register(AppUser user);
Task<bool> validateUserById(int userId);
}