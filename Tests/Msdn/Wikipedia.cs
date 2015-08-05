namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class Msdn
    {
        [TestMethod]
        public void ValidFromWikipedia()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.Msdn.IsValid,
                Examples.Wikipedia.Valid,

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
        }

        [TestMethod]
        public void InvalidFromWikipedia()
        {
            CustomAssert.IsFalse(
                EmailAddressValidator.Msdn.IsValid,
                Examples.Wikipedia.Invalid,

                // False positives:
                new[]
                {
                    @"",
                }

            );
        }
    }
}
