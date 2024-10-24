using DemoApplication.Models;
using DemoApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApplication.Services
{
    // User Service to deal with User functions
    public class UserService
    {
        // Default Constructor
        public UserService() 
        {
            
        }

        public User GetUserByUsername(string username)
        {
            var userRepository = new UserRepository();
            return userRepository.GetUserByUsername(username);
        }

        public User GetUserByUserId(int userId)
        {
            var userRepository = new UserRepository();
            return userRepository.GetUserByUserId(userId);
        }

        public void AddUser(User user)
        {
            var userRepository = new UserRepository();
            userRepository.SaveUser(user);
        }
    }
}