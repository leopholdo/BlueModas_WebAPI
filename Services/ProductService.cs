using System.Collections.Generic;
using System.Linq;
using BlueModas_WebAPI.Data;
using BlueModas_WebAPI.Models;

namespace BlueModas_WebAPI.Services
{
    public interface IProductService
    {
        List<TabProduct> GetProducts(int? tprID);
    }

    public class ProductService : IProductService
    {
        readonly APIContext _apiContext;

        public ProductService(APIContext apiContext)
        {
            _apiContext = apiContext;
        }

        public List<TabProduct> GetProducts(int? tprID)
        {
            List<TabProduct> result =
                _apiContext.TabProduct
                .WhereIf(tprID != null, x => x.tprID == tprID)
                .ToList();

            return result;
        }

    }
}