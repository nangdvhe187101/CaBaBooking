using CatBaBooking.Models;

namespace CatBaBooking.Service.Interface.Auth;

public interface IRegisterOwnerService
{
    Task<User> RegisterOwnerAsync(string email, string password, string fullname,int roleId, string address, string citizen, string phone);
}