using CatBaBooking.Models;
using CatBaBooking.Service.Interface.Auth;
using MailKit.Net.Smtp;
using MimeKit;

namespace CatBaBooking.Service;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<bool> EmailAsync(string email, string otp)
    {
        try
        {
            var smtpServer = _config["EmailSettings:SmtpServer"] ?? "smtp.gmail.com";
            var port = int.Parse(_config["EmailSettings:Port"] ?? "587");
            var fromEmail = _config["EmailSettings:FromEmail"] ?? "catbabooking.fms@gmail.com";
            var appPassword = _config["EmailSettings:AppPassword"] ?? "bzsnvnkpjodfwdvx";

            var mess = new MimeMessage();
            mess.From.Add(new MailboxAddress("Hệ Thống Web CatBaBooking", fromEmail));
            mess.To.Add(new MailboxAddress("", email));
            mess.Subject = "Mã OTP khôi phục mật khẩu của bạn";
            
            mess.Body = new TextPart("html")
            {
                Text = $"<h3>Mã OTP của bạn là: <b style='color:blue; font-size:24px;'>{otp}</b></h3>" +
                       $"<p>Mã này có hiệu lực trong vòng 5 phút. Vui lòng không chia sẻ mã này cho bất kỳ ai.</p>"
            };

            using var client = new SmtpClient(); 
            await client.ConnectAsync(smtpServer, port, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(fromEmail, appPassword);
            await client.SendAsync(mess);
            await client.DisconnectAsync(true);

            return true;
        }
        catch (Exception)
        {
            return false; 
        }
    }
}