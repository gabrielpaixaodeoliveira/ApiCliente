using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCliente.Domain.DTO;
using ApiCliente.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ApiCliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteService;

        public ClienteController(IClienteAppService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(_clienteService.GetAllComInclude());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("IdCliente")]
        public async Task<ActionResult> Get(int IdCliente)
        {
            try
            {
                return Ok(_clienteService.GetByIdComInclude(IdCliente));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post(ClienteEntradaDTO cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var retorno = _clienteService.Add(cliente);
                    return Created($"/cliente/{retorno.IdCliente}", retorno);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Alterar dados do cliente.
        /// </summary>
        /// <param name="IdCliente"></param>  
        /// <param name="model"></param>  
        [HttpPut("{IdCliente}")]
        public async Task<ActionResult> Put(int IdCliente, ClienteEntradaDTO cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteService.Update(cliente, IdCliente);
                    return NoContent();
                }
                else
                {
                    return BadRequest(ModelState);
                }


            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um cliente.
        /// </summary>
        /// <param name="IdCliente"></param>  
        /// <param name="model"></param>  
        [HttpDelete("{IdCliente}")]
        public async Task<ActionResult> Delete(int IdCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteService.Remove(IdCliente);
                    return NoContent();
                }
                else
                {
                    return BadRequest(ModelState);
                }


            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
