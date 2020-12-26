using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCliente.Domain.DTO;
using ApiCliente.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using ApiCliente.Domain.Entities;

namespace ApiCliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoAppService _enderecoService;

        public EnderecoController(IEnderecoAppService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var retorno = _enderecoService.GetAll();
                if (retorno != null)
                    return Ok(retorno);
                else
                    return NotFound();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{IdEndereco}")]
        public async Task<ActionResult> GetById(int IdEndereco)
        {
            try
            {
                var retorno = _enderecoService.GetById(IdEndereco);
                if (retorno != null)
                    return Ok(retorno);
                else
                    return NotFound();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(EnderecoEntradaDTO endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var retorno = _enderecoService.Add(endereco);
                    return Created($"/endereco/{retorno}", retorno);
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
        /// Alterar dados do endereco.
        /// </summary>
        /// <param name="IdEndereco"></param>  
        /// <param name="model"></param>  
        [HttpPut("{IdEndereco}")]
        public async Task<ActionResult> Put(int IdEndereco, EnderecoEntradaDTO endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _enderecoService.Update(endereco, IdEndereco);
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
        /// Remove um endereco.
        /// </summary>
        /// <param name="IdEndereco"></param>  
        /// <param name="model"></param>  
        [HttpDelete("{IdEndereco}")]
        public async Task<ActionResult> Delete(int IdEndereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _enderecoService.Remove(IdEndereco);
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
