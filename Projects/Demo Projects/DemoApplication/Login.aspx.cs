using DemoApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            // Take the username, and the password
            // Find the user in the database, if the user doesn't exist, return error User Not Found
            // If user exists, check the password
            // If the password matches, then login

            var username = Username.Text.Trim();
            var password = Password.Text.Trim();
            var loginService = new LoginService();

            // Check if user exists
            if (!loginService.FindUser(username))
            {
                ErrorLabel.Text = $"User {username} not found in system.";
            }

            // If the user exists, attempt a login

            var user = loginService.Login(username, password);

            if (user == null)
            {
                LoginLabel.Text = "Bad Username or Password";
            }

            else
            {
                Response.Redirect($"Default.aspx?userId={user.UserId}");
            }


        }
    }
}