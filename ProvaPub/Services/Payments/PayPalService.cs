using ProvaPub.Interfaces;

namespace ProvaPub.Services.Payments
{
    public class PayPalService : IPaymentMethod
    {
        public void Pay(decimal paymentValue)
        {
            // Processa o pagamento via Paypal
        }
    }
}
