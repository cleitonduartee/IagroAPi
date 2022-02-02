using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Crud;

namespace Infraestrutura.Repositorio
{
    public class RepositorioMunicipio : RepositorioCrud<Municipio>, IMunicipio
    {
        public RepositorioMunicipio(ApiContext context) : base(context)
        {
        }
    }
}
