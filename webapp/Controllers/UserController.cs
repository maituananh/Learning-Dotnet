using API.Configurations.DI;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Requests;
using Application.Usecases.User.CreateUserHandler;
using Application.Commands.User;

namespace Controller.User;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly CreateUserHandler _createUserHandler;
    private readonly IMapper _mapper;

    public UserController(CreateUserHandler createUserHandler, IMapper mapper)
    {
        _createUserHandler = createUserHandler;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddNewUser(UserCreateRequest request)
    {
        var userCommand = _mapper.Map<CreateUserCommand>(request);
        
        _createUserHandler.Create(userCommand);

        return Ok();
    }
}
