using Aplicacao.Dto.ProdutorDTO;
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
        [HttpGet("BuscarPorCpf/{cpf}")]
        public async Task<ActionResult<Produtor>> BuscarPorCpf(string cpf)
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
        [HttpPost("CadastrarProdutor")]
        public async Task<ActionResult> CadastrarProdutor(ProdutorInsertDTO produtorDto)
        {
            if (!ModelState.IsValid)
                return null;

            if (_IAplicacaoProdutor.ValidarCpf(produtorDto.Cpf))
            {
                Produtor novoProdutor = ProdutorInsertDTO.ToProdutor(produtorDto);
                await _IAplicacaoProdutor.CadastrarProdutor(novoProdutor);
                return Ok("Produtor cadastrado com sucesso.");
            }
            else
            {
                return BadRequest("CPF informado no cadastro é inválido.");
            }
            
        }
        [HttpPut("EditarProdutor/{id:int}")]
        public async Task<ActionResult> EditarProdutor(ProdutorDTO produtorDto, int id)
        {
            if (!ModelState.IsValid)
                return null;
            if (id != produtorDto.ProdutorId)
                return NotFound("Id informado não é o mesmo do Produtor");

            if (_IAplicacaoProdutor.ValidarCpf(produtorDto.Cpf))
            {
                Produtor produtor= _IAplicacaoProdutor.BuscarPorId(produtorDto.ProdutorId).Result;
                ProdutorDTO.AtualizaProdutor(produtorDto, produtor);
                await _IAplicacaoProdutor.EditarProdutor(produtor);
                return Ok("Produtor editado com sucesso.");
            }
            else
            {
                return BadRequest("CPF informado na edição é inválido.");
            }

        }
    }
}
