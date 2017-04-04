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
                EmailAddressValidator.Msdn,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"_______@example.com",
                    @"much.""more\ unusual""@example.com",
                    @"very.unusual.""@"".unusual.com@example.com",
                    @"very.""(),:;<>[]"".VERY.""very@\ ""very"".unusual@strange.example.com",
                    @"""email""@example.com",
                    @"あいうえお@example.com"
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.Msdn,
                Examples.Invalid,

                // False positives:
                new[]
                {
                    @"email@111.222.333.44444",
                    @"email@123.123.123.123",
                }

            );
        }

        [TestMethod]
        public void ReferenceSourceWithCodeFool()
        {
            CustomAssert.IsTrue(                
                EmailAddressValidator.ReferenceSource,
                Examples.Valid,

                // False negatives:
                new[]
                {
                    @"much.""more\ unusual""@example.com",
                    @"very.unusual.""@"".unusual.com@example.com",
                    @"very.""(),:;<>[]"".VERY.""very@\ ""very"".unusual@strange.example.com",
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.ReferenceSource,
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
                    @"email@123.123.123.123",
                    @"email@example",
                    @"email@example..com",
                    @"email@example.com (Joe Smith)",
                }

            );
        }

        [TestMethod]
        public void HaackedWithCodeFool()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.Haacked,
                Examples.Valid,
                
                // False negatives:
                new[]
                {
                    @"email@123.123.123.123",
                    @"email@[123.123.123.123]",
                    @"much.""more\ unusual""@example.com",
                    @"very.unusual.""@"".unusual.com@example.com",
                    @"very.""(),:;<>[]"".VERY.""very@\ ""very"".unusual@strange.example.com",
                    @"""email""@example.com",
                    @"あいうえお@example.com"
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.Haacked,
                Examples.Invalid,
            
                // False positives:
                new[]
                {
                    @"@example.com",
                }

            );
        }

        [TestMethod]
        public void JStedfastWithCodeFool()
        {
            CustomAssert.IsTrue(
                EmailAddressValidator.JStedfast,
                Examples.Valid,

                // False negatives:
                new []
                {
                    @"very.""(),:;<>[]"".VERY.""very@\ ""very"".unusual@strange.example.com"
                }

            );

            CustomAssert.IsFalse(
                EmailAddressValidator.JStedfast,
                Examples.Invalid,

                // False positives:
                new []
                {
                    @"email@example",
                }

            );
        }
    }
}
