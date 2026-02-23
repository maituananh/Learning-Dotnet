using API.Requests;
using API.Responses;
using Application.Commands;
using Application.Usecases;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Webapp.Application.Usecases;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController(
    CreateUserHandler createUserHandler,
    AssignUserToGroupHandler assignUserToGroupHandler,
    GetUserHandler getUserHandler,
    ClaimsPrincipal claimsPrincipal,
    IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddNewUser([FromBody] UserCreateRequest request, CancellationToken ct)
    {
        var userCommand = mapper.Map<CreateUserCommand>(request);

        var domain = await createUserHandler.Handle(userCommand, ct);

        Console.WriteLine("User created with ID: " + claimsPrincipal.Claims.Where(c => c.Type == "name").Single().Value);

        return Ok(mapper.Map<UserResponse>(domain));
    }

    [HttpGet("me")]
    public async Task<IActionResult> Me(CancellationToken ct)
    {
        var userId = new Guid(claimsPrincipal.Claims.Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Single().Value);

        var domain = await getUserHandler.Handle(userId, ct);

        if (domain is null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<UserResponse>(domain));
    }

    [HttpPatch("{userId:guid}/group/{groupId:guid}")]
    public async Task<IActionResult> AssignUserToGroup(Guid userId, Guid groupId, CancellationToken ct)
    {
        var assignment = new AssignUserToGroupCommand(userId, groupId);

        var domain = await assignUserToGroupHandler.Handle(assignment, ct);

        return Ok(mapper.Map<GroupUserResponse>(domain));
    }
}
