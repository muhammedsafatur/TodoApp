using Microsoft.AspNetCore.Mvc;
using Models.Users;
using Service.Abstract;
using WebApi.Middlewares;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost("addroletouser")]
    public async Task<IActionResult> AddRoleToUser([FromBody] RoleAddToUserRequestDto dto)
    {
        var result = await _roleService.AddRoleToUser(dto);
        return Ok(result);
    }

    [HttpGet("getallrolesbyid")]
    public async Task<IActionResult> GetAllRolesByUserId([FromQuery] string userId)
    {
        var result = await _roleService.GetAllRolesByUserId(userId);
        return Ok(result);
    }

    [HttpPost("addrole")]
    public async Task<IActionResult> AddRoleAsync([FromQuery] string Name)
    {
        var result = await _roleService.AddRoleAsync(Name);
        return Ok(result);
    }
}
