using Dapper;
using DemoApplication.Models;
using System.Data.SqlClient;

// Repository code. These classes contain code which connect to SQL Server and pull data from the database and put it into its respective models
// These repositories are using the Dapper ORM rather than Entity Framework, as Dapper is much more powerful than Entity Framework
// Dapper ORM Website: https://www.learndapper.com/

namespace DemoApplication.Repositories
{
    // User repository --> Maps dbo.Users table in SQL Database to the User model.
    public class UserRepository
    {
        // Connection string tells C# how to connect to the database
        // In a real world application, this string would be in a secrets manager of sorts like AWS Secrets Manager or Vault Enterprise
        private string _connectionString = "Server=localhost; Database=WebApp; Integrated Security=True; Encrypt=False;";

        // These are the repository methods. These are C# methods which run SQL, retrieve the data, and bind to the model that represents the database table.
        public void SaveUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO dbo.Users (UserName, PasswordHash) VALUES (@UserName, @PasswordHash);";

                var parameters = new { UserName = user.UserName, PasswordHash = user.PasswordHash };

                connection.Open();
                connection.Execute(sql, parameters);
            }
        }

        public User GetUserByUsername(string username)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM dbo.Users WHERE UserName = @UserName";

                // QuerySingleOrDefault returns null if no record is found, avoids exceptions
                return connection.QuerySingleOrDefault<User>(sql, new { UserName = username });
            }
        }

        public User GetUserByUserId(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM dbo.Users WHERE UserId = @UserId";

                // QuerySingleOrDefault returns null if no record is found, avoids exceptions
                return connection.QuerySingleOrDefault<User>(sql, new { UserId = userId });
            }
        }
    }
}