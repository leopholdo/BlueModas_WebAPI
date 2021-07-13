using BlueModas_WebAPI.Data;
using BlueModas_WebAPI.Models;

namespace BlueModas_WebAPI.Services
{
    public interface ICheckoutService
    {
        TabOrder InsertOrder(TabOrder order);
        TabProductBasket InsertProductBasket(TabProductBasket productBasket);
    }

    public class CheckoutService : ICheckoutService
    {
        readonly APIContext _apiContext;

        public CheckoutService(APIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public TabOrder InsertOrder(TabOrder order)
        {
            _apiContext.TabOrder.Add(order);
            _apiContext.SaveChanges();

            return order;
        }

        public TabProductBasket InsertProductBasket(TabProductBasket productBasket)
        {
            _apiContext.TabProductBasket.Add(productBasket);
            _apiContext.SaveChanges();

            return productBasket;
        }

    }
}