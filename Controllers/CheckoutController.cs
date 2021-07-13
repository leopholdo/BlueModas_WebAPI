using System;
using BlueModas_WebAPI.Models;
using BlueModas_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlueModas_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckoutController : Controller
    {
        readonly IClientService _clientService;
        readonly ICheckoutService _checkoutService;
        readonly IProductService _productService;
        public CheckoutController(IClientService clientService, ICheckoutService checkoutService, IProductService productService)
        {
            _clientService = clientService;
            _checkoutService = checkoutService;
            _productService = productService;
        }

        [HttpPost]
        public ActionResult Checkout([FromBody] OrderEntity orderEntity)
        {
            try
            {
                if (_clientService.GetClient(orderEntity.client.tclEmail) != null)
                {
                    orderEntity.client = _clientService.UpdateClient(orderEntity.client);
                }
                else
                {
                    orderEntity.client = _clientService.InsertClient(orderEntity.client);
                }

                orderEntity.order = new TabOrder();
                orderEntity.order.tortclID = orderEntity.client.tclID;
                orderEntity.order.torDate = DateTime.Now;

                orderEntity.order = _checkoutService.InsertOrder(orderEntity.order);

                foreach (TabProductBasket productBasket in orderEntity.productBasketList)
                {
                    productBasket.TabProduct = _productService.GetProducts(productBasket.tpbtprID)[0];
                    productBasket.tpbtorID = orderEntity.order.torID;
                    _checkoutService.InsertProductBasket(productBasket);
                }

                return Ok(orderEntity);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}