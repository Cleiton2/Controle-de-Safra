namespace Controle_de_Safra.Models
{
    public class CarregamentoModel
    {
        public DateTime DataCarregamento { get; set; }

        public string NomeMotorista { get; set; }

        public string NomeLocalOrigem { get; set; }

        public string NomeLocalDestino { get; set; }

        public string NomeContratante { get; set; }

        public float Peso { get; set; }
    }
}
