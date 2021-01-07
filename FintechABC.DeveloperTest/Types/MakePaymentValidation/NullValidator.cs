namespace FintechABC.DeveloperTest.Types.MakePaymentValidation
{
    public class NullValidator : IPaymentValidator
    {
        public bool IsValid(Account account, MakePaymentRequest request)
        {
            return true;
        }
    }
}
