using System.Text.RegularExpressions;

namespace CatBaBooking.Utils;

public static class PasswordUtils
{
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string password, string hashPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashPassword);
    }
    
    public static bool IsStrongPassword(string password)
    {
        if (string.IsNullOrEmpty(password)) 
            return false;
        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$";
        return Regex.IsMatch(password, pattern);
    }
}