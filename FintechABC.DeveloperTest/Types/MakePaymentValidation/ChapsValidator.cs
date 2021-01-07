namespace FintechABC.DeveloperTest.Types.MakePaymentValidation
{
    public class ChapsValidator : IPaymentValidator
    {
        public bool IsValid(Account account, MakePaymentRequest _)
        {
            return account.Status == AccountStatus.Live;
        }
    }
}
