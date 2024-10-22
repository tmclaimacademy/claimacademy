using DemoApplication.Models;
using DemoApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Services
{
    public class LoginService
    {
        public LoginService()
        {

        }

        public bool FindUser(string username)
        {
            var userRepository = new UserRepository();
            var user = userRepository.GetUser(username);

            if (user == null)
            {
                return false;
            }

            else
            {
                return true;
            }

        }

        public User Login(string username, string password)
        {
            var userRepository = new UserRepository();
            var userSessionRepository = new UserSessionRepository();
            var cryptoService = new CryptoService();
            var user = userRepository.GetUser(username);
            var authenticated = cryptoService.VerifyPassword(password, user.PasswordHash);

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
                return user;

            }

            else
            {
                return null;
            }

            
        }
    }
}