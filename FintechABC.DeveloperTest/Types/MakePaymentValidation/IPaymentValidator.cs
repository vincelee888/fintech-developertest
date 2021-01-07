namespace FintechABC.DeveloperTest.Types.MakePaymentValidation
{
    public interface IPaymentValidator
    {
        bool IsValid(Account account, MakePaymentRequest request);
    }
}
