using System;
using System.Data.SqlClient;

namespace Ada.Aluno.Database
{
	public class MinhaConexao : IDisposable
	{
        private readonly SqlConnection _connection;

		public MinhaConexao(string connectionString)
		{
            _connection = new SqlConnection(connectionString);
            _connection.Open();
		}


        //DbContext


        public SqlCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}

