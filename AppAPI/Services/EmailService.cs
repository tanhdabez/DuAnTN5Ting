using System.Net.Mail;
using System.Net;
using AppData.ViewModels.QLND;
using AppAPI.IServices;

namespace AppAPI.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendForgotPasswordConfirmation(ForgotPasswordRequest forgot)
        {
            // Create an instance of SmtpClient
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
<<<<<<< HEAD
            smtpClient.Credentials = new NetworkCredential("5tingclothes@gmail.com", "phamtuananh123.");

            // Create an instance of MailMessage
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("5tingclothes@gmail.com");
=======
            smtpClient.Credentials = new NetworkCredential("nhuph20156@gmail.com", "Nhucong2003.");

            // Create an instance of MailMessage
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("nhuph20156@gmail.com");
>>>>>>> b6cef1a2f35980402036641f65579444d10644ff
            mailMessage.To.Add(new MailAddress(forgot.Email));
            mailMessage.Subject = "Reset Password";
            mailMessage.Body = "Please click the link below to reset your password:<br><a href='https://localhost:7095/api/ResetPassword?email=" + forgot.Email + "&token=" + forgot.Token + "'>Reset Password</a>";

            // Send the email
            await smtpClient.SendMailAsync(mailMessage);
            mailMessage.Dispose();
        }
    }
}
