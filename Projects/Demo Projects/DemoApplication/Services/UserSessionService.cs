using DemoApplication.Models;
using DemoApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Services
{
    // User Session Service to manage UserSessions
    public class UserSessionService
    {
        // Default Constructor
        public UserSessionService() 
        {
            
        }

        // Check if a session is still active
        public bool Active(UserSession userSession)
        {

            /*
             * Requirements for a session that is no longer active:
             * 1. It has been more than 15 minutes since the last activity OR
             * 2. The isActive indicator is false
             */
            var isActive = (DateTime.Now - userSession.LastActivityDateTime).TotalMinutes < 15 && userSession.IsActive == true;
            return isActive;
        }

        public UserSession CreateNewSession(User user)
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

            var userSessionRepository = new UserSessionRepository();
            newSession = userSessionRepository.CreateNewSession(newSession);
            return newSession;
        }

        public UserSession GetUserSessionBySessionID(string sessionId)
        {
            var userSessionRepository = new UserSessionRepository();
            return userSessionRepository.GetUserSessionBySessionID(sessionId);
        }

        public UserSession GetUserSessionByUserId(int userId)
        {
            var userSessionRepository = new UserSessionRepository();
            return userSessionRepository.GetUserSessionByUserId(userId);
        }
    }
}