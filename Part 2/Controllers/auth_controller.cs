using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Part_2.database;
using Part_2.models;

namespace Part_2.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        get_authentication authentication = new get_authentication();

        // Register a new user
        [HttpPost("register")]
        public IActionResult Register(register_user request)
        {
            if (request.role != "Participant" &&
                request.role != "Organiser")
            {
                return BadRequest("Role must be Participant or Organiser.");
            }

            string password = request.password;

            string message = authentication.register_user(
                request.email,
                password,
                request.role);

            return Content(message);
        }
        // login
        [HttpPost("login")]
        public IActionResult Login(register_user request)
        {
            string message = authentication.login_user(
                request.email,
                request.password);

            if (message == "Invalid email or password.")
            {
                return BadRequest(message);
            }

            return Content(message);
        }

    }
}
