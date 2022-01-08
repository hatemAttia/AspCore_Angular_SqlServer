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
            var eleve = _authenticateService.AuthenticateEleve(model.Email, model.password);

            if (eleve == null)
                return BadRequest(new
                { message = "Eleve or Password is incorrect" });
            return Ok(eleve);
        }
        [Route("/auth-admin")]
        [HttpPost]
        public IActionResult Post([FromBody] Auth model)
        {
            var admin = _authenticateService.AuthenticateAdmin(model.Email, model.Password);

            if (admin == null)
                return BadRequest(new
                { message = "admin or Password is incorrect" });
            return Ok(admin);
        }
    }
}

