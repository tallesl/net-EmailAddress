namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class Msdn
    {
        [TestMethod]
        public void ValidFromSebianceEmailValidator()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.Msdn.IsValid,
                Examples.SembianceEmailValidator.Valid,

                // False negatives:
                new[]
                {
                    @"""escaped\""quote""@sld.com",
                    @"&'*+-./=?^_{}~@other-valid-characters-in-local.net",
                    @"punycode-numbers-in-tld@sld.xn--3e0b707e",
                }
            );
        }

        [TestMethod]
        public void InvalidFromSebianceEmailValidator()
        {
            CustomAssert.IsFalse(
                EmailAddressValidator.Msdn.IsValid,
                Examples.SembianceEmailValidator.Invalid,

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
    }
}
