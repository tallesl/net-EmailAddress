namespace EmailAddressLibrary.Tests.Wikipedia
{
    using System.Collections.Generic;

    /// <summary>
    /// Examples borrowed from Wikipedia.
    /// https://en.wikipedia.org/wiki/Email_address#Examples
    /// </summary>
    internal static partial class Examples
    {
        internal static IEnumerable<string> Valid =
            new[]
            {
                @""" ""@example.org",
                @"""()<>[]:,;@\""!#$%&'*+-/=?^_`{}| ~.a""@example.org",
                @"""much.more unusual""@example.com",
                @"""very.(),:;<>[]\"".VERY.\""very@\ \""very\"".unusual""@strange.example.com",
                @"""very.unusual.@.unusual.com""@example.com",
                @"#!$%&'*+-/=?^_`{}|~@example.org",
                @"a.little.lengthy.but.fine@dept.example.com",
                @"admin@mailserver1",
                @"disposable.style.email.with+symbol@example.com",
                @"niceandsimple@example.com",
                @"other.email-with-dash@example.com",
                @"very.common@example.com",
                @"üñîçøðé@example.com",
                @"üñîçøðé@üñîçøðé.com",
            };

        internal static IEnumerable<string> Invalid =
            new[]
            {
                @"Abc.example.com",
                @"A@b@c@example.com",
                @"a""b(c)d,e:f;gi[j\k]l@example.com",
                @"just""not""right@example.com",
                @"this is""not\allowed@example.com",
                @"this\ still\""not\allowed@example.com",
                @"john..doe@example.com",
                @"john.doe@example..com",
                @" john.doe@example.com",
                @"john.doe@example.com ",
                @"abc",
            };
    }
}
