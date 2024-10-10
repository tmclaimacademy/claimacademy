using AccessBasedWebApp.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace AccessBasedWebApp.Repositories
{
    public class UserRepository
    {
        private string _connectionString = "Server=localhost; Database=WebApp; Integrated Security=True; Encrypt=False;";
        
        public void SaveCredentials(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO dbo.Users (UserName, PasswordHash) VALUES (@UserName, @PasswordHash);";

                var parameters = new { UserName = user.UserName, PasswordHash = user.PasswordHash };

                connection.Open();
                connection.Execute(sql, parameters);
            }
        }

        public User GetUser(string username)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM dbo.Users WHERE UserName = @UserName";

                // QuerySingleOrDefault returns null if no record is found, avoids exceptions
                return connection.QuerySingleOrDefault<User>(sql, new { UserName = username });
            }
        }
    }
}
