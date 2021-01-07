using FintechABC.DeveloperTest.Services;
using FintechABC.DeveloperTest.Types;
using NUnit.Framework;

namespace FintechABC.DeveloperTest.Tests.Services.PaymentServiceTests
{
    public class ChapsAgainstLiveAccount : PaymentServiceTestBase
    {
        [SetUp]
        public void Setup()
        {
            ReturnedAccount = new Account
            {
                Balance = AccountStartingBalance,
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                Status = AccountStatus.Live
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
        public void SavedAccountShouldHaveRequestedAmountDeductedFromAccountBalance()
        {
            Assert.That(UpdatedAccount.Balance, Is.EqualTo(AccountStartingBalance - Request.Amount));
        }

        [Test]
        public void ShouldReturnSuccessfulResult()
        {
            Assert.True(Result.Success);
        }
    }
}
