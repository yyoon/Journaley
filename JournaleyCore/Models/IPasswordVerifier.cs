namespace Journaley.Core.Models
{
    /// <summary>
    /// An interface for verifying password.
    /// </summary>
    public interface IPasswordVerifier
    {
        /// <summary>
        /// Verifies if the given password matches with the known password.
        /// </summary>
        /// <param name="inputPassword">The input password.</param>
        /// <returns>
        ///   <c>true</c> if the given password matches; otherwise, <c>false</c>.
        /// </returns>
        bool VerifyPassword(string inputPassword);
    }
}
