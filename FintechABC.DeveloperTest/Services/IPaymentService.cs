using FintechABC.DeveloperTest.Types;

namespace FintechABC.DeveloperTest.Services
{
    public interface IPaymentService
    {
        MakePaymentResult MakePayment(MakePaymentRequest request);
    }
}
