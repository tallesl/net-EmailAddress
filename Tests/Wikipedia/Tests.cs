namespace EmailAddressLibrary.Tests.Wikipedia
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class Tests
    {
        [TestMethod]
        public void MsdnWithWikipedia()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.Msdn,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"""()<>[]:,;@\""!#$%&'*+-/=?^_`{}| ~.a""@example.org",
                    @"""very.(),:;<>[]\"".VERY.\""very@\ \""very\"".unusual""@strange.example.com",
                    @"""very.unusual.@.unusual.com""@example.com",
                    @"#!$%&'*+-/=?^_`{}|~@example.org",
                    @"admin@mailserver1",
                    @"üñîçøðé@example.com",
                    @"üñîçøðé@üñîçøðé.com",
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.Msdn,
                Examples.Invalid
            );
        }

        [TestMethod]
        public void ReferenceSourceWithWikipedia()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.ReferenceSource,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"""very.(),:;<>[]\"".VERY.\""very@\ \""very\"".unusual""@strange.example.com",
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.ReferenceSource,
                Examples.Invalid,

                // False positives:
                new[]
                {
                    @"john..doe@example.com",
                    @"john.doe@example..com",
                    @" john.doe@example.com",
                    @"john.doe@example.com ",
                }

            );
        }

        [TestMethod]
        public void HaackedWithWikipedia()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.Haacked,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"""very.(),:;<>[]\"".VERY.\""very@\ \""very\"".unusual""@strange.example.com",
                    @"admin@mailserver1",
                    @"üñîçøðé@example.com",
                    @"üñîçøðé@üñîçøðé.com",
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.Haacked,
                Examples.Invalid
            );
        }

        [TestMethod]
        public void JStedfastWithWikipedia()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.JStedfast,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"admin@mailserver1"
                }
            );

            CustomAssert.IsFalse(
                EmailAddressValidator.JStedfast,
                Examples.Invalid
            );
        }
    }
}
