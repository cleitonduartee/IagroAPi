using Dominio.Interfaces;
using Dominio.Interfaces.InterfaceServico;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico
{
    public class ServicoProdutor : IServicoProdutor
    {
        private readonly IProdutor _IProdutor;
        private readonly IEndereco _IEndereco;
        public ServicoProdutor(IProdutor IProdutor, IEndereco IEndereco)
        {
            _IProdutor = IProdutor;
            _IEndereco = IEndereco;
        }
        public async Task<Produtor> BuscarPorCpf(string cpf)
        {
            return await _IProdutor.BuscarPorCpf(p => p.Cpf.Equals(cpf));
        }

        public async Task<Produtor> BuscarPorId(int id)
        {
            return await _IProdutor.BuscarPorId(id);
        }

        public async Task<List<Produtor>> BuscarTodos()
        {
            return await _IProdutor.BuscarTodos();
        }
        public async Task CadastrarProdutor(Produtor produtor)
        {
           await _IProdutor.Adicionar(produtor);
        }

        public async Task EditarProdutor(Produtor produtor)
        {
            await _IEndereco.Atualizar(produtor.Endereco);
            await _IProdutor.Atualizar(produtor);
        }

        public bool ValidarCpf(string cpf)
        {
            if (!cpf.All(char.IsDigit)) //Verifica se str é Number
            {
                return false;
            }
            string valor = cpf.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            return true;
        }
    }
}
