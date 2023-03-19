using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace housing_back_end.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected int GetUserId() {
        return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}