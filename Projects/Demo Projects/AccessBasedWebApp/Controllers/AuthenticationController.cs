using AccessBasedWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace AccessBasedWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        public async Task<IActionResult> Authenticate([FromBody] RegistrationDetails credentialPair)
        {
            return Ok(new { message = "Authentication Successful" });
        }
    }
}
