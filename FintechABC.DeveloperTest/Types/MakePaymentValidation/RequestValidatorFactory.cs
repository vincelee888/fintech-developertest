namespace FintechABC.DeveloperTest.Types.MakePaymentValidation
{
    public static class RequestValidatorFactory
    {
        public static IPaymentValidator GetValidator(MakePaymentRequest request)
        {
            return request.PaymentScheme switch
            {
                PaymentScheme.Chaps => new ChapsValidator(),
                PaymentScheme.FasterPayments => new FasterPaymentsValidator(),
                _ => new NullValidator()
            };
        }
    }
}
