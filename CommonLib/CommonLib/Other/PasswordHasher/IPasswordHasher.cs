namespace CommonLib.Other.PasswordHasher;

public interface IPasswordHasher
{
    public string HashPassword(string password);
    public bool VerifyPassword(string password, string hashedPassword);
}