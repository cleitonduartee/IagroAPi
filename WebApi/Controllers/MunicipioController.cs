using Aplicacao.Interfaces;
using Entidades.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class MunicipioController : Controller
    {
        private readonly IAplicacaoMunicipio _IAplicacaoMunicipio;
        public MunicipioController(IAplicacaoMunicipio IAplicacaoMunicipio)
        {
            _IAplicacaoMunicipio = IAplicacaoMunicipio;
        }
        [HttpGet("/api/v1/BuscarTodos")]
        public async Task<List<Municipio>> BuscarTodos()
        {
            return await _IAplicacaoMunicipio.BuscarTodos();
        }
        [HttpPost("/api/v1/AdicionarMunicipio")]
        public async void AdicionarMunicipio(string nome)
        {
            await _IAplicacaoMunicipio.Adicionar(new Municipio(nome));
            
        }
    }
}
