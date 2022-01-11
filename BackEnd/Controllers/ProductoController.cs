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
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [Route("GetListadoProductos")]
        [HttpGet]
        public async Task<IActionResult> GetListadoProductos()
        {
            try
            {
                var productos = await _productoService.GetListaProductos();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            try
            {
                await _productoService.CreateProducto(producto);
                return Ok(new { message = "Se agrego el producto exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        [Route("PostEntrada")]
        public async Task<IActionResult> PostEntrada([FromBody] Entrada entrada)
        {
            try
            {
                await _productoService.CreateEntrada(entrada);
                return Ok(new { message = "Se agrego el producto exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Producto producto)
        {
            try
            {
                await _productoService.EditProducto(producto);
                return Ok(new { message = "Se modifico el producto exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

    }
}
