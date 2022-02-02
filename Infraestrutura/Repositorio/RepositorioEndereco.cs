using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Crud;

namespace Infraestrutura.Repositorio
{
    public class RepositorioEndereco : RepositorioCrud<Endereco>, IEndereco
    {
        public RepositorioEndereco(ApiContext context) : base(context)
        {
        }
    }
}
