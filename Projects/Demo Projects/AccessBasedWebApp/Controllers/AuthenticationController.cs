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
            var credentialRepository = new CredentialPairRepository();
            var credentialPair = credentialRepository.RetrieveCredentials(details.UserName);
            var authenticated = UtilityMethods.VerifyPassword(details.Password, credentialPair.PasswordHash);
            if (authenticated)
            {
                return Ok(new { message = "Authentication Successful" });
            }

            else
            {
                return BadRequest(new { message = "Incorrect Username or Password." });
            }
            
        }
    }
}
