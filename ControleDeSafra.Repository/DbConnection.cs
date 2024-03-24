using FirebirdSql.Data.FirebirdClient;

namespace ControleDeSafra.Repository
{
    public class DbConnection
    {
        private readonly FbConnection connection;
        public DbConnection()
        {
            string conexao2 =
                @"User=SYSDBA;Password=masterkey;Database=C:\Users\virro\OneDrive\Documentos\PastaBD\SAFRA.FB4;DataSource=localhost;
                  Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;
                  MaxPoolSize=50;Packet Size=8192;\r\nServerType=0;";

            connection = new FbConnection(conexao2);
        }

        public FbConnection ObtenhaConexao()
        {
            connection.Open();
            return connection;
        }

        public static void EncerreConexao(FbDataReader dr, FbConnection con)
        {
            dr.Close();
            con.Close();
        }
    }
}