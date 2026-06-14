namespace CatBaBooking.Service.Interface.Auth;

public interface IForgotPasswordService
{
    Task<string> SendOTPAsync(string email);
    Task<bool> ResetPasswordAsync(string email, string newPassword);
}