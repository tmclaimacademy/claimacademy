﻿using AccessBasedWebApp.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace AccessBasedWebApp.Repositories
{
    public class CredentialPairRepository
    {
        private string _connectionString = "Server=localhost; Database=WebApp; Integrated Security=True; Encrypt=False;";
        
        public void SaveCredentials(CredentialPair credentialPair)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO dbo.CredentialPair (UserName, PasswordHash) VALUES (@UserName, @PasswordHash);";

                var parameters = new { UserName = credentialPair.UserName, PasswordHash = credentialPair.PasswordHash };

                connection.Open();
                connection.Execute(sql, parameters);
            }
        }

        public CredentialPair RetrieveCredentials(string username)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM dbo.CredentialPair WHERE UserName = @UserName";

                // QuerySingleOrDefault returns null if no record is found, avoids exceptions
                return connection.QuerySingleOrDefault<CredentialPair>(sql, new { UserName = username });
            }
        }
    }
}
