using System.Collections.Generic;
using FintechABC.DeveloperTest.Types.MakePaymentValidation;

namespace FintechABC.DeveloperTest.Types
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountStatus Status { get; set; }
        public AllowedPaymentSchemes AllowedPaymentSchemes { get; set; }

        public void MakePayment(MakePaymentRequest request)
        {
            Balance -= request.Amount;
        }

        public bool CanMakePayment(MakePaymentRequest request)
        {
            var validator = RequestValidatorFactory.GetValidator(request);

            return IsAllowedPaymentScheme(request) &&
                validator.IsValid(this, request);
        }

        private bool IsAllowedPaymentScheme(MakePaymentRequest request)
        {
            var paymentSchemeMapping = new Dictionary<PaymentScheme, AllowedPaymentSchemes>
            {
                {PaymentScheme.Bacs, AllowedPaymentSchemes.Bacs},
                {PaymentScheme.Chaps, AllowedPaymentSchemes.Chaps},
                {PaymentScheme.FasterPayments, AllowedPaymentSchemes.FasterPayments}
            };
            return AllowedPaymentSchemes.HasFlag(paymentSchemeMapping[request.PaymentScheme]);
        }
    }
}
