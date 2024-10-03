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
            if (string.IsNullOrEmpty(email.EmailAddress) || string.IsNullOrEmpty(email.Subject) || string.IsNullOrEmpty(email.Body))
            {
                return BadRequest(new { error = "All fields (to, subject, body) are required." });
            }

            if (!IsValidEmail(email.EmailAddress))
            {
                return BadRequest(new { error = "\"EmailAddress\" E-mail address is not in correct e-mail address format." });
            }

            try
            {
                var smtpPassword = System.IO.File.ReadAllText("C:\\Users\\Tavish\\Documents\\contactapiapppword.txt").Trim();
                // Set up SMTP client
                var smtpClient = new SmtpClient("smtppro.zoho.com")  // Replace with your SMTP server
                {
                    Port = 587,                                       // Replace with your SMTP port
                    Credentials = new NetworkCredential("no-reply@tavicole.net", smtpPassword),  // Replace with your email credentials
                    EnableSsl = true,                                 // Set to true if your SMTP server requires SSL
                };

                // Send the message to the website owner, once that is successful, then send a confirmation to the website visitor
                // Build the message body without using a StringBuilder (as StringBuilder takes extra memory)
                string messageBody = string.Empty;
                var utcNow = DateTime.UtcNow;
                messageBody += $"You have a new message from {email.Name} ({email.EmailAddress}) that was sent at {utcNow}.{Environment.NewLine}{Environment.NewLine}";
                messageBody += $"Message: {Environment.NewLine}{Environment.NewLine}";
                messageBody += email.Body;

                // Define the email message
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("no-reply@tavicole.net", "New Contact Form Submission"),  // Replace with your email
                    Subject = email.Subject,
                    ReplyTo = new MailAddress(email.EmailAddress),
                    Body = messageBody,
                    IsBodyHtml = false,  // Change to true if sending HTML
                };

                // Add recipient email
                mailMessage.To.Add("tavish@tavicole.net");

                // Send email asynchronously
                await smtpClient.SendMailAsync(mailMessage);

                // Pause 1 second between message sends to avoid a time-based block for sending messages too quickly
                Thread.Sleep(1000);

                // Build and send the confirmation email to the website visitor
                messageBody = string.Empty;
                messageBody += $"Thank you for contacting Tavish Misra. A copy of your message is below: {Environment.NewLine}{Environment.NewLine}";
                messageBody += $"Your Name: {email.Name}{Environment.NewLine}";
                messageBody += $"Your Email: {email.EmailAddress}{Environment.NewLine}";
                messageBody += $"Subject: {email.Subject}{Environment.NewLine}";
                messageBody += $"Date: {utcNow}{Environment.NewLine}";
                messageBody += $"Message: {Environment.NewLine}{Environment.NewLine}{email.Body}{Environment.NewLine}{Environment.NewLine}";
                messageBody += "Please do not reply to this email as there is no mailbox associated with this email address. You will receive a response to your message within 24-48 hours.";

                // Define the email message
                mailMessage = new MailMessage
                {
                    From = new MailAddress("no-reply@tavicole.net", "Your website message has been received"),  // Replace with your email
                    Subject = email.Subject,
                    Body = messageBody,
                    IsBodyHtml = false,  // Change to true if sending HTML
                };

                // Add recipient email
                mailMessage.To.Add(email.EmailAddress);

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
