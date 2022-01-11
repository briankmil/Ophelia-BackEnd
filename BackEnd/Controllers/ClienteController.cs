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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [Route("GetListadoClientes")]
        [HttpGet]
        public async Task<IActionResult> GetListadoClientes()
        {
            try
            {
                var clientes = await _clienteService.GetListaClientes();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                await _clienteService.CreateCliente(cliente);
                return Ok(new { message = "Se agrego el cliente exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Cliente cliente)
        {
            try
            {
                await _clienteService.EditCliente(cliente);
                return Ok(new { message = "Se modifico el cliente exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

    }
}
