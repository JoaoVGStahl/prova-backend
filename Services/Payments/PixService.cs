using ProvaPub.Interfaces;

namespace ProvaPub.Services.Payments
{
    public class PixService : IPaymentMethod
    {
        public void Pay(decimal paymentValue)
        {
            // Processa o pagamento via pix
        }
    }
}
