namespace ProvaPub.Interfaces
{
    public interface IPaymentMethod
    {
        void Pay(decimal paymentValue);
    }
}
