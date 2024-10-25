using DemoApplication.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            // Include this logic to check whether we are logging in for the first time or if we are logging out
            // If we are logging out, there will be query parameters in the URL, if we are logging in for first time, there will not be

            if (Request.QueryString.Count > 0)
            {
                // Populate the logout message
                LogoutMessage.Text = "Logged out";
            }
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

            // Attempt a login with the user
            var user = loginService.Login(username, password);

            // If null is returned by Login method from LoginService, then the login did not succeed
            if (user == null)
            {
                LoginLabel.ForeColor = Color.Red;
                LoginLabel.Text = "Bad Username or Password";
            }

            // Otherwise, if we successfully logged in, then go to the default page with the user info.
            else
            {
                Response.Redirect($"Default.aspx?sessionID={user.SessionID}");
            }
        }
    }
}