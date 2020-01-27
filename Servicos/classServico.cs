using System;
using System.Data.SqlClient;


namespace Servicos
{
    public class classServico
    {
        string sConn = Config.Default.ConnectionString;
        private string _credencial = Config.Default.Credencial;
      
        public string Credencial
        {
            get { return _credencial; }
        }
        public DateTime horalocal
        {
            get { return DateTime.Now; }
        }

        public string sconexao
        {
            get { return sConn; }
        }

        public Boolean GravarMovimento(string param_credencial, DateTime param_hora)
        {
            bool _retorna = false;
            // Gerando um objeto conexão configurado pela propriedade sconexao
            SqlConnection _objconn = new SqlConnection(sconexao);
            // configurar o command
            SqlCommand _comandosql = new SqlCommand();
            try
            {
                string data_hora;
                data_hora = param_hora.Year.ToString() +
                    param_hora.Month.ToString().PadLeft(2, '0') +
                    param_hora.Day.ToString().PadLeft(2, '0') + " " +
                    param_hora.Hour.ToString().PadLeft(2, '0') + ":" +
                    param_hora.Minute.ToString().PadLeft(2, '0') + ":" +
                    param_hora.Second.ToString().PadLeft(2, '0');

                _objconn.Open(); //abrir conexão para uso no command
                _comandosql.Connection = _objconn;
                _comandosql.CommandType = System.Data.CommandType.Text;
                _comandosql.CommandText = " INSERT INTO MOVIMENTO(DATA_MOVIMENTO, CREDENCIAL)";
                _comandosql.CommandText += " VALUES('" + data_hora + "','" + param_credencial + "')";
                //Acionamento
                _comandosql.ExecuteNonQuery();
                _retorna = true;
                return _retorna;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                _objconn.Close();
                _objconn.Dispose();
                _comandosql.Dispose();
            }
        }
    }
}
