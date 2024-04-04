using Microsoft.AspNetCore.Mvc;

namespace PingService.Controllers;

public class PingResponse
{
    public string Response { get; set; }
}

[ApiController]
[Route("[controller]")]
public class PingServiceController : ControllerBase
{
    [HttpGet]
    public PingResponse Get()
    {
        return new PingResponse { Response = "ping" };
    }
}