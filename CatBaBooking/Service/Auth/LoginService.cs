using CatBaBooking.Models;
using CatBaBooking.Service.Interface.Auth;
using CatBaBooking.Utils;
using Microsoft.EntityFrameworkCore;

namespace CatBaBooking.Service;

public class LoginService : ILoginService
{
    private readonly CatBaBookingContext con;
    public LoginService(CatBaBookingContext con)
    {
        this.con = con;
    }

    public async Task<User> LoginAsync(string email, string password)
    {
        var user = await con.Users
                            .Include(x=> x.Role)
                            .FirstOrDefaultAsync(x => x.Email == email);
        if (user == null || user.Status != "active")
        {
            return null;
        }
        bool isPasswordValid = PasswordUtils.VerifyPassword(password, user.PasswordHash);
        if (!isPasswordValid)
        {
            return null;
        }

        return user;
    }
}