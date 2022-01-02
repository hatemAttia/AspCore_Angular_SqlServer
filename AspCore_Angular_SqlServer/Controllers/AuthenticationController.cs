using AspCore_Angular_SqlServer.Models;
using AspCore_Angular_SqlServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCore_Angular_SqlServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticateService _authenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Eleve model)
        {
            var eleve = _authenticateService.Authenticate(model.Email, model.password);

            if (eleve == null)
                return BadRequest(new
                { message = "Eleve or Password is incorrect" });
            return Ok(eleve);
        }
    }
}

