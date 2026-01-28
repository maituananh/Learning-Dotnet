using API.Configurations.DI;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Requests;
using Application.Usecases.CreateUserHandler;
using Application.Commands.User;

namespace Controller.User;

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
