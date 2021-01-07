using FintechABC.DeveloperTest.Data;
using FintechABC.DeveloperTest.Types;

namespace FintechABC.DeveloperTest.Tests.Services.PaymentServiceTests
{
    public abstract class PaymentServiceTestBase : IAccountDataStore
    {
        protected const decimal AccountStartingBalance = 100;
        protected Account ReturnedAccount;
        protected MakePaymentRequest Request;
        protected Account UpdatedAccount;
        protected MakePaymentResult Result;
        Account IAccountDataStore.GetAccount(string accountNumber)
        {
            return ReturnedAccount;
        }

        void IAccountDataStore.UpdateAccount(Account account)
        {
            UpdatedAccount = account;
        }
    }
}
