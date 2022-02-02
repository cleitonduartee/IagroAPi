using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServico
{
    public interface IServicoProdutor
    {
        Task CadastrarProdutor(Produtor produtor);
        Task EditarProdutor(Produtor produtor);
        Task<Produtor> BuscarPorCpf(string cpf);
        Task<Produtor> BuscarPorId(int id);
        Task<List<Produtor>> BuscarTodos();
        bool ValidarCpf(string cpf);

    }
}
