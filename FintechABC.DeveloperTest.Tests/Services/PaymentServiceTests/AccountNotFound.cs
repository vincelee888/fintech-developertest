using FintechABC.DeveloperTest.Services;
using FintechABC.DeveloperTest.Types;
using NUnit.Framework;

namespace FintechABC.DeveloperTest.Tests.Services.PaymentServiceTests
{
    public class AccountNotFound : PaymentServiceTestBase
    {
        [SetUp]
        public void Setup()
        {
            ReturnedAccount = null;
            Request = new MakePaymentRequest
            {
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
