using System;
using Ada.Aluno.Application.Interfaces.Repositories;

namespace Ada.Aluno.Database.Repositories
{
	public class AlunoRepository : IAlunoRepository
	{
        private readonly MinhaConexao _conexao;
		public AlunoRepository(MinhaConexao conexao)
		{
            _conexao = conexao;
		}

        public void Adicionar(Core.Aluno aluno)
        {
            using var command = _conexao.CreateCommand();
            
            command.CommandText = "INSERT INTO Aluno (Nome, Cidade, NomeDaMae)" +
                $" VALUES  ('{aluno.Nome}', '{aluno.Cidade}', '{aluno.NomeMae}')";

            command.ExecuteNonQuery();
        }

        public List<Core.Aluno> BuscarTodos()
        {
            var listaDeAlunos = new List<Core.Aluno>();

            using var command = _conexao.CreateCommand();

            command.CommandText = "SELECT * FROM Aluno";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                listaDeAlunos.Add(new Core.Aluno
                {
                    Id = (int)reader["Id"],
                    Nome = reader["Nome"].ToString()!,
                    Cidade = reader["Cidade"].ToString()!,
                    NomeMae = reader["NomeDaMae"]?.ToString()
                });
            }

            return listaDeAlunos;
        }
    }
}

