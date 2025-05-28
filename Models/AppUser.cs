using user_service.Enum;

namespace user_service.Models;

public class AppUser
{
    
    public  int id { get; set; }
    public required string name { get; set; }
    public required string email { get; set; }
    public required string password { get; set; }
    public required Role role { get; set; }
}