using ProvaPub.Enums;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Services.Payments;

namespace ProvaPub.Services
{
    public class OrderService
    {
        public async Task<Order> PayOrder(PaymentsTypes paymentMethod,decimal paymentValue, int customerId)
        {
            GetPaymentMethod(paymentMethod).Pay(paymentValue);

            return await Task.FromResult(new Order()
            {
                Value = paymentValue,
            });
        }

        private static IPaymentMethod GetPaymentMethod(PaymentsTypes paymentType)
        {
            return paymentType switch
            {
                PaymentsTypes.Pix => new PixService(),
                PaymentsTypes.CreditCard => new CreditCardService(),
                PaymentsTypes.PayPal => new PayPalService(),
                PaymentsTypes.Boleto => new BoletoService(),
            };
        }
    }
}
