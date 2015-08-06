namespace EmailAddressValidation.Tests.Wikipedia
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class Tests
    {
        [TestMethod]
        public void MsdnWithWikipedia()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.Msdn.IsValid,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"""()<>[]:,;@\\""!#$%&'*+-/=?^_`{}| ~.a""@example.org",
                    @"""very.(),:;<>[]\"".VERY.\""very@\ \""very\"".unusual""@strange.example.com",
                    @"""very.unusual.@.unusual.com""@example.com",
                    @"#!$%&'*+-/=?^_`{}|~@example.org",
                    @"admin@mailserver1",
                    @"üñîçøðé@example.com",
                    @"üñîçøðé@üñîçøðé.com",
                }

            );

            CustomAssert.IsFalse(EmailAddressValidator.Msdn.IsValid, Examples.Invalid);
        }

        [TestMethod]
        public void ReferenceSourceWithWikipedia()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.ReferenceSource.IsValid,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"""()<>[]:,;@\\""!#$%&'*+-/=?^_`{}| ~.a""@example.org",
                    @"""very.(),:;<>[]\"".VERY.\""very@\ \""very\"".unusual""@strange.example.com",
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.ReferenceSource.IsValid,
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
                EmailAddressValidator.Haacked.IsValid,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"""()<>[]:,;@\\""!#$%&'*+-/=?^_`{}| ~.a""@example.org",
                    @"""very.(),:;<>[]\"".VERY.\""very@\ \""very\"".unusual""@strange.example.com",
                    @"admin@mailserver1",
                    @"üñîçøðé@example.com",
                    @"üñîçøðé@üñîçøðé.com",
                }

            );

            CustomAssert.IsFalse(EmailAddressValidator.Haacked.IsValid, Examples.Invalid);
        }
    }
}
