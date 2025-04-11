using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CommonLib.Other.PasswordHasher;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16; // 128 бит
    private const int KeySize = 32;  // 256 бит
    private const int Iterations = 100_000; // количество итераций

    public string HashPassword(string password)
    {
        using var rng = RandomNumberGenerator.Create();
        byte[] salt = new byte[SaltSize];
        rng.GetBytes(salt);

        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        byte[] key = pbkdf2.GetBytes(KeySize);

        var hashBytes = new byte[SaltSize + KeySize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(key, 0, hashBytes, SaltSize, KeySize);

        return Convert.ToBase64String(hashBytes);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        byte[] hashBytes = Convert.FromBase64String(hashedPassword);

        byte[] salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        byte[] key = pbkdf2.GetBytes(KeySize);

        for (int i = 0; i < KeySize; i++)
        {
            if (hashBytes[i + SaltSize] != key[i])
                return false;
        }

        return true;
    }
}