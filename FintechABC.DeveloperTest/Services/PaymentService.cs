using FintechABC.DeveloperTest.Data;
using FintechABC.DeveloperTest.Types;

namespace FintechABC.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountDataStore _accountDataStore;

        public PaymentService(IAccountDataStore accountDataStore)
        {
            _accountDataStore = accountDataStore;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = _accountDataStore.GetAccount(request.DebtorAccountNumber);

            return CanProcessRequest(request, account) 
                ? ProcessRequest(request, account)
                : GetUnsuccessfulRequest();
        }

        private static bool CanProcessRequest(MakePaymentRequest request, Account account)
        {
            return account != null &&
                   account.CanMakePayment(request);
        }

        private static MakePaymentResult GetUnsuccessfulRequest()
        {
            return new MakePaymentResult();
        }

        private MakePaymentResult ProcessRequest(MakePaymentRequest request, Account account)
        {
            account.MakePayment(request);

            _accountDataStore.UpdateAccount(account);
            
            return new MakePaymentResult
            {
                Success = true
            };
        }
    }
}
