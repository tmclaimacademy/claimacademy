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
            var credentialRepository = new CredentialPairRepository();
            var credentialPair = new CredentialPair();
            credentialPair.UserName = registration.UserName;
            credentialPair.PasswordHash = UtilityMethods.HashPassword(registration.Password);
            credentialRepository.SaveCredentials(credentialPair);
            return Ok(new { message = "Registration Successful" });
        }
    }
}
