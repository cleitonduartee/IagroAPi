using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Repositorio.Crud;

namespace Infraestrutura.Repositorio
{
    public class RepositorioMunicipio : RepositorioCrud<Municipio>, IMunicipio
    {
    }
}
