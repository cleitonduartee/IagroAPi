using Aplicacao.Dto;
using Aplicacao.Dto.PropriedadeDTO;
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
    public class PropriedadeController : ControllerBase
    {
        private readonly IAplicacaoPropriedade _IAplicacaoPropriedade;
        public PropriedadeController(IAplicacaoPropriedade IAplicacaoPropriedade)
        {
            _IAplicacaoPropriedade = IAplicacaoPropriedade;
        }
        [HttpGet("BuscarTodos")]
        public async Task<List<PropriedadeResponseDTO>> BuscarTodos()
        {
            return await _IAplicacaoPropriedade.BuscarTodos();
             
        }
        [HttpGet("BuscarPorIE/{ie:int}")]
        public async Task<ActionResult<PropriedadeResponseDTO>> BuscarPorIE(int ie)
        {
            var propriedadeResponseDTO = await _IAplicacaoPropriedade.BuscarPorIE(ie);
            if (propriedadeResponseDTO != null)
                return Ok(propriedadeResponseDTO);
            else
                return NotFound("Propriedade não encontrado.");
        }
        [HttpGet("BuscarPorProdutor/{produtor}")]
        public async Task<List<PropriedadeResponseDTO>> BuscarPorProdutor(string produtor)
        {
            return await _IAplicacaoPropriedade.BuscarPorProdutor(produtor);
           
        }
        [HttpPost("CadastrarPropriedade")]
        public async Task<ActionResult> CadastrarPropriedade(PropriedadeInsertDTO PropriedadeDto)
        {
            if (!ModelState.IsValid)            
                return null;

            Propriedade novoPropriedade = PropriedadeInsertDTO.ToPropriedade(PropriedadeDto);
            await _IAplicacaoPropriedade.CadastrarPropriedade(novoPropriedade);
            return Ok("Popriedade cadastrada com sucesso.");

        }
        [HttpPut("EditarPropriedade/{id:int}")]
        public async Task<ActionResult> EditarPropriedade(PropriedadeDTO propriedadeDTO, int id)
        {
            if (!ModelState.IsValid)
                return null;
            if (id != propriedadeDTO.ProdutorId)
                return NotFound("Id informado não é o mesmo da Propriedade");


            Propriedade propriedade = _IAplicacaoPropriedade.BuscarPorId(propriedadeDTO.PropriedadeId).Result;
            PropriedadeDTO.AtualizaPropriedade(propriedadeDTO, propriedade);
            await _IAplicacaoPropriedade.EditarPropriedade(propriedade);
            return Ok("Propriedade editada com sucesso.");

        }
    }
}
