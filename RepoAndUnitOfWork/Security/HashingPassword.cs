using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Security
{
    public sealed class HashingPassword
    {
        const int SaltSize = 16;
        const int HashSize = 20;
        const int HashIter = 10000;
        /// <summary>
        /// Two arrays that are read only and cant be set;
        /// </summary>
        private byte[] salt;
        private byte[] hash;
        /// <summary>
        /// A constructor that takes a password and set values to the password salt and hashes it.
        /// </summary>
        /// <param name="password"></param>
        public HashingPassword(string password)
        {
            //Fyller en array(salt) med random värden. 
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);
            //Skapar en instans av Rfc2898DeriveBytes klassen och hämtar hash värdet.
            hash = new Rfc2898DeriveBytes(password, salt, HashIter).GetBytes(HashSize);
        }
        /// <summary>
        /// Second constructor that takes one argument. This takes the two arrays salt and hash and puts inside hashBytes array. This breaks up the stored password 
        /// </summary>
        /// <param name="hashBytes"></param>
        public HashingPassword(byte[] hashBytes)
        {
            Array.Copy(hashBytes, 0, salt = new byte[SaltSize], 0, SaltSize);
            Array.Copy(hashBytes, SaltSize, hash = new byte[HashSize], 0, HashSize);
        }
        /// <summary>
        /// Method that combines the salt and hash to the hashBytes array to be sent in to database
        /// </summary>
        /// <returns></returns>
        public byte[] PasswordToArray()
        {
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return hashBytes;
        }
        /// <summary>
        /// A method that checks the incoming password is the same as the one that was sent in with the second constructor
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool VerifyPassword(string password)
        {
            byte[] pass = new Rfc2898DeriveBytes(password, salt, HashIter).GetBytes(HashSize);
            for (int i = 0; i < HashSize; i++)
            {
                if (pass[i] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
