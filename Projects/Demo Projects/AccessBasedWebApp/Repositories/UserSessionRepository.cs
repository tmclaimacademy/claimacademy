using AccessBasedWebApp.Models;
using Dapper;
using System.Data.SqlClient;

namespace AccessBasedWebApp.Repositories
{
    public class UserSessionRepository
    {
        private string _connectionString = "Server=localhost; Database=WebApp; Integrated Security=True; Encrypt=False;";

        public void CreateNewSession(UserSession userSession)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO dbo.UserSession (SessionId, UserId, IsActive, LastActivityDateTime) VALUES (@SessionId, @UserId, @IsActive, CURRENT_TIMESTAMP);";

                var parameters = new { SessionId = userSession.SessionID, UserId = userSession.UserId, userSession.IsActive };

                connection.Open();
                connection.Execute(sql, parameters);
            }
        }
    }
}
