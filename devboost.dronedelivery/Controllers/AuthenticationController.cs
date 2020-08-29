using devboost.Domain.Handles.Queries.Interfaces;
using devboost.Domain.Queries.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        readonly ILoginHandler _loginService;

        public AuthenticationController(ILoginHandler loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] QueryUserFilter user)
        {
            var result = await _loginService.LoginUser(user);
            if (!result.Valid)
                return NotFound(result.Message);
            else
                return Ok(result);
        }
    }
}
