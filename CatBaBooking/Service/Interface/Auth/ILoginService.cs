using CatBaBooking.Models;

namespace CatBaBooking.Service.Interface.Auth;

public interface ILoginService
{
    Task<User> LoginAsync(string email, string password);
}