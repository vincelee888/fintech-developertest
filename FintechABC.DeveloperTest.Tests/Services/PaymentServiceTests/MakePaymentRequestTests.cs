using FintechABC.DeveloperTest.Types;
using NUnit.Framework;

namespace FintechABC.DeveloperTest.Tests.Services.PaymentServiceTests
{
    public class MakePaymentRequestTests
    {
        [Test]
        public void PaymentSchemeDefaultsToFasterPayments()
        {
            var sut = new MakePaymentRequest();
            Assert.That(sut.PaymentScheme, Is.EqualTo(PaymentScheme.FasterPayments));
        }
    }
}
