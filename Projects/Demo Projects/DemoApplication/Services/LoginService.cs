using DemoApplication.Models;
using DemoApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Services
{
    // This Login Service contains methods which perform actions needed for login.
    public class LoginService
    {
        // Default constructor, don't need another
        public LoginService()
        {

        }

        public UserSession Login(string username, string password)
        {
            var userService = new UserService();
            var cryptoService = new CryptoService();
            var user = userService.GetUserByUsername(username);
            UserSession nullSession = null;

            // Return null user session if the user isn't found
            if (user == null)
            {
                return nullSession;
            }

            // If the user is found otherwise, verify the password
            var authenticated = cryptoService.VerifyPassword(password, user.PasswordHash);

            // If the user is authenticated (credentials verified against database), then create a new login session.
            if (authenticated)
            {
                // Check for existing session
                var userSessionService = new UserSessionService();
                var userSession = userSessionService.GetUserSessionByUserId(user.UserId);

                // Return the existing session if it exists (do not create a new one)
                if (userSession != null)
                {
                    return userSession;
                }

                // If there is no existing user session, create the new user session
                var newSession = userSessionService.CreateNewSession(user);
                return newSession;
            }

            // If the authentication fails, return a null user session.
            else
            {
                return nullSession;
            }

            
        }
    }
}