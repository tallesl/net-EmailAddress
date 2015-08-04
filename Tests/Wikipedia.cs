namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Examples borrowed from Wikipedia (2015-06-25).
    /// (https://en.wikipedia.org/wiki/Email_address#Examples)
    /// </summary>
    [TestClass]
    public class Wikipedia
    {
        [TestMethod]
        public void ValidFromWikipedia()
        {
            Assert.IsTrue(EmailAddressValidator.IsValid("\" \"@example.org"));
            Assert.IsTrue(EmailAddressValidator.IsValid("\"()<>[]:,;@\\\"!#$%&'*+-/=?^_`{}| ~.a\"@example.org"));
            Assert.IsTrue(EmailAddressValidator.IsValid("\"much.more unusual\"@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("\"very.(),:;<>[]\\\".VERY.\\\"very@\\\\ \\\"very\\\".unusual\"@strange.example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("\"very.unusual.@.unusual.com\"@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("#!$%&'*+-/=?^_`{}|~@example.org"));
            Assert.IsTrue(EmailAddressValidator.IsValid("a.little.lengthy.but.fine@dept.example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("admin@mailserver1"));
            Assert.IsTrue(EmailAddressValidator.IsValid("disposable.style.email.with+symbol@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("niceandsimple@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("other.email-with-dash@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("very.common@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("üñîçøðé@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("üñîçøðé@üñîçøðé.com"));
        }

        [TestMethod]
        public void InvalidFromWikipedia()
        {
            Assert.IsFalse(EmailAddressValidator.IsValid("A@b@c@example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("Abc.example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("a\"b(c)d,e:f;g<h>i[j\\k]l@example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("abc"));
            Assert.IsFalse(EmailAddressValidator.IsValid("just\"not\"right@example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("this is\"not\\allowed@example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("this\\ still\\\"not\\\\allowed@example.com"));
        }

        [TestMethod]
        public void FalsePositivesFromWikipedia()
        {
            Assert.IsTrue(EmailAddressValidator.IsValid(" john.doe@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("john..doe@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("john.doe@example..com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("john.doe@example.com "));
        }
    }
}
