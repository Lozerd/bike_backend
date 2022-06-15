using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bike_backend.Controllers;

[ApiController]
[ApiVersion("1.0")]
public class IndexController : Controller
{
    [HttpGet("index/")]
    [Authorize]
    public IActionResult Index()
    {
        return Ok(new { title = "Hello World" });
    }
}