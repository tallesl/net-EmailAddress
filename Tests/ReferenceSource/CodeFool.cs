namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class ReferenceSource
    {
        [TestMethod]
        public void ValidFromCodeFool()
        {
            CustomAssert.IsTrue(                
                EmailAddressValidator.ReferenceSource.IsValid,
                Examples.CodeFool.Valid,

                // False negatives:
                new[]
                {
                    @"much.“more\ unusual”@example.com",
                    @"very.unusual.“@”.unusual.com@example.com",
                    @"very.“(),:;<>[]”.VERY.“very@\ ""very”.unusual@strange.example.com",
                }

            );
        }

        [TestMethod]
        public void InvalidFromCodeFool()
        {
            CustomAssert.IsFalse(
                EmailAddressValidator.ReferenceSource.IsValid,
                Examples.CodeFool.Invalid,
                
                // False positives:
                new[]
                {
                    @"Abc..123@example.com",
                    @"Joe Smith <email@example.com>",
                    @"email..email@example.com",
                    @"email.@example.com",
                    @"email@-example.com",
                    @"email@111.222.333.44444",
                    @"email@example",
                    @"email@example..com",
                    @"email@example.com (Joe Smith)",
                    @"email@example.web",
                    @"あいうえお@example.com",
                }

            );
        }
    }
}
