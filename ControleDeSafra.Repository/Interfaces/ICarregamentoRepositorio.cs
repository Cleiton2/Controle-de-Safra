using ControleDeSafra.Domain.Entidade;

namespace ControleDeSafra.Repository.Interfaces
{
    public interface ICarregamentoRepositorio : IRepositorio
    {
        Carregamento ConsulteCarregamentoPorCodigo(int codigo);

        Carregamento ConsulteCarregamento(string? descricao);

        List<Carregamento> ConsulteCarregamentos();

        void AdicioneCarregamento(Carregamento carregamento);

        void AtualizeCarregamento(Carregamento carregamento);

        void RemovaCarregamento(int codigo);
    }
}