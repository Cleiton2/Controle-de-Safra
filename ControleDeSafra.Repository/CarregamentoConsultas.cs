using ControleDeSafra.Domain.Entidade;
using ControleDeSafra.Repository.Interfaces;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace ControleDeSafra.Repository
{
    public class CarregamentoConsultas : IConsultaCarregamento
    {
        public void AdicioneCarregamento(Carregamento carregamento)
        {
            DbConnection dbConnection = new();
            using FbConnection con = dbConnection.ObtenhaConexao();
            using FbCommand command = new();

            command.Connection = con;
            command.Transaction = con.BeginTransaction();

            command.CommandText = @"INSERT INTO TBCARREGAMENTO (CARCODIGO, CARDATA, CARMOTORISTA, CARORIGEM, CARDESTINO, CARCONTRATANTE, CARPESO)
                                                    VALUES ((SELECT MAX(CARCODIGO) + 1 FROM TBCARREGAMENTO), @CARDATA, @CARMOTORISTA, @CARORIGEM, @CARDESTINO, @CARCONTRATANTE, @CARPESO)";

            command.Parameters.Add("@CARDATA", carregamento.DataCarregamento.ToString("dd/MM/yyyy"));
            command.Parameters.Add("@CARMOTORISTA", carregamento.Motorista.Nome);
            command.Parameters.Add("@CARORIGEM", carregamento.LocalOrigem);
            command.Parameters.Add("@CARDESTINO", carregamento.LocalDestino);
            command.Parameters.Add("@CARCONTRATANTE", carregamento.Contratante.Nome);
            command.Parameters.Add("@CARPESO", carregamento.Peso);

            command.ExecuteNonQuery();
            command.Transaction.Commit();
        }

        public void AtualizeCarregamento(Carregamento carregamento)
        {
            DbConnection dbConnection = new();
            using FbConnection con = dbConnection.ObtenhaConexao();
            using FbCommand command = new();

            command.Connection = con;
            command.Transaction = con.BeginTransaction();

            command.CommandText = @"UPDATE TBCARREGAMENTO 
                                    SET CARDATA = @CARDATA, CARMOTORISTA = @CARMOTORISTA, CARORIGEM = @CARORIGEM, 
                                    CARDESTINO = @CARDESTINO, CARCONTRATANTE = @CARCONTRATANTE, 
                                    CARPESO = @CARPESO WHERE CARCODIGO = @CARCODIGO";

            command.Parameters.Add("@CARDATA", carregamento.DataCarregamento.ToString("dd/MM/yyyy"));
            command.Parameters.Add("@CARMOTORISTA", carregamento.Motorista.Nome);
            command.Parameters.Add("@CARORIGEM", carregamento.LocalOrigem);
            command.Parameters.Add("@CARDESTINO", carregamento.LocalDestino);
            command.Parameters.Add("@CARCONTRATANTE", carregamento.Contratante.Nome);
            command.Parameters.Add("@CARPESO", carregamento.Peso);
            command.Parameters.Add("@CARPESO", carregamento.Codigo);

            command.ExecuteNonQuery();
            command.Transaction.Commit();
        }

        public Carregamento ConsulteCarregamento(string? descricao)
        {
            DbConnection dbConnection = new();
            using FbConnection con = dbConnection.ObtenhaConexao();
            using FbCommand command = new();

            command.Connection = con;
            command.Transaction = con.BeginTransaction();

            command.CommandText = "SELECT * FROM TBCARREGAMENTO WHERE  ";

            FbDataReader dr = command.ExecuteReader();

            return MonteDadosCarregamento(dr);
        }

        public Carregamento ConsulteCarregamentoPorCodigo(int codigo)
        {
            throw new NotImplementedException();
        }

        public List<Carregamento> ConsulteCarregamentos()
        {
            DbConnection dbConnection = new();
            using FbConnection con = dbConnection.ObtenhaConexao();
            using FbCommand command = new();

            command.Connection = con;
            command.Transaction = con.BeginTransaction();

            command.CommandText = "SELECT * FROM TBCARREGAMENTO";

            FbDataReader rd = command.ExecuteReader();

            List<Carregamento> carregamentos = [];

            while (rd.Read())
            {
                carregamentos.Add(MonteDadosCarregamento(rd));
            }

            DbConnection.EncerreConexao(rd, con);

            return carregamentos;
        }

        public void RemovaCarregamento(int codigo)
        {
            
        }

        private static Carregamento MonteDadosCarregamento(FbDataReader dr)
        {
            Carregamento carregamento = new()
            {
                Codigo = dr.GetInt32("CARCODIGO"),
                DataCarregamento = Convert.ToDateTime(dr.GetString("CARDATA")),
                Contratante = new()
                {
                    Nome = dr.GetString("CARCONTRATANTE")
                },
                LocalDestino = dr.GetString("CARDESTINO")
                ,
                LocalOrigem = dr.GetString("CARORIGEM")
            };

            return carregamento;
        }
    }
}