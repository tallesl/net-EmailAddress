namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Issue1
    {
        [TestMethod]
        public void ValidFromIssue1()
        {
            Assert.IsTrue(EmailAddressValidator.IsValid("fooé@bar.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("fooée@bar.com"));
        }
    }
}
