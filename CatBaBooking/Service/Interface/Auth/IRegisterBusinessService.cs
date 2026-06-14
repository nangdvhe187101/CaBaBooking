namespace CatBaBooking.Service.Interface.Auth;

public interface IRegisterBusinessService
{
    Task<bool> RegisterBusinessAsync(string name, string address, int ownerId, string type, string description);
}