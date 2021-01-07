using FintechABC.DeveloperTest.Services;
using FintechABC.DeveloperTest.Types;
using NUnit.Framework;

namespace FintechABC.DeveloperTest.Tests.Services.PaymentServiceTests
{
    public class AccountDoesNotAllowChaps : PaymentServiceTestBase
    {
        [SetUp]
        public void Setup()
        {
            ReturnedAccount = new Account
            {
                Balance = AccountStartingBalance,
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments
            };
            Request = new MakePaymentRequest
            {
                PaymentScheme = PaymentScheme.Chaps,
                Amount = 10
            };
            
            var sut = new PaymentService(this);

            Result = sut.MakePayment(Request);
        }

        [Test]
        public void ShouldNotUpdateAccount()
        {
            Assert.That(UpdatedAccount, Is.Null);
        }

        [Test]
        public void ShouldReturnUnsuccessfulResult()
        {
            Assert.False(Result.Success);
        }
    }
}
