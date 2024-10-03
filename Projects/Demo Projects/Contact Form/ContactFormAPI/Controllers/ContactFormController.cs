using ContactFormAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactFormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] Email email)
        {
            // Validate the request
            if (string.IsNullOrEmpty(email.ReplyTo) || string.IsNullOrEmpty(email.Subject) || string.IsNullOrEmpty(email.Body))
            {
                return BadRequest(new { error = "All fields (to, subject, body) are required." });
            }

            if (!IsValidEmail(email.ReplyTo))
            {
                return BadRequest(new { error = "\"ReplyTo\" E-mail address is not in correct e-mail address format." });
            }

            try
            {
                var smtpPassword = System.IO.File.ReadAllText("C:\\Users\\Tavish\\Documents\\contactapiapppword.txt").Trim();
                // Set up SMTP client
                var smtpClient = new SmtpClient("smtp.example.com")  // Replace with your SMTP server
                {
                    Port = 587,                                       // Replace with your SMTP port
                    Credentials = new NetworkCredential("your-email@example.com", "your-email-password"),  // Replace with your email credentials
                    EnableSsl = true,                                 // Set to true if your SMTP server requires SSL
                };

                // Define the email message
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("tmclaimacademy@gmail.com", "Contact Form Submission"),  // Replace with your email
                    Subject = email.Subject,
                    Body = email.Body,
                    ReplyTo = new MailAddress(email.ReplyTo),
                    IsBodyHtml = false,  // Change to true if sending HTML
                };

                // Add recipient email
                mailMessage.To.Add(email.ReplyTo);

                // Send email asynchronously
                await smtpClient.SendMailAsync(mailMessage);

                // Return success response
                return Ok(new { message = "Email sent successfully" });
            }
            catch (SmtpException smtpEx)
            {
                // Handle SMTP-specific errors
                return StatusCode(500, new { error = "Failed to send email", details = smtpEx.Message });
            }
            catch (System.Exception ex)
            {
                // Handle general errors
                return StatusCode(500, new { error = "An error occurred", details = ex.Message });
            }
        }
        static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Regular expression pattern for validating an email
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Use Regex to validate the email address
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
