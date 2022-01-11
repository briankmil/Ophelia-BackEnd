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
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [Route("GetListadoFacturas")]
        [HttpGet]
        public async Task<IActionResult> GetListadoFacturas()
        {
            try
            {
                var facturas = await _facturaService.GetListaFacturas();
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Factura factura)
        {
            try
            {
                var idFactura = await _facturaService.CreateFactura(factura);
                return Ok(new { message = "Se agrego la factura exitosamente", idFactura = idFactura });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        [Route("PostDetalleFactura")]
        public async Task<IActionResult> PostDetalleFactura([FromBody] List<DetalleFactura> detalleFacturas)
        {
            try
            {
                await _facturaService.CreateDetalleFacturas(detalleFacturas);
                return Ok(new { message = "Se agregaron los detalle factura exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


    }
}
