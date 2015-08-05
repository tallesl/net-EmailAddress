namespace EmailAddressValidation.Tests
{
    using System.Collections.Generic;

    internal static partial class Examples
    {
        /// <summary>
        /// Examples borrowed from the Sembiance/email-validator repository.
        /// (https://github.com/Sembiance/email-validator/blob/8794676fb1ad9f5c92799df48744e651c4cdb237/test.js)
        /// </summary>
        internal static class SembianceEmailValidator
        {
            internal static IEnumerable<string> Valid =
                new[]
                {
                    @"""\e\s\c\a\p\e\d""@sld.com",
                    @"""back\slash""@sld.com",
                    @"""escaped\""quote""@sld.com",
                    @"""quoted""@sld.com",
                    @"""quoted-at-sign@sld.org""@sld.com",
                    @"&'*+-./=?^_{}~@other-valid-characters-in-local.net",
                    @"01234567890@numbers-in-local.net",
                    @"a@single-character-in-local.org",
                    @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@letters-in-local.org",
                    @"backticksarelegit@test.com",
                    @"bracketed-IP-instead-of-domain@[127.0.0.1]",
                    @"country-code-tld@sld.rw",
                    @"country-code-tld@sld.uk",
                    @"letters-in-sld@123.com",
                    @"local@dash-in-sld.com",
                    @"local@sld.newTLD",
                    @"local@sub.domains.com",
                    @"mixed-1234-in-{+^}-local@sld.net",
                    @"one-character-third-level@a.example.com",
                    @"one-letter-sld@x.org",
                    @"punycode-numbers-in-tld@sld.xn--3e0b707e",
                    @"single-character-in-sld@x.org",
                    @"the-character-limit@for-each-part.of-the-domain.is-sixty-three-characters.this-is-exactly-sixty-three-characters-so-it-is-valid-blah-blah.com",
                    @"the-total-length@of-an-entire-address.cannot-be-longer-than-two-hundred-and-fifty-four-characters.and-this-address-is-255-characters-exactly.so-it-should-be-invalid.and-im-going-to-add-some-more-words-here.to-increase-the-lenght-blah-blah-blah-blah-bl.org",
                    @"uncommon-tld@sld.mobi",
                    @"uncommon-tld@sld.museum",
                    @"uncommon-tld@sld.travel",
                };

            internal static IEnumerable<string> Invalid =
                new[]
                {                
                    @"! #$%`|@invalid-characters-in-local.org",
                    @"(),:;`|@more-invalid-characters-in-local.org",
                    @"* .local-starts-with-dot@sld.com",
                    @"<>@[]`|@even-more-invalid-characters-in-local.org",
                    @"@missing-local.org",
                    @"IP-and-port@127.0.0.1:25",
                    @"another-invalid-ip@127.0.0.256",
                    @"invalid",
                    @"invalid-characters-in-sld@! ""#$%(),/;<>_[]`|.org",
                    @"invalid-ip@127.0.0.1.26",
                    @"local-ends-with-dot.@sld.com",
                    @"missing-at-sign.net",
                    @"missing-dot-before-tld@com",
                    @"missing-sld@.com",
                    @"missing-tld@sld.",
                    @"partially.""quoted""@sld.com",
                    @"sld-ends-with-dash@sld-.com",
                    @"sld-starts-with-dashsh@-sld.com",
                    @"the-character-limit@for-each-part.of-the-domain.is-sixty-three-characters.this-is-exactly-sixty-four-characters-so-it-is-invalid-blah-blah.com",
                    @"the-local-part-is-invalid-if-it-is-longer-than-sixty-four-characters@sld.net",
                    @"the-total-length@of-an-entire-address.cannot-be-longer-than-two-hundred-and-fifty-four-characters.and-this-address-is-255-characters-exactly.so-it-should-be-invalid.and-im-going-to-add-some-more-words-here.to-increase-the-lenght-blah-blah-blah-blah-bl.org",
                    @"two..consecutive-dots@sld.com",
                    @"unbracketed-IP@127.0.0.1",
                };
        }
    }
}
