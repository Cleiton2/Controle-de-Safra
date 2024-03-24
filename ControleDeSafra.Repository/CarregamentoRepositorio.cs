using ControleDeSafra.Domain.Entidade;
using ControleDeSafra.Repository.Interfaces;

namespace ControleDeSafra.Repository
{
    public class CarregamentoRepositorio : ICarregamentoRepositorio
    {
        public void AdicioneCarregamento(Carregamento carregamento) =>
            new CarregamentoConsultas().AdicioneCarregamento(carregamento);

        public void AtualizeCarregamento(Carregamento carregamento) =>
            new CarregamentoConsultas().AtualizeCarregamento(carregamento);

        public Carregamento ConsulteCarregamento(string? descricao) =>
            new CarregamentoConsultas().ConsulteCarregamento(descricao);

        public Carregamento ConsulteCarregamentoPorCodigo(int codigo) =>
            new CarregamentoConsultas().ConsulteCarregamentoPorCodigo(codigo);

        public List<Carregamento> ConsulteCarregamentos() => 
            new CarregamentoConsultas().ConsulteCarregamentos();

        public void RemovaCarregamento(int codigo) =>
            new CarregamentoConsultas().RemovaCarregamento(codigo);
    }
}