using AccessBasedWebApp.Models;
using Dapper;
using System.Data.SqlClient;

namespace AccessBasedWebApp.Repositories
{
    public class BlogRepository
    {
        private string _connectionString = "Server=localhost; Database=WebApp; Integrated Security=True; Encrypt=False;";

        public void CreateBlog(Blog blog)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO dbo.BlogEntries (UserId, BlogCreateDateTime, BlogText) VALUES (@UserId, @BlogCreateDateTime, @BlogText);";

                var parameters = new { UserId = blog.UserId, BlogCreateDateTime = blog.BlogCreateDateTime, BlogText = blog.BlogText };

                connection.Open();
                connection.Execute(sql, parameters);
            }
        }
    }
}
