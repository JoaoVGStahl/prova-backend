using ProvaPub.Interfaces;

namespace ProvaPub.Services.Payments
{
    public class CreditCardService : IPaymentMethod
    {
        public void Pay(decimal paymentValue)
        {
            // Processa o pagamento via cartão de crédito
        }
    }
}
