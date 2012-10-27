namespace KSS.HorseRacing.Infrastucture.Security
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    using KSS.HorseRacing.Infrastucture.DataModels;

    /// <summary>
    /// The crypto provider md5.
    /// </summary>
    public class CryptoProviderMd5 : ICryptoProvider
    {
        /// <summary>
        /// Creates the salt.
        /// </summary>
        /// <returns>
        /// The random salt.
        /// </returns>
        public string CreateSalt()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// The create hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The hash of password.
        /// </returns>
        public string CreateHash(string password)
        {
            var md5 = MD5.Create();
            var encoding = Encoding.UTF8;
            return Convert.ToBase64String(md5.ComputeHash(encoding.GetBytes(password)));
        }

        /// <summary>
        /// The create crypto password.
        /// </summary>
        /// <param name="password">The user's password.</param>
        /// <param name="salt">The user's salt.</param>
        /// <returns>
        /// The encrypted password.
        /// </returns>
        public string CreateCryptoPassword(string password, string salt)
        {
            return CreateHash(CreateHash(password) + salt);
        }

        /// <summary>
        /// The compare password.
        /// </summary>
        /// <param name="user">The current user.</param>
        /// <param name="password">The password to verify.</param>
        /// <returns>
        /// Is user's password match with <paramref name="password" />.
        /// </returns>
        public bool ComparePassword(User user, string password)
        {
            return user.Password.PasswordHash == CreateCryptoPassword(password, user.Password.Salt);
        }
    }
}