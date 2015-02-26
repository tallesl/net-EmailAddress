using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailAddressValidation.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Valid()
        {
            // The following are examples from the original code itself (https://msdn.microsoft.com/library/01escwtf%28v=vs.100%29.aspx)
            Assert.IsTrue(EmailAddressValidator.IsValid("david.jones@proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("d.j@server1.proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("jones@ms1.proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("js#internal@proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("j_9@[129.126.118.1]"));
            Assert.IsTrue(EmailAddressValidator.IsValid("j.s@server1.proseware.com"));

            // The following were borrowed from Sembiance/email-validator (https://github.com/Sembiance/email-validator/blob/master/test.js)
            Assert.IsTrue(EmailAddressValidator.IsValid("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ@letters-in-local.org"));
            Assert.IsTrue(EmailAddressValidator.IsValid("01234567890@numbers-in-local.net"));
            Assert.IsTrue(EmailAddressValidator.IsValid("mixed-1234-in-{+^}-local@sld.net"));
            Assert.IsTrue(EmailAddressValidator.IsValid("a@single-character-in-local.org"));
            Assert.IsTrue(EmailAddressValidator.IsValid("one-character-third-level@a.example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("single-character-in-sld@x.org"));
            Assert.IsTrue(EmailAddressValidator.IsValid("local@dash-in-sld.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("letters-in-sld@123.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("one-letter-sld@x.org"));
            Assert.IsTrue(EmailAddressValidator.IsValid("uncommon-tld@sld.museum"));
            Assert.IsTrue(EmailAddressValidator.IsValid("uncommon-tld@sld.travel"));
            Assert.IsTrue(EmailAddressValidator.IsValid("uncommon-tld@sld.mobi"));
            Assert.IsTrue(EmailAddressValidator.IsValid("country-code-tld@sld.uk"));
            Assert.IsTrue(EmailAddressValidator.IsValid("country-code-tld@sld.rw"));
            Assert.IsTrue(EmailAddressValidator.IsValid("local@sld.newTLD"));
            Assert.IsTrue(EmailAddressValidator.IsValid("the-total-length@of-an-entire-address.cannot-be-longer-than-two-hundred-and-fifty-four-characters.and-this-address-is-254-characters-exactly.so-it-should-be-valid.and-im-going-to-add-some-more-words-here.to-increase-the-lenght-blah-blah-blah-blah-bla.org"));
            Assert.IsTrue(EmailAddressValidator.IsValid("the-character-limit@for-each-part.of-the-domain.is-sixty-three-characters.this-is-exactly-sixty-three-characters-so-it-is-valid-blah-blah.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("local@sub.domains.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("backticks`are`legit@test.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("\"quoted\"@sld.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("\"\\e\\s\\c\\a\\p\\e\\d\"@sld.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("\"quoted-at-sign@sld.org\"@sld.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("\"back\\slash\"@sld.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("bracketed-IP-instead-of-domain@[127.0.0.1]"));

            // False negatives:
            // • &'*+-./=?^_{}~@other-valid-characters-in-local.net
            // • \"escaped\\\"quote\"@sld.com
            // • punycode-numbers-in-tld@sld.xn--3e0b707e
        }

        [TestMethod]
        public void Invalid()
        {
            // The following are examples from the original code itself (https://msdn.microsoft.com/library/01escwtf%28v=vs.100%29.aspx)
            Assert.IsFalse(EmailAddressValidator.IsValid("j.@server1.proseware.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("j..s@proseware.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("js*@proseware.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("js@proseware..com"));

            // Curiously, there are 2 emails listed as "Invalid" that passes as valid:
            // • j@proseware.com9
            // • js@proseware.com9

            // The following were borrowed from Sembiance/email-validator (https://github.com/Sembiance/email-validator/blob/master/test.js)
            Assert.IsFalse(EmailAddressValidator.IsValid("@missing-local.org"));
            Assert.IsFalse(EmailAddressValidator.IsValid("! #$%`|@invalid-characters-in-local.org"));
            Assert.IsFalse(EmailAddressValidator.IsValid("(),:;`|@more-invalid-characters-in-local.org"));
            Assert.IsFalse(EmailAddressValidator.IsValid("<>@[]\\`|@even-more-invalid-characters-in-local.org"));
            Assert.IsFalse(EmailAddressValidator.IsValid(".local-starts-with-dot@sld.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("local-ends-with-dot.@sld.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("two..consecutive-dots@sld.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("partially.\"quoted\"@sld.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("missing-sld@.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("sld-starts-with-dashsh@-sld.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("invalid-characters-in-sld@! \"#$%(),/;<>_[]`|.org"));
            Assert.IsFalse(EmailAddressValidator.IsValid("missing-dot-before-tld@com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("missing-tld@sld."));
            Assert.IsFalse(EmailAddressValidator.IsValid("invalid"));
            Assert.IsFalse(EmailAddressValidator.IsValid("the-character-limit@for-each-part.of-the-domain.is-sixty-three-characters.this-is-exactly-sixty-four-characters-so-it-is-invalid-blah-blah.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("missing-at-sign.net"));
            Assert.IsFalse(EmailAddressValidator.IsValid("unbracketed-IP@127.0.0.1"));
            Assert.IsFalse(EmailAddressValidator.IsValid("IP-and-port@127.0.0.1:25"));

            // False positives:
            // • the-local-part-is-invalid-if-it-is-longer-than-sixty-four-characters@sld.net
            // • sld-ends-with-dash@sld-.com
            // • the-total-length@of-an-entire-address.cannot-be-longer-than-two-hundred-and-fifty-four-characters.and-this-address-is-255-characters-exactly.so-it-should-be-invalid.and-im-going-to-add-some-more-words-here.to-increase-the-lenght-blah-blah-blah-blah-bl.org
            // • invalid-ip@127.0.0.1.26
            // • another-invalid-ip@127.0.0.256
        }
    }
}
