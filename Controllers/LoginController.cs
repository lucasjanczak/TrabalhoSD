using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Requests;
using Web.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly PersonService _personService;

        public LoginController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] PersonRequest request)
        {
            if (_personService.Login(request))
            {
                return Ok(new { message = "Login bem-sucedido." });
            }
            return BadRequest(new { message = "Login ou senha inválidos." });

        }
    }
}
