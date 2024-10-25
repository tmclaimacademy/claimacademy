using DemoApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Services
{
    public class LogoutService
    {
        public LogoutService() 
        {
            
        }

        public void Logout(string sessionID)
        {
            var userSessionRepository = new UserSessionRepository();

            // Set the active state for the session to false, which will signify a logout.
            userSessionRepository.ModifyExistingSession(sessionID, false);
        }
    }
}