namespace FintechABC.DeveloperTest.Types.MakePaymentValidation
{
    public class FasterPaymentsValidator : IPaymentValidator
    {
        public bool IsValid(Account account, MakePaymentRequest request)
        {
            return account.Balance >= request.Amount;
        }
    }
}
