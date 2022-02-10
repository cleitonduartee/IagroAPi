using Aplicacao.Interfaces;
using Dominio.Dto.ProdutorDTO;
using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Repositorio;
using Microsoft.AspNetCore.Cors;
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
        public async Task<List<ProdutorResponseDTO>> BuscarTodos()
        {
            return await _IAplicacaoProdutor.BuscarTodos();
        }
        [HttpGet("BuscarPorCpf/{cpf}")]
        public async Task<ActionResult<ProdutorResponseDTO>> BuscarPorCpf(string cpf)
        {
            if (_IAplicacaoProdutor.ValidarCpf(cpf))            {
                var produtorResponseDTO =  await _IAplicacaoProdutor.BuscarPorCpf(cpf);  
                if(produtorResponseDTO != null)
                    return Ok(produtorResponseDTO);                                   
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
