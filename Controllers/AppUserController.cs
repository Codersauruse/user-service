using Microsoft.AspNetCore.Mvc;
using user_service.DTO;
using user_service.Service.interfaces;

namespace user_service.Controllers;
[ApiController]
[Route("/api/user")]
public class AppUserController :ControllerBase
{
    private readonly IAppUserService _appUserService;
    public AppUserController(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }
    [HttpGet("/getUser/{userId}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var user = await  _appUserService.GetUserById(userId);
        return Ok(user);
    }
    
    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] AppUserRequest userDetails)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = await  _appUserService.Register(userDetails);
        return Ok(user);
    }
    
    [HttpGet("/validateUser/{userId}")]
    public async Task<IActionResult> validateUserById(int userId)
    {
        var result = await  _appUserService.validateUserById(userId);
        return Ok(result);
    }
    
}