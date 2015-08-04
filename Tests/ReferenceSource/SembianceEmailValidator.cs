namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class ReferenceSource
    {
        [TestMethod]
        public void ValidFromSebianceEmailValidator()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.ReferenceSource.IsValid,
                Examples.SembianceEmailValidator.Valid
            );
        }

        [TestMethod]
        public void InvalidFromSebianceEmailValidator()
        {
            CustomAssert.IsFalse(
                EmailAddressValidator.ReferenceSource.IsValid,
                Examples.SembianceEmailValidator.Invalid,

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
                    @"the-local-part-is-invalid-if-it-is-longer-than-sixty-four-characters@sld.net",@"the-total-length@of-an-entire-address.cannot-be-longer-than-two-hundred-and-fifty-four-characters.and-this-address-is-255-characters-exactly.so-it-should-be-invalid.and-im-going-to-add-some-more-words-here.to-increase-the-lenght-blah-blah-blah-blah-bl.org",
                    @"two..consecutive-dots@sld.com",
                    @"unbracketed-IP@127.0.0.1",
                }

            );
        }
    }
}
