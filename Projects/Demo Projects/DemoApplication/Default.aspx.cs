using DemoApplication.Services;
using System;
using System.Drawing;
using System.Web;
using System.Web.UI;

namespace SimpleWebFormsApp
{
    // Default.aspx: This page loads after login, or if a valid user session is not present.
    public partial class Default : Page
    {
        // Page_Load method always runs when the page is invoked
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Session ID from URL
            var sessionID = Request.QueryString["sessionID"].Trim();

            // Hide Logout Button by default, logout button should only appear for a valid logged in session
            Logout.Visible = false;

            // Determine if the user is logged in

            // Get a current user session from the database for the user
            var userSessionService = new UserSessionService();
            var userService = new UserService();
            var session = userSessionService.GetUserSessionBySessionID(sessionID);
            var user = userService.GetUserByUserId(session.UserId);

            // Check if the session is active

            var isSessionActive = userSessionService.Active(session);

            if (!isSessionActive)
            {
                WelcomeMessage.ForeColor = Color.Red;
                WelcomeMessage.Text = $"Valid Session Not Found";
            }

            else
            {
                WelcomeMessage.Text = $"Welcome {user.UserName}.";
                Logout.Visible = true;
            }
        }

        
        // This method runs when the Logout button is clicked
        protected void Logout_Click(object sender, EventArgs e)
        {
            // Get the session ID from the URL
            var sessionID = Request.QueryString["sessionID"].Trim();

            // Create an instance of the Logout service
            var logoutService = new LogoutService();

            // Log the user out with the active session ID
            logoutService.Logout(sessionID);

            // Redirect back to login page after logout is complete
            Response.Redirect($"Login.aspx?sessionID={sessionID}&logout={true}");
        }
    }
}
