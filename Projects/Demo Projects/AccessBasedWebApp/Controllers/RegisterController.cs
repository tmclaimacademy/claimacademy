using AccessBasedWebApp.Models;
using AccessBasedWebApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccessBasedWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegisterController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationDetails registration)
        {
            var userRepository = new UserRepository();
            var hashedPassword = UtilityMethods.HashPassword(registration.Password);
            var user = new User() {UserName = registration.UserName, PasswordHash = hashedPassword };
            userRepository.SaveCredentials(user);
            return Ok(new { message = "Registration Successful" });
        }
    }
}
