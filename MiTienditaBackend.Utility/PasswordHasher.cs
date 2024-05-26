using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MiTienditaBackend.Utility
{
  public class PasswordHasher
  {
    private const int SaltSize = 256 / 8;
    private const int KeySize = 256 / 8;
    private const int Iterations = 10000;
    private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;
    private const string Delimiter = ";";

    public string Hash(string password)
    {
      var RandomSalt = RandomNumberGenerator.GetBytes(SaltSize);
      var Hash = Rfc2898DeriveBytes.Pbkdf2(password, RandomSalt, Iterations, _hashAlgorithmName, SaltSize);

      return string.Join(Delimiter, Convert.ToBase64String(RandomSalt), Convert.ToBase64String(Hash));
    }

    public bool Verify(string passwordHashed, string inputPassword)
    {
      var Elements = passwordHashed.Split(Delimiter);
      var RandomSalt = Convert.FromBase64String(Elements[0]);
      var Hash = Convert.FromBase64String(Elements[1]);

      var HashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, RandomSalt, Iterations, _hashAlgorithmName, KeySize);

      return CryptographicOperations.FixedTimeEquals(Hash, HashInput);
    }

    public int GeneratePassword(int length = 32)
    {
      string Characters = "abcdefghijklmnopqrstuvxyz!@#$%^&*()_+}{?>./'[]-=091756432";
      string SecurePassword = "";
      var Ran = new Random();

      for (int i = 0; i < length; i++)
      {
      }

      return Ran.Next(Characters.Length);
    }
  }
}
