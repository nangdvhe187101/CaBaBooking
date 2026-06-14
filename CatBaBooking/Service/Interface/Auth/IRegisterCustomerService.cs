using CatBaBooking.Models;

namespace CatBaBooking.Service.Interface.Auth;

public interface IRegisterCustomerService
{
    Task<bool> RegisterCustomerAsync(string email, string password, string fullname,int roleId);
}