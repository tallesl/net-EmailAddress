namespace EmailAddressValidation
{
    using ReferenceSource.System.Net.Mail;
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
    }
}
