using API.Requests;
using API.Responses;
using Application.Commands;
using Application.Usecases;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(
    CreateUserHandler createUserHandler,
    AssignUserToGroupHandler assignUserToGroupHandler,
    IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddNewUser(UserCreateRequest request, CancellationToken ct)
    {
        var userCommand = mapper.Map<CreateUserCommand>(request);

        var domain = await createUserHandler.Handle(userCommand, ct);

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
