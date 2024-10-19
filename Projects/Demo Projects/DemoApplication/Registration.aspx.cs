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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            // When the Register button is clicked, start the process

            // Create a new registration service
            var registrationService = new RegistrationService();

            // Take the username, password, and repeat password for verification
            var username = Username.Text.Trim();
            var password = Password.Text.Trim();
            var repeatPassword = RepeatPassword.Text.Trim();

            // Hash the password and the repeat password, compare the hashes
            var hashedPassword = registrationService.HashPassword(password);
            var passwordsMatch = registrationService.VerifyPassword(repeatPassword, hashedPassword);

            if (passwordsMatch)
            {
                RegistrationResult.Text = "Registration Successful!";
                RegistrationResult.ForeColor = Color.Green;
            }

            else
            {
                RegistrationResult.Text = "Passwords Do Not Match!";
                RegistrationResult.ForeColor = Color.Red;
            }
        }
    }
}