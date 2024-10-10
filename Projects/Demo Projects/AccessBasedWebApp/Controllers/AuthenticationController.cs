using AccessBasedWebApp.Models;
using AccessBasedWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace AccessBasedWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        public async Task<IActionResult> Authenticate([FromBody] RegistrationDetails details)
        {
            var userRepository = new UserRepository();
            var userSessionRepository = new UserSessionRepository();
            var user = userRepository.GetUser(details.UserName);
            var authenticated = UtilityMethods.VerifyPassword(details.Password, user.PasswordHash);
            if (authenticated)
            {
                Guid g = Guid.NewGuid();

                var newSession = new UserSession()
                {
                    SessionID = g.ToString(),
                    UserId = user.UserId,
                    IsActive = true
                };

                userSessionRepository.CreateNewSession(newSession);
                return Ok(new { message = "Authentication Successful" });
            }

            else
            {
                return BadRequest(new { message = "Incorrect Username or Password." });
            }
            
        }
    }
}
