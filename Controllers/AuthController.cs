using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AbarrotesHogar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IServicesAuth _servicesAuth;

    public AuthController(IServicesAuth servicesAuth)
    {
        _servicesAuth = servicesAuth;
    }

    [HttpPost("login")]
    public ActionResult<AuthResponse> Login([FromBody] AuthRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        AuthResponse response = _servicesAuth.Login(request);
        return Ok(response);
    }
}