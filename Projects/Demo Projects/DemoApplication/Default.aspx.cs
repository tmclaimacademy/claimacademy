using DemoApplication.Services;
using System;
using System.Drawing;
using System.Web;
using System.Web.UI;

namespace SimpleWebFormsApp
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sessionID = Request.QueryString["sessionID"].Trim();

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
            }
        }
    }
}
