using System.Threading.Tasks;
using ApiCliente.Domain.DTO;
using ApiCliente.Aplication.Interface;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<JsonResult> Get()
        {
            try
            {
                var retorno = _clienteService.GetAllComInclude();
                if (retorno == null)
                    return new JsonResult(NotFound());
                else
                    return new JsonResult(Ok(retorno));
            }
            catch (System.Exception ex)
            {
                return new JsonResult(BadRequest(ex.Message));
            }
        }

        [HttpGet("IdCliente")]
        public async Task<ActionResult> Get(int IdCliente)
        {
            try
            {
                var retorno = _clienteService.GetByIdComInclude(IdCliente);
                if (retorno == null)
                    return NotFound();
                else
                    return Ok(retorno);                
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
