using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCliente.Domain.DTO;
using ApiCliente.Aplication.Interface;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ClienteController(IClienteAppService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(_mapper.Map<List<ClienteSaidaDTO>>(_clienteService.GetAll()));
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
        /// <param name="ClienteId"></param>  
        /// <param name="model"></param>  
        [HttpPut("{clienteId}")]
        public async Task<ActionResult> Put(int clienteId, ClienteEntradaDTO cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteService.Update(cliente);
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
