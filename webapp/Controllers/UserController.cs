using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Requests;
using Application.Usecases;
using Application.Commands.User;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(CreateUserHandler createUserHandler, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddNewUser(UserCreateRequest request, CancellationToken ct)
    {
        var userCommand = mapper.Map<CreateUserCommand>(request);
        
        await createUserHandler.Handle(userCommand, ct);

        return Ok();
    }
}
