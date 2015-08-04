namespace EmailAddressValidation
{
    using ReferenceSource.System.Net.Mail;
    using System;

    public static class EmailAddressValidator
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
