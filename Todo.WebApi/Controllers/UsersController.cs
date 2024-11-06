using Microsoft.AspNetCore.Mvc;
using Models.Users;
using Service.Abstract;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthenticationService _authenticationService;

    public UsersController(IUserService userService, IAuthenticationService authenticationService)
    {
        _userService = userService;
        _authenticationService = authenticationService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] RegisterRequestDto dto)
    {
        var result = await _authenticationService.RegisterByTokenAsync(dto);
        return Ok(result);
    }

    [HttpGet("getbyemail")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        var result = await _userService.GetByEmailAsync(email);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var result = await _authenticationService.LoginByTokenAsync(dto);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] string id)
    {
        var result = await _userService.DeleteAsync(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromQuery] string id, [FromBody] UpdateRequestDto dto)
    {
        var result = await _userService.UpdateAsync(id, dto);
        return Ok(result);
    }

    [HttpPut("changepassword")]
    public async Task<IActionResult> ChangePassword(string id, ChangePasswordRequestDto dto)
    {
        var result = await _userService.ChangePasswordAsync(id, dto);
        return Ok(result);
    }
}
