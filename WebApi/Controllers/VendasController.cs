using Aplicacao.Aplicacao;
using Aplicacao.Interfaces;
using Dominio.Dto.HistoricoDTO;
using Dominio.Dto.Movimentacao.HistoricoDTO;
using Dominio.Dto.VendaDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IAplicacaoVenda _AplicacaoVenda;
        public VendasController(IAplicacaoVenda IAplicacaoVenda)
        {
             _AplicacaoVenda = IAplicacaoVenda;
        }

        [HttpPost("RealizarVenda")]
        public async Task<ActionResult> RealizarVenda(VendaInsertDTO vendaInsertDto)
        {
            if (!ModelState.IsValid)
                return null;

            try
            {
                await _AplicacaoVenda.RealizarVenda(vendaInsertDto);
                return Ok("Venda realizada com suceso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CancelarVenda/{codigoHistoricoVenda}")]
        public async Task<ActionResult> CancelarVenda(string codigoHistoricoVenda)
        {
            try
            {
                await _AplicacaoVenda.CancelarVenda(codigoHistoricoVenda);
                return Ok("Cancelamento realizada com suceso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("BuscarVendasPorPropriedade/{propriedadeId:int}")]
        public async Task<List<HistoricoCompraVendaResponseDTO>> BuscarVendasPorPropriedade(int propriedadeId)
        {
            return await _AplicacaoVenda.BuscarVendasPorPropriedade(propriedadeId);
        }
        [HttpGet("BuscarVendasPorProdutor/{produtorId:int}")]
        public async Task<List<HistoricoCompraVendaResponseDTO>> BuscarVendasPorProdutor(int produtorId)
        {
            return await _AplicacaoVenda.BuscarVendasPorProdutor(produtorId);          
          
        }
        [HttpGet("BuscarComprasPorProdutor/{produtorId:int}")]
        public async Task<List<HistoricoCompraVendaResponseDTO>> BuscarComprasPorProdutor(int produtorId)
        {
            return await _AplicacaoVenda.BuscarComprasPorProdutor(produtorId);
        }

    }
}
