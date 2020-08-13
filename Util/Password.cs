using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WebAPI.Util
{
    public class Password
    {
        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // four cores
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024; // 1 GB

            return argon2.GetBytes(16);
        }

        public bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }

        public string CreateSecurePassword(string password)
        {
            var salt = CreateSalt();
            var hash = HashPassword(password, salt);
            
            var saltString = Convert.ToBase64String(salt);
            var hashString = Convert.ToBase64String(hash);

            //var saltBytes2 = Convert.FromBase64String(saltString);

            return saltString + ".." + hashString;
        }
    }
}
