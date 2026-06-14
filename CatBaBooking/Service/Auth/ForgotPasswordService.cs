using CatBaBooking.Models;
using CatBaBooking.Service.Interface.Auth;
using CatBaBooking.Utils;
using Microsoft.EntityFrameworkCore;

namespace CatBaBooking.Service;

public class ForgotPasswordService : IForgotPasswordService
{
    private readonly CatBaBookingContext con;
    private readonly IEmailService emailService;

    public ForgotPasswordService(CatBaBookingContext con, IEmailService emailService)
    {
        this.con = con;
        this.emailService = emailService;
    }

    public async Task<string> SendOTPAsync(string email)
    {
        var user = await con.Users.FirstOrDefaultAsync(x=>x.Email == email && x.Status == "active");
        if (user == null) return null;
        string otp = new Random().Next(100000, 999999).ToString();
        await emailService.EmailAsync(email, otp);
        return otp;
    }

    public async Task<bool> ResetPasswordAsync(string email, string newPassword)
    {
        var user = await con.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user == null) return false;
        user.PasswordHash = PasswordUtils.HashPassword(newPassword);
        user.UpdatedAt = DateTime.Now;
        await con.SaveChangesAsync();
        return true;
    }
}