namespace EmailAddressLibrary.Tests.CodeFool
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public partial class Tests
    {
        [TestMethod]
        public void MsdnWithCodeFool()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.Msdn.IsValid,
                Examples.Valid,

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

            CustomAssert.IsFalse(
                EmailAddressValidator.Msdn.IsValid,
                Examples.Invalid,

                // False positives:
                new[]
                {
                    @"email@111.222.333.44444",
                    @"email@example.web",
                }

            );
        }

        [TestMethod]
        public void ReferenceSourceWithCodeFool()
        {
            CustomAssert.IsTrue(                
                EmailAddressValidator.ReferenceSource.IsValid,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"much.“more\ unusual”@example.com",
                    @"very.unusual.“@”.unusual.com@example.com",
                    @"very.“(),:;<>[]”.VERY.“very@\ ""very”.unusual@strange.example.com",
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.ReferenceSource.IsValid,
                Examples.Invalid,
                
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

        [TestMethod]
        public void HaackedWithCodeFool()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.Haacked.IsValid,
                Examples.Valid,
                
                // False negatives:
                new[]
                {
                    @"email@123.123.123.123",
                    @"email@[123.123.123.123]",
                    @"much.“more\ unusual”@example.com",
                    @"very.unusual.“@”.unusual.com@example.com",
                    @"very.“(),:;<>[]”.VERY.“very@\ ""very”.unusual@strange.example.com",
                    @"“email”@example.com",
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.Haacked.IsValid,
                Examples.Invalid,
            
                // False positives:
                new[]
                {
                    @"@example.com",
                    @"email@example.web",
                }

            );
        }
    }
}
