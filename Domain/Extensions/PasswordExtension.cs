using System.Security.Cryptography;

namespace Domain.Extensions;

public static class PasswordExtension
{
    private const int SaltSize = 16; // 128-bit salt
    private const int HashSize = 32; // 256-bit hash
    private const int Iterations = 10000; // PBKDF2 iterations

    /// <summary>
    /// Generates a hashed password with a unique salt.
    /// </summary>
    /// <param name="password">The plaintext password.</param>
    /// <returns>The hashed password as a string (salt + hash).</returns>
    public static string HashPassword(this string password)
    {
        // Generate a unique salt
        byte[] salt = GenerateSalt();

        // Hash the password using PBKDF2
        byte[] hash = HashPasswordWithSalt(password, salt);

        // Combine salt and hash
        byte[] saltAndHash = new byte[salt.Length + hash.Length];
        Array.Copy(salt, 0, saltAndHash, 0, salt.Length);
        Array.Copy(hash, 0, saltAndHash, salt.Length, hash.Length);

        // Return as Base64 string
        return Convert.ToBase64String(saltAndHash);
    }

    /// <summary>
    /// Verifies a plaintext password against the hashed password.
    /// </summary>
    /// <param name="password">The plaintext password.</param>
    /// <param name="hashedPassword">The stored hashed password.</param>
    /// <returns>True if the password is valid; otherwise, false.</returns>
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Decode the Base64 encoded hash
        byte[] saltAndHash = Convert.FromBase64String(hashedPassword);

        // Extract the salt (first 16 bytes)
        byte[] salt = new byte[SaltSize];
        Array.Copy(saltAndHash, 0, salt, 0, SaltSize);

        // Extract the hash (remaining bytes)
        byte[] storedHash = new byte[HashSize];
        Array.Copy(saltAndHash, SaltSize, storedHash, 0, HashSize);

        // Hash the provided password with the extracted salt
        byte[] computedHash = HashPasswordWithSalt(password, salt);

        // Compare the stored hash and the computed hash
        return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
    }

    /// <summary>
    /// Generates a random salt.
    /// </summary>
    /// <returns>A byte array containing the salt.</returns>
    private static byte[] GenerateSalt()
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] salt = new byte[SaltSize];
            rng.GetBytes(salt);
            return salt;
        }
    }

    /// <summary>
    /// Hashes a password with a given salt using PBKDF2.
    /// </summary>
    /// <param name="password">The plaintext password.</param>
    /// <param name="salt">The salt.</param>
    /// <returns>The hashed password as a byte array.</returns>
    private static byte[] HashPasswordWithSalt(string password, byte[] salt)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
        {
            return pbkdf2.GetBytes(HashSize);
        }
    }
}