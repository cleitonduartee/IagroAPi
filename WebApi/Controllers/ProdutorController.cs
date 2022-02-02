using Aplicacao.Interfaces;
using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{    
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProdutorController : ControllerBase
    {
        private readonly IAplicacaoProdutor _IAplicacaoProdutor;
        public ProdutorController(IAplicacaoProdutor IAplicacaoProdutor)
        {
            _IAplicacaoProdutor = IAplicacaoProdutor;
        }
        [HttpGet("BuscarTodos")]
        public async Task<List<Produtor>> BuscarTodos()
        {
            var produtores = await _IAplicacaoProdutor.BuscarTodos();
            return produtores;
        }
        [HttpGet("{cpf}")]
        public async Task<ActionResult<Produtor>> BuscarPorCepf(string cpf)
        {
            if (_IAplicacaoProdutor.ValidarCpf(cpf))            {
                var produtor =  await _IAplicacaoProdutor.BuscarPorCpf(cpf);
                if(produtor != null) 
                    return Ok(produtor);
                else
                    return NotFound("Produtor não encontrado.");
            }
            return BadRequest("CPF Inválido.");
        }
        [HttpPost]
        public async Task<ActionResult<Produtor>> CadastrarProdutor(string cpf)
        {
            if (_IAplicacaoProdutor.ValidarCpf(cpf))
            {
                var produtor = await _IAplicacaoProdutor.BuscarPorCpf(cpf);
                if (produtor != null)
                    return Ok(produtor);
                else
                    return NotFound("Produtor não encontrado.");
            }
            return BadRequest("CPF Inválido.");
        }
    }
}
