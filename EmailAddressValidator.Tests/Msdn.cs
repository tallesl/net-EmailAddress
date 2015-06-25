namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Examples borrowed from a MSDN page.
    /// (https://msdn.microsoft.com/en-us/library/01escwtf%28v=vs.110%29.aspx)
    /// </summary>
    [TestClass]
    public class Msdn
    {
        [TestMethod]
        public void ValidFromMsdn()
        {
            Assert.IsTrue(EmailAddressValidator.IsValid("\"j\\\"s\\\"\"@proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("d.j@server1.proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("david.jones@proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("j.s@server1.proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("j@proseware.com9"));
            Assert.IsTrue(EmailAddressValidator.IsValid("j_9@[129.126.118.1]"));
            Assert.IsTrue(EmailAddressValidator.IsValid("jones@ms1.proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("js#internal@proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("js@contoso.ä¸­å›½"));
            Assert.IsTrue(EmailAddressValidator.IsValid("js@proseware.com9"));
        }

        [TestMethod]
        public void FalsePositivesFromMsdn()
        {
            Assert.IsTrue(EmailAddressValidator.IsValid("j..s@proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("j.@server1.proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("js*@proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("js@proseware..com"));
        }
    }
}
