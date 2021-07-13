using System;
using BlueModas_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlueModas_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProducts")]
        public ActionResult GetProducts(int? tprID)
        {
            try
            {
                return Ok(_productService.GetProducts(tprID));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}