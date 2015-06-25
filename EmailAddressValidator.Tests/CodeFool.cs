namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Examples borrowed from the CodeFool blog.
    /// (http://codefool.tumblr.com/post/15288874550/list-of-valid-and-invalid-email-addresses)
    /// </summary>
    [TestClass]
    public class CodeFool
    {
        [TestMethod]
        public void ValidFromCodeFool()
        {
            Assert.IsTrue(EmailAddressValidator.IsValid("1234567890@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("_______@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@123.123.123.123"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@[123.123.123.123]"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@example-one.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@example.co.jp"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@example.museum"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@example.name"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@subdomain.example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("firstname+lastname@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("firstname-lastname@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("firstname.lastname@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("“email”@example.com"));
        }

        [TestMethod]
        public void InvalidFromCodeFool()
        {
            Assert.IsFalse(EmailAddressValidator.IsValid("#@%^%#$@#$@#.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid(".email@example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("@example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("email.example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("email@example@example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("just\"not\"right@example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("plainaddress"));
            Assert.IsFalse(EmailAddressValidator.IsValid("this\\ is\"really\"not\\allowed@example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("“(),:;<>[\\]@example.com"));
        }

        [TestMethod]
        public void FalseNegativesFromCodeFool()
        {
            Assert.IsFalse(EmailAddressValidator.IsValid("much.“more\\ unusual”@example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("very.unusual.“@”.unusual.com@example.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("very.“(),:;<>[]”.VERY.“very@\\\\ \"very”.unusual@strange.example.com"));
        }

        [TestMethod]
        public void FalsePositivesFromCodeFool()
        {
            Assert.IsTrue(EmailAddressValidator.IsValid("Abc..123@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("Joe Smith <email@example.com>"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email..email@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email.@example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@-example.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@111.222.333.44444"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@example"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@example..com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@example.com (Joe Smith)"));
            Assert.IsTrue(EmailAddressValidator.IsValid("email@example.web"));
            Assert.IsTrue(EmailAddressValidator.IsValid("あいうえお@example.com"));
        }
    }
}
