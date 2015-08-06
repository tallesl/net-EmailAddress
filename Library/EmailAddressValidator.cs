namespace EmailAddressValidation
{
    using EmailAddressValidation.Implementations;
    using EmailAddressValidation.Implementations.ReferenceSource.System.Net.Mail;
    using System;

    public static class EmailAddressValidator
    {
        /// <summary>
        /// MSDN implementation.
        /// https://msdn.microsoft.com/library/01escwtf%28v=vs.100%29.aspx
        /// </summary>
        public static class Msdn
        {
            /// <summary>
            /// Checks if the given email address is valid using MSDN implementation.
            /// </summary>
            /// <param name="address">Email address to check</param>
            /// <returns>True if the given email address is valid, false otherwise</returns>
            public static bool IsValid(string address)
            {
                return RegexUtilities.IsValidEmail(address);
            }
        }

        /// <summary>
        /// Reference Source implementation.
        /// http://referencesource.microsoft.com
        /// </summary>
        public static class ReferenceSource
        {
            /// <summary>
            /// Checks if the given email address is valid using Reference Source implementation.
            /// </summary>
            /// <param name="address">Email address to check</param>
            /// <returns>True if the given email address is valid, false otherwise</returns>
            public static bool IsValid(string address)
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
        }

        /// <summary>
        /// Phil Haack's regex.
        /// http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
        /// </summary>
        public static class Haacked
        {
            /// <summary>
            /// Checks if the given email address is valid using Phil Haack's implementation.
            /// </summary>
            /// <param name="address">Email address to check</param>
            /// <returns>True if the given email address is valid, false otherwise</returns>
            public static bool IsValid(string address)
            {
                return HaackedRegex.Regex.IsMatch(address);
            }
        }
    }
}
