using ControleDeSafra.Repository;
using ControleDeSafra.Domain.Entidade;

namespace ControleSafra.Testes
{
    public class UnitTest1
    {
        [Fact]
        public void Carregar()
        {
            List<Carregamento> carregamentoRepositorio = 
                new CarregamentoRepositorio().ConsulteCarregamentos();

            Assert.NotEmpty(carregamentoRepositorio);
        }

        [Fact]
        public void Inserir()
        {
            Carregamento carregamento = new()
            {
                DataCarregamento = Convert.ToDateTime("24/05/2022"),
                Contratante = new()
                {
                    Nome = "Joselino"
                },
                LocalDestino = "Teste2",
                LocalOrigem = "Teste3",
                Motorista = new()
                {
                    Nome = "Ronaldo"
                },
                Peso = 1256
            };

            new CarregamentoRepositorio().AdicioneCarregamento(carregamento);
        }
    }
}