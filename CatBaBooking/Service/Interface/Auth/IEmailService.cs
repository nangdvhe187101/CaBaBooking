namespace CatBaBooking.Service.Interface.Auth;

public interface IEmailService
{
    Task<bool> EmailAsync(string email, string otp);
}