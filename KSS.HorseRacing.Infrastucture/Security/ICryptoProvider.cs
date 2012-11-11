namespace KSS.HorseRacing.Infrastucture.Security
{
    using KSS.HorseRacing.Infrastucture.DataModels;

    /// <summary>
    /// The CryptoProvider interface.
    /// </summary>
    public interface ICryptoProvider
    {
        /// <summary>
        /// Creates the salt.
        /// </summary>
        /// <returns>
        /// The random salt.
        /// </returns>
        string CreateSalt();

        /// <summary>
        /// The create hash.
        /// </summary>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The hash of password.
        /// </returns>
        string CreateHash(string password);

        /// <summary>
        /// The create crypto password.
        /// </summary>
        /// <param name="password">
        /// The user's password.
        /// </param>
        /// <param name="salt">
        /// The user's salt.
        /// </param>
        /// <returns>
        /// The encrypted password.
        /// </returns>
        string CreateCryptoPassword(string password, string salt);

        /// <summary>
        /// The compare password.
        /// </summary>
        /// <param name="user">
        /// The current user.
        /// </param>
        /// <param name="password">
        /// The password to verify.
        /// </param>
        /// <returns>
        /// Is user's password match with <paramref name="password"/>.
        /// </returns>
        bool ComparePassword(User user, string password);
    }
}