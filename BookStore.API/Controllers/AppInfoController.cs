using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BookStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppInfoController(IOptions<AppInfo> config) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAppInfo() => Ok(config.Value);
}