namespace EmailAddressValidation.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class Msdn
    {
        [TestMethod]
        public void ValidFromCodeFool()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.Msdn.IsValid,
                Examples.CodeFool.Valid,

                // False negatives:
                new[]
                {
                    @"_______@example.com",
                    @"much.“more\ unusual”@example.com",
                    @"very.unusual.“@”.unusual.com@example.com",
                    @"very.“(),:;<>[]”.VERY.“very@\ ""very”.unusual@strange.example.com",
                    @"“email”@example.com",
                }

            );
        }

        [TestMethod]
        public void InvalidFromCodeFool()
        {
            CustomAssert.IsFalse(
                EmailAddressValidator.Msdn.IsValid,
                Examples.CodeFool.Invalid,
                
                // False positives:
                new[]
                {
                    @"email@111.222.333.44444",
                    @"email@example.web",
                }

            );
        }
    }
}
