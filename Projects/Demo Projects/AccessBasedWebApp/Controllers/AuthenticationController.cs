using AccessBasedWebApp.Models;
using AccessBasedWebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace AccessBasedWebApp.Controllers
{
    // Create an API controller that will authenticate a user with a username and password
    // We must declare the following 2 properties, Route, and API Controller at a minimum
    // Route("api/[controller]")] means that this API endpoint is accessible by the following URL format:
    // https://hostname/api/[PartOfClassNamePriorToTheWordController]
    // Here, [Route("api/[controller]")] corresponds to https://hostname/api/Authentication
    // Since the class name of the controller is AuthenticationController, we use the first part of the class name here
    // Also, the route and controller names are case sensitive when invoking the endpoint via Postman or through Javascript or a mobile phone app.
    [Route("api/[controller]")]
    [ApiController]

    // Contr
    public class AuthenticationController : Controller
    {
        // [HttpPost] means we invoke this method via a POST method with HTTP, meaning we are sending data from the client to the server
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] LoginDetails details)
        {
            // We have repository classes for SQL and database functionality

            // Create a new instance of the User Repository
            var userRepository = new UserRepository();

            // Do the same for the User Session Repository
            var userSessionRepository = new UserSessionRepository();

            // Get user from database with username received from front-end application
            var user = userRepository.GetUser(details.UserName);

            if (user == null)
            {
                return BadRequest(new { message = "User not found." });
            }

            // Take the password input from front-end application, hash and salt the input and compare with
            // the password hash in the database. If they match, then the user is authenticated.
            var authenticated = UtilityMethods.VerifyPassword(details.Password, user.PasswordHash);

            // If the user is authenticated, create a new session with a Microsoft GUID
            // GUIDs (Globally Unique Identifers) are proprietary to Microsoft
            // Generally otherwise, these are called UUIDs (Universally Unique Identifiers)

            if (authenticated)
            {
                // Create the GUID
                Guid g = Guid.NewGuid();

                // Create a new user session with the GUID as the session ID, the User ID from the Users table in the database,
                // and set IsActive to true by default as this is a new session.
                var newSession = new UserSession()
                {
                    SessionID = g.ToString(),
                    UserId = user.UserId,
                    IsActive = true
                };

                // Save the new session details to the database
                userSessionRepository.CreateNewSession(newSession);

                //Report to the front application that the authentication/login was successful with a timestamp and the session ID
                return Ok(new { message = "Authentication Successful", lastLogin = DateTime.Now, sessionId = newSession.SessionID });
            }

            // If the login details were incorrect, report that to the front-end application instead
            else
            {
                return BadRequest(new { message = "Incorrect Username or Password." });
            }
            
        }
    }
}
