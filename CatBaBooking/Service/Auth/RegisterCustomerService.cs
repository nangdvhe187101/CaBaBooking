using CatBaBooking.Models;
using CatBaBooking.Service.Interface.Auth;
using CatBaBooking.Utils;
using Microsoft.EntityFrameworkCore;

namespace CatBaBooking.Service;

public class RegisterCustomerService : IRegisterCustomerService
{
    private readonly CatBaBookingContext con;
    public RegisterCustomerService(CatBaBookingContext con)
    {
        this.con = con;
    }

    public async Task<bool> RegisterCustomerAsync(string email, string password, string fullname, int roleId)
    {
        bool checkemail = await con.Users.AnyAsync(x => x.Email == email);
        if (checkemail)
        {
            return false;
        }

        string hashpassword = PasswordUtils.HashPassword(password);
        var newUser = new User(
            0,
            roleId,
            fullname,
            email,
            hashpassword,
            null,
            null,
            null,
            "active",
            DateTime.Now,
            DateTime.Now);
        await con.Users.AddAsync(newUser);
        await con.SaveChangesAsync();
        return true;
    }
}