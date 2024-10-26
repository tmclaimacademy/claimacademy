using Dapper;
using DemoApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoApplication.Repositories
{
    // Maps dbo.UserSessions table in Database to UserSession model
    public class UserSessionRepository
    {
        private string _connectionString = "Server=localhost; Database=WebApp; Integrated Security=True; Encrypt=False;";

        public UserSession CreateNewSession(UserSession userSession)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO dbo.UserSessions (SessionId, UserId, IsActive, LastActivityDateTime) VALUES (@SessionId, @UserId, @IsActive, CURRENT_TIMESTAMP);";

                var parameters = new { SessionId = userSession.SessionID, userSession.UserId, userSession.IsActive };

                connection.Open();
                connection.Execute(sql, parameters);
            }

            return userSession;
        }

        public void ModifyExistingSession(string sessionId, bool active)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE dbo.UserSessions SET isActive = @isActive, LastActivityDateTime = CURRENT_TIMESTAMP WHERE SessionId = @SessionId;";
                var parameters = new { IsActive = active, SessionId = sessionId };

                connection.Open();
                connection.Execute(sql, parameters);
            }
        }

        public UserSession GetUserSessionBySessionID(string sessionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM dbo.UserSessions WHERE SessionID = @sessionId";

                // QuerySingleOrDefault returns null if no record is found, avoids exceptions
                return connection.QuerySingleOrDefault<UserSession>(sql, new { sessionId });
            }
        }

        public UserSession GetUserSessionByUserId(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM dbo.UserSessions WHERE UserID = @userId AND IsActive = @isActive";

                // QuerySingleOrDefault returns null if no record is found, avoids exceptions
                return connection.QuerySingleOrDefault<UserSession>(sql, new {UserID = userId, IsActive = true});
            }
        }
    }
}