using Microsoft.AspNetCore.Mvc;
using Web.Requests;
using Web.Services;

namespace Web.Controllers;

[ApiController]
[Route("Login")]
public class LoginController(PersonService personService) : Controller
{
    private readonly PersonService _personService = personService;

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
