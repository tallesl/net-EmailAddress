namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Examples from issue #1.
    /// (https://github.com/tallesl/EmailAddressValidator/issues/1)
    /// </summary>
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
