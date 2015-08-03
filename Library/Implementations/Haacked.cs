namespace EmailAddressValidation.Implementations
{
    using System.Text.RegularExpressions;

    internal static class HaackedRegex
    {
        public static readonly Regex Regex = new Regex(
            @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$",
            RegexOptions.IgnoreCase);
    }
}
