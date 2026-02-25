using Application.Commands;
using Application.Requests;
using Application.Responses;
using Application.Usecases;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(
    AuthenHandler authenHandler,
    IValidator<AuthRequest> validator,
    IMapper mapper) : Controller
{
    [HttpPost("token")]
    public async Task<IActionResult> GenerateToken([FromBody] AuthRequest auth, CancellationToken ct)
    {
        var validationResult = validator.ValidateAsync(auth, ct);

        if (!validationResult.Result.IsValid)
        {
            return BadRequest(validationResult.Result.Errors.Select(e => e.ErrorMessage));
        }

        var command = mapper.Map<AuthenticationCommand>(auth);

        var token = await authenHandler.Handle(command, ct);

        return Ok(mapper.Map<AuthResponse>(token));
    }
}
