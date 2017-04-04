namespace EmailAddressLibrary.Tests.SembianceEmailValidator
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class Tests
    {
        [TestMethod]
        public void MsdnWithSembianceEmailValidator()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.Msdn,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"""escaped\""quote""@sld.com",
                    @"&'*+-./=?^_{}~@other-valid-characters-in-local.net",
                    @"punycode-numbers-in-tld@sld.xn--3e0b707e",
                }
            );

            CustomAssert.IsFalse(
                EmailAddressValidator.Msdn,
                Examples.Invalid,

                // False positives:
                new[]
                {
                    @"another-invalid-ip@127.0.0.1.56",
                    @"another-invalid-ip@127.0.0.256",
                    @"invalid-ip@127.0.0.1.26",
                    @"sld-ends-with-dash@sld-.com",
                    @"the-local-part-is-invalid-if-it-is-longer-than-sixty-four-characters@sld.net",
                    @"the-total-length@of-an-entire-address.cannot-be-longer-than-two-hundred-and-fifty-four-characters.and-this-address-is-255-characters-exactly.so-it-should-be-invalid.and-im-going-to-add-some-more-words-here.to-increase-the-lenght-blah-blah-blah-blah-bl.org",
                }

            );
        }

        [TestMethod]
        public void ReferenceSourceWithSebianceEmailValidator()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.ReferenceSource,
                Examples.Valid
            );

            CustomAssert.IsFalse(
                EmailAddressValidator.ReferenceSource,
                Examples.Invalid,

                // False positives:
                new[]
                {
                    @"! #$%`|@invalid-characters-in-local.org",
                    @"another-invalid-ip@127.0.0.256",
                    @"invalid-ip@127.0.0.1.26",
                    @"local-ends-with-dot.@sld.com",
                    @"missing-dot-before-tld@com",
                    @"missing-tld@sld.",
                    @"partially.""quoted""@sld.com",
                    @"sld-ends-with-dash@sld-.com",
                    @"sld-starts-with-dashsh@-sld.com",
                    @"the-character-limit@for-each-part.of-the-domain.is-sixty-three-characters.this-is-exactly-sixty-four-characters-so-it-is-invalid-blah-blah.com",
                    @"the-local-part-is-invalid-if-it-is-longer-than-sixty-four-characters@sld.net",
                    @"the-total-length@of-an-entire-address.cannot-be-longer-than-two-hundred-and-fifty-four-characters.and-this-address-is-255-characters-exactly.so-it-should-be-invalid.and-im-going-to-add-some-more-words-here.to-increase-the-lenght-blah-blah-blah-blah-bl.org",
                    @"two..consecutive-dots@sld.com",
                    @"unbracketed-IP@127.0.0.1",
                }

            );
        }

        [TestMethod]
        public void HaackedWithSembianceEmailValidator()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.Haacked,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"""\e\s\c\a\p\e\d""@sld.com",
                    @"""back\slash""@sld.com",
                    @"bracketed-IP-instead-of-domain@[127.0.0.1]",
                    @"one-letter-sld@x.org",
                    @"punycode-numbers-in-tld@sld.xn--3e0b707e",
                    @"single-character-in-sld@x.org",
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.Haacked,
                Examples.Invalid,

                // False positives:
                new[]
                {
                    @"@missing-local.org",
                    @"the-character-limit@for-each-part.of-the-domain.is-sixty-three-characters.this-is-exactly-sixty-four-characters-so-it-is-invalid-blah-blah.com",
                    @"the-local-part-is-invalid-if-it-is-longer-than-sixty-four-characters@sld.net",
                    @"the-total-length@of-an-entire-address.cannot-be-longer-than-two-hundred-and-fifty-four-characters.and-this-address-is-255-characters-exactly.so-it-should-be-invalid.and-im-going-to-add-some-more-words-here.to-increase-the-lenght-blah-blah-blah-blah-bl.org",
                }

            );
        }

        [TestMethod]
        public void JStedfastWithSembianceEmailValidator()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.JStedfast,
                Examples.Valid,

                // False negatives:
                new []
                {
                    @"punycode-numbers-in-tld@sld.xn--3e0b707e",
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.JStedfast,
                Examples.Invalid
            );
        }
    }
}
