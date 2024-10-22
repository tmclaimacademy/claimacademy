using Dapper;
using DemoApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoApplication.Repositories
{
    public class UserRepository
    {
        // Connection string tells C# how to connect to the database
        // In a real world application, this string would be in a secrets manager of sorts like AWS Secrets Manager or Vault Enterprise
        private string _connectionString = "Server=localhost; Database=WebApp; Integrated Security=True; Encrypt=False;";

        // These are the repository methods. These are C# methods which run SQL, retrieve the data, and bind to the model that represents the database table.
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