namespace EmailAddressLibrary
{
    using EmailAddressLibrary.Implementations;
    using EmailAddressLibrary.Implementations.ReferenceSource.System.Net.Mail;
    using System;

    public static class EmailAddressValidator
    {
        /// <summary>
        /// Checks if the given email address is valid using MSDN implementation.
        /// https://msdn.microsoft.com/library/01escwtf%28v=vs.100%29.aspx
        /// </summary>
        /// <param name="address">Email address to check</param>
        /// <returns>True if the given email address is valid, false otherwise</returns>
        public static bool Msdn(string address)
        {
            return RegexUtilities.IsValidEmail(address);
        }

        /// <summary>
        /// Checks if the given email address is valid using Reference Source implementation.
        /// http://referencesource.microsoft.com
        /// </summary>
        /// <param name="address">Email address to check</param>
        /// <returns>True if the given email address is valid, false otherwise</returns>
        public static bool ReferenceSource(string address)
        {
            try
            {
                MailAddressParser.ParseAddress(address);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the given email address is valid using Phil Haack's implementation.
        /// http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
        /// </summary>
        /// <param name="address">Email address to check</param>
        /// <returns>True if the given email address is valid, false otherwise</returns>
        public static bool Haacked(string address)
        {
            return HaackedRegex.Regex.IsMatch(address);
        }
    }
}
