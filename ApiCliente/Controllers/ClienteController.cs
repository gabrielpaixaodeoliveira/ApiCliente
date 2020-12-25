﻿using System;
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
                return Ok(_clienteService.GetAll());
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
                    _clienteService.Add(cliente);
                    return Created($"/cliente/{cliente}", cliente);
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
                return BadRequest(ModelState);
            }
        }

    }
}
