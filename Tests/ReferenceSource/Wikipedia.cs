namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class ReferenceSource
    {
        [TestMethod]
        public void ValidFromWikipedia()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.ReferenceSource.IsValid,
                Examples.Wikipedia.Valid,

                // False negatives:
                new[]
                {
                    @"""()<>[]:,;@\\""!#$%&'*+-/=?^_`{}| ~.a""@example.org",
                    @"""very.(),:;<>[]\"".VERY.\""very@\ \""very\"".unusual""@strange.example.com",
                }

            );
        }

        [TestMethod]
        public void InvalidFromWikipedia()
        {
            CustomAssert.IsFalse(
                EmailAddressValidator.ReferenceSource.IsValid,
                Examples.Wikipedia.Invalid,

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
    }
}
