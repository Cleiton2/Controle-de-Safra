namespace ControleDeSafra.Domain.Entidade
{
    public class Carregamento
    {
        public int Codigo { get; set; }

        public DateTime DataCarregamento { get; set; }

        public Motorista Motorista { get; set; }

        public string LocalOrigem { get; set; }

        public string LocalDestino { get; set; } 

        public Contratante Contratante { get; set; }

        public float Peso {  get; set; }
    }
}