namespace EmailAddressLibrary.Tests.CodeFool
{
    using System.Collections.Generic;

    /// <summary>
    /// Examples borrowed from the CodeFool blog.
    /// http://codefool.tumblr.com/post/15288874550/list-of-valid-and-invalid-email-addresses
    /// </summary>
    internal static class Examples
    {
        internal static IEnumerable<string> Valid =
            new[]
            {
                @"1234567890@example.com",
                @"_______@example.com",
                @"email@123.123.123.123",
                @"email@[123.123.123.123]",
                @"email@example-one.com",
                @"email@example.co.jp",
                @"email@example.com",
                @"email@example.museum",
                @"email@example.name",
                @"email@subdomain.example.com",
                @"firstname+lastname@example.com",
                @"firstname-lastname@example.com",
                @"firstname.lastname@example.com",
                @"much.“more\ unusual”@example.com",
                @"very.unusual.“@”.unusual.com@example.com",
                @"very.“(),:;<>[]”.VERY.“very@\ ""very”.unusual@strange.example.com",
                @"“email”@example.com",
            };

        internal static IEnumerable<string> Invalid =
            new[]
            {
                @"#@%^%#$@#$@#.com",
                @".email@example.com",
                @"@example.com",
                @"Abc..123@example.com",
                @"Joe Smith <email@example.com>",
                @"email..email@example.com",
                @"email.@example.com",
                @"email.example.com",
                @"email@-example.com",
                @"email@111.222.333.44444",
                @"email@example",
                @"email@example..com",
                @"email@example.com (Joe Smith)",
                @"email@example.web",
                @"email@example@example.com",
                @"just""not""right@example.com",
                @"plainaddress",
                @"this\ is""really""not\allowed@example.com",
                @"“(),:;<>[]@example.com",
                @"あいうえお@example.com",
            };
    }
}
