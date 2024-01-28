using ProvaPub.Interfaces;

namespace ProvaPub.Services.Payments
{
    public class BoletoService : IPaymentMethod
    {
        public void Pay(decimal paymentValue)
        {
            // Processa o pagamento via boleto
        }
    }
}
