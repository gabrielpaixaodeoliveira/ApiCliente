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
        private readonly IAppServiceBase<Endereco> _appServiceBase;

        public EnderecoController(IAppServiceBase<Endereco> appServiceBase)
        {
            _appServiceBase = appServiceBase;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(_appServiceBase.GetAll());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Endereco endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _appServiceBase.Add(endereco);
                    return Created($"/endereco/{endereco}", endereco);
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
        public async Task<ActionResult> Put(int IdEndereco, Endereco endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _appServiceBase.Update(endereco);
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
