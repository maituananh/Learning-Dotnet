using API.Requests;
using API.Responses;
using Application.Commands;
using Application.Usecases;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(
    AuthenHandler authenHandler,
    IMapper mapper) : Controller
{
    [HttpPost("token")]
    public async Task<IActionResult> GenerateToken([FromBody] AuthRequest auth, CancellationToken ct)
    {
        var command = mapper.Map<AuthenticationCommand>(auth);

        var token = await authenHandler.Handle(command, ct);

        return Ok(mapper.Map<AuthResponse>(token));
    }
}
