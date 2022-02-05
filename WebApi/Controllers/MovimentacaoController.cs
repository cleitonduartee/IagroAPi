using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Aplicacao.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entidades.Entidades;
using Dominio.ExceptionPersonalizada;
using System;
using Dominio.Dto.Movimentacao.MovimentacaoDTO;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
         
        private readonly IAplicacaoMovimentacao _IAplicacaoMovimentacao;
        public MovimentacaoController(IAplicacaoMovimentacao IAplicacaoMovimentacao)
        {
            _IAplicacaoMovimentacao = IAplicacaoMovimentacao;
        }
        [HttpGet("BuscarPorIdPropriedade/{propriedadeId:int}")]
        public async Task<List<MovimentacaoResponseDTO>> BuscarPorIdPropriedade(int propriedadeId)
        {
            var movemntacoesList = await _IAplicacaoMovimentacao.BuscarPorIdPropriedade(propriedadeId);
            var movimentacoesDtoList = new List<MovimentacaoResponseDTO>();
            movemntacoesList.ForEach(mov => movimentacoesDtoList.Add(new MovimentacaoResponseDTO(mov)));
            return movimentacoesDtoList;
        }
        [HttpPost("CancelarMovimentacao/{codigo}")]
        public async Task<ActionResult> CancelarMovimentacao(string codigo)
        {
            try
            {
                await _IAplicacaoMovimentacao.CancelarMovimentacao(codigo);
                return Ok();
            }
            catch(ExceptionGenerica ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
