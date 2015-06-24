namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The following are examples from the original code itself.
    /// (https://msdn.microsoft.com/library/01escwtf%28v=vs.100%29.aspx)
    /// </summary>
    [TestClass]
    public class MsdnExample
    {
        [TestMethod]
        public void Valid()
        {
            Assert.IsTrue(EmailAddressValidator.IsValid("david.jones@proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("d.j@server1.proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("jones@ms1.proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("js#internal@proseware.com"));
            Assert.IsTrue(EmailAddressValidator.IsValid("j_9@[129.126.118.1]"));
            Assert.IsTrue(EmailAddressValidator.IsValid("j.s@server1.proseware.com"));
        }

        [TestMethod]
        public void Invalid()
        {
            Assert.IsFalse(EmailAddressValidator.IsValid("j.@server1.proseware.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("j..s@proseware.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("js*@proseware.com"));
            Assert.IsFalse(EmailAddressValidator.IsValid("js@proseware..com"));

            // Curiously, there are 2 emails listed as "Invalid" that passes as valid:
            // • j@proseware.com9
            // • js@proseware.com9
        }
    }
}
