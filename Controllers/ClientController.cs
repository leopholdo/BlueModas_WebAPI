using System;
using BlueModas_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlueModas_WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : Controller
    {

        readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("GetClient")]
        public ActionResult GetClient(string tclEmail)
        {
            try
            {
                return Ok(_clientService.GetClient(tclEmail));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}