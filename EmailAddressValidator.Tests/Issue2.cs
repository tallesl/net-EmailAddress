namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Examples from issue #2.
    /// (https://github.com/tallesl/EmailAddressValidator/issues/2)
    /// </summary>
    [TestClass]
    public class Issue2
    {
        [TestMethod]
        public void FalsePositivesFromIssue2()
        {
            Assert.IsTrue(EmailAddressValidator.IsValid("fooé@bar.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("fooée@bar.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("con@firm.ed."));
            Assert.IsTrue(EmailAddressValidator.IsValid("con@firm.ed..."));
            Assert.IsTrue(EmailAddressValidator.IsValid("con@firm.ed.++"));
            Assert.IsTrue(EmailAddressValidator.IsValid("con@firm.ed---"));
            Assert.IsTrue(EmailAddressValidator.IsValid("con@firm.ed--///***-test"));
        }
    }
}
