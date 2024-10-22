using Dapper;
using DemoApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoApplication.Repositories
{
    public class UserSessionRepository
    {
        private string _connectionString = "Server=localhost; Database=WebApp; Integrated Security=True; Encrypt=False;";

        public void CreateNewSession(UserSession userSession)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO dbo.UserSessions (SessionId, UserId, IsActive, LastActivityDateTime) VALUES (@SessionId, @UserId, @IsActive, CURRENT_TIMESTAMP);";

                var parameters = new { SessionId = userSession.SessionID, UserId = userSession.UserId, IsActive = userSession.IsActive };

                connection.Open();
                connection.Execute(sql, parameters);
            }
        }

        public UserSession GetUserSession(string sessionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM dbo.UserSessions WHERE SessionID = @sessionId";

                // QuerySingleOrDefault returns null if no record is found, avoids exceptions
                return connection.QuerySingleOrDefault<UserSession>(sql, new { sessionId = sessionId });
            }
        }
    }
}