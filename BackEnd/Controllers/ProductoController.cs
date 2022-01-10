using BackEnd.Domains.IServices;
using BackEnd.Domains.Models;
using BackEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoSercie;
        private readonly IConfiguration _config;

        public ProductoController(IConfiguration config, IProductoService productoService)
        {
            _config = config;
            _productoSercie = productoService;
        }

        [Route("GetListadoProductos")]
        [HttpGet]
        public async Task<IActionResult> GetListadoProductos()
        {
            try
            {
                var productos = await _productoSercie.GetListaProductos();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
               
    }
}
