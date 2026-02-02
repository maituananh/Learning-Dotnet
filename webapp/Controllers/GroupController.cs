using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    [HttpGet("/{groupId:guid}")]
    public async Task<IActionResult> GetGroupById(Guid groupId) {

        return Ok(new { groupId });
    }
}
