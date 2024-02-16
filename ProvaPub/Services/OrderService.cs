using ProvaPub.Enums;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Services.Payments;

namespace ProvaPub.Services
{
    public class OrderService
    {
        private readonly IServiceProvider _serviceProvider;

        public OrderService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Order> PayOrder(PaymentsTypes paymentMethod,decimal paymentValue, int customerId)
        {
            GetPaymentMethod(paymentMethod).Pay(paymentValue);

            return await Task.FromResult(new Order()
            {
                Value = paymentValue,
                CustomerId = customerId,
                OrderDate = DateTime.Now,
            });
        }

        private IPaymentMethod GetPaymentMethod(PaymentsTypes paymentType)
        {
            return paymentType switch
            {
                PaymentsTypes.Pix => _serviceProvider.GetRequiredService<PixService>(),
                PaymentsTypes.CreditCard => _serviceProvider.GetRequiredService<CreditCardService>(),
                PaymentsTypes.PayPal => _serviceProvider.GetRequiredService<PayPalService>(),
                PaymentsTypes.Boleto => _serviceProvider.GetRequiredService<BoletoService>(),
                _ => throw new ArgumentException("Unsupported payment type", nameof(paymentType))
            };
        }
    }
}
