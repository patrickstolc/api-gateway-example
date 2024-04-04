using Microsoft.AspNetCore.Mvc;

namespace PongService.Controllers;

public class PongResponse
{
    public string Response { get; set; }
}

[ApiController]
[Route("[controller]")]
public class PongServiceController : ControllerBase
{
    [HttpGet]
    public PongResponse Get()
    {
        return new PongResponse { Response = "pong" };
    }
}