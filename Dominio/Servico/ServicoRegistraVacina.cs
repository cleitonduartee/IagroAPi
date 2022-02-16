using Dominio.Dto.RegistroVacinaDTO;
using Dominio.ExceptionPersonalizada;
using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoRegistraVacina : IServicoRegistroVacina
    {
        private readonly IRegistroVacina _IRegistroVacina;
        private readonly IServicoPropriedade _IServicoPropriedade;
        private readonly IRebanho _IRebanho;

        private Propriedade propriedade;
        private RegistroVacina registroVacina;

        public ServicoRegistraVacina(IRegistroVacina IRegistroVacina, IServicoPropriedade IServicoPropriedade, IRebanho IRebanho)
        {
            _IRegistroVacina = IRegistroVacina;
            _IServicoPropriedade = IServicoPropriedade;
            _IRebanho = IRebanho;
        }
        public async Task AdicionarRegistroVacina(RegistroVacinaInsertDTO registroDto)
        {
            await ValidacoesParaRegistrarVacinacao(registroDto);
            await AtualizaAnimaisVacinadoRebanho(registroDto);                       

            var registroVacinaNovo = new RegistroVacina(registroDto.PropriedadeId,
                                                    registroDto.TipoVacina,
                                                    registroDto.QtdBovinoVacinado,
                                                    registroDto.QtdBubalinoVacinado,
                                                    registroDto.DataVacinacao);

            await _IRegistroVacina.AdicionarRegistroVacina(registroVacinaNovo);
            //propriedade.DataUltimaVacinacao = registroVacinaNovo.DataRegistro;
            //await _IServicoPropriedade.EditarPropriedade(propriedade);
        }

        public async Task CancelarRegistroVacina(string codigoRegistro)
        {
            await ValidacoesParaCancelarRegistrarVacinacao(codigoRegistro);
            await AtualizaAnimaisCanceladoNoRegistro();

            registroVacina.Ativo = false;
            registroVacina.DataCancelamento = DateTime.Now;
            await _IRegistroVacina.CancelarRegistroVacina(registroVacina);
        }

        private async Task ValidacoesParaRegistrarVacinacao(RegistroVacinaInsertDTO registroDto)
        {
            string validacao = "";
            propriedade = await _IServicoPropriedade.BuscarPorId(registroDto.PropriedadeId);

            if (propriedade == null)
                validacao += "ERROR: Propriedade não localizada.";

            int qtdBovinoVacinadoNoRegistro = registroDto.QtdBovinoVacinado;
            int qtdBubalinoVacinadoNoRegistro = registroDto.QtdBubalinoVacinado;

            var rebanho = propriedade.Rebanho;
            if (qtdBovinoVacinadoNoRegistro > rebanho.SaldoSemVacinaBovino || qtdBubalinoVacinadoNoRegistro > rebanho.SaldoSemVacinaBubalino)
                validacao += "ERROR: Quantidade de animais vacinados por espécie é maior que o saldo de animais sem vacina.";

            if (!RegistroVacina.DataVacinacaoEValida(registroDto.DataVacinacao))
                validacao += "ERROR: Data de vacinação é invalida. Data deve ser do ano atual.";


            if (!String.IsNullOrEmpty(validacao))
                throw new ExceptionGenerica(validacao);
        }
        private async Task ValidacoesParaCancelarRegistrarVacinacao(string codigoRegistro)
        {
            string validacao = "";

            registroVacina = await _IRegistroVacina.BuscarRegistroVacinaPorCodigo(codigoRegistro);
            if (registroVacina == null)
                validacao+= "ERROR: Não foi localizado o registro de vacinação com o id informado.";

            propriedade = await _IServicoPropriedade.BuscarPorId(registroVacina.PropriedadeId);
            if (propriedade == null)
                validacao += "ERROR: Propriedade não localizada.";

            var rebanho = propriedade.Rebanho;
            if(rebanho.DataUltimaVenda > registroVacina.DataRegistro)
                validacao += "ERROR: Não é possivel cancelar esse registro, pois houve venda posterior a data de cadastro da vacinação. ";
                   

            if (!String.IsNullOrEmpty(validacao))
                throw new ExceptionGenerica(validacao);
        }
        private async Task AtualizaAnimaisVacinadoRebanho(RegistroVacinaInsertDTO registroDto)
        {
            
            int qtdBovinoVacinadoNoRegistro = registroDto.QtdBovinoVacinado;
            int qtdBubalinoVacinadoNoRegistro = registroDto.QtdBubalinoVacinado;

            var rebanho = propriedade.Rebanho;
            rebanho.SaldoSemVacinaBovino -= qtdBovinoVacinadoNoRegistro;
            rebanho.SaldoComVacinaBovino += qtdBovinoVacinadoNoRegistro;

            rebanho.SaldoSemVacinaBubalino -= qtdBubalinoVacinadoNoRegistro;
            rebanho.SaldoComVacinaBubalino += qtdBubalinoVacinadoNoRegistro;
            rebanho.DataVacina = registroDto.DataVacinacao;

            await _IRebanho.Atualizar(rebanho);
        }
        private async Task AtualizaAnimaisCanceladoNoRegistro()
        {

            int qtdBovinoVacinadoNoRegistro = registroVacina.QtdBovinoVacinado;
            int qtdBubalinoVacinadoNoRegistro = registroVacina.QtdBubalinoVacinado;

            var rebanho = propriedade.Rebanho;
            rebanho.SaldoSemVacinaBovino += qtdBovinoVacinadoNoRegistro;
            rebanho.SaldoComVacinaBovino -= qtdBovinoVacinadoNoRegistro;

            rebanho.SaldoSemVacinaBubalino += qtdBubalinoVacinadoNoRegistro;
            rebanho.SaldoComVacinaBubalino -= qtdBubalinoVacinadoNoRegistro;           

            await _IRebanho.Atualizar(rebanho);
        }

        public async Task<List<RegistroVacina>> BuscarRegistrosPorPropriedadeId(int idPropriedade)
        {
            var list = await _IRegistroVacina.BuscarRegistrosPorPropriedadeId(registro =>
                                             registro.PropriedadeId.Equals(idPropriedade));

            return list;
        }
    }
}
