using Application.Responses;
using Application.Usecases;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly GetGroupByIdHandler _getGroupByIdHandler;
    private readonly IMapper _mapper;

    public GroupController(
        GetGroupByIdHandler getGroupByIdHandler,
        IMapper mapper)
    {
        _getGroupByIdHandler = getGroupByIdHandler;
        _mapper = mapper;
    }

    [HttpGet("{groupId:guid}")]
    public async Task<IActionResult> GetGroupById(Guid groupId, CancellationToken tx)
    {
        var group = await _getGroupByIdHandler.Handle(groupId, tx);

        return Ok(_mapper.Map<GroupResponse>(group));
    }
}
