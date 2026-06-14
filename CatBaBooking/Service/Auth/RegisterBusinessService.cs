using CatBaBooking.Models;
using CatBaBooking.Service.Interface.Auth;
using Microsoft.EntityFrameworkCore;

namespace CatBaBooking.Service;

public class RegisterBusinessService : IRegisterBusinessService
{
    private readonly CatBaBookingContext con;
    public RegisterBusinessService(CatBaBookingContext con)
    {
        this.con = con;
    }

    public async Task<bool> RegisterBusinessAsync(string name, string address, int ownerId, string type, string description)
    {
        bool checkOwner = await con.Businesses.AnyAsync(x => x.OwnerId == ownerId);
        if (checkOwner)
        {
            return false;
        }

        var newBusinesses = new Business(
            0,
            ownerId,
            name,
            type,
            address,
            description,
            "pending",
            DateTime.Now,
            DateTime.Now);
        await con.Businesses.AddAsync(newBusinesses);
        await con.SaveChangesAsync();
        return true;
    }
}