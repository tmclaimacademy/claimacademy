using DemoApplication.Models;
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

            

            // Create a new cryptography service
            var cryptoService = new CryptoService();

            // Create a new registration service
            var registrationService = new RegistrationService();

            // Take the username, password, and repeat password for verification
            var username = Username.Text.Trim();
            var password = Password.Text.Trim();
            var repeatPassword = RepeatPassword.Text.Trim();

            // Verify password requirements are met
            var errorList = registrationService.VerifyRegistrationRequirements(username, password);

            // Make a bulleted list of errors if there are errors
            if (errorList.Any())
            {
                PasswordErrors.ForeColor = Color.Red;
                PasswordErrors.DataSource = errorList;
                PasswordErrors.DataBind();
                return; // Stop running rest of code if there are password errors
            }

            // If all the password requirements are good, then clear them from the page
            PasswordErrors.Visible = false;

            // If the password requirements are met, hash the password and the repeat password, compare the hashes
            var hashedPassword = cryptoService.HashPassword(password);
            var passwordsMatch = cryptoService.VerifyPassword(repeatPassword, hashedPassword);

            // Check if the passwords match
            if (passwordsMatch)
            {
                // If the passwords match, register the user in the database
                var result = registrationService.RegisterUser
                    (
                        new User
                        {
                            UserName = username,
                            PasswordHash = hashedPassword
                        }
                    );

                // If the database registration operation is successful, say registration successful, else give the error
                if (result == "Registration Successful!")
                {
                    RegistrationResult.ForeColor = Color.Green;
                    RegistrationResult.Text = result;
                    Register.Enabled = false;
                }

                else
                {
                    RegistrationResult.ForeColor = Color.Red;
                    RegistrationResult.Text = result;
                }
               
            }

            else
            {
                RegistrationResult.ForeColor = Color.Red;
                RegistrationResult.Text = "Passwords Do Not Match!";
            }
        }
    }
}