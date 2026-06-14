using CatBaBooking.Models;
using CatBaBooking.Service.Interface.Auth;
using CatBaBooking.Utils;
using Microsoft.EntityFrameworkCore;

namespace CatBaBooking.Service;

public class RegisterOwnerService : IRegisterOwnerService
{
    private readonly CatBaBookingContext con;
    public  RegisterOwnerService(CatBaBookingContext con)
    {
        this.con = con;
    }

    public async Task<User> RegisterOwnerAsync(string email, string password, string fullname, int roleId, string address,
        string citizen, string phone)
    {
        bool checkemail = await con.Users.AnyAsync(x => x.Email == email);
        if (checkemail)
        {
            return null;
        }

        string hashpassword = PasswordUtils.HashPassword(password);
        var newUser = new User(
            0,
            roleId,
            fullname,
            email,
            hashpassword,
            phone,
            citizen,
            address,
            "pending",
            DateTime.Now,
            DateTime.Now);
        await con.Users.AddAsync(newUser);
        await con.SaveChangesAsync();
        return newUser;
    }
}