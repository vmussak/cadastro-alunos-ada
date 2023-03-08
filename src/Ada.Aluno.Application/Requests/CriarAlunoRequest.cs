using System;
namespace Ada.Aluno.Application.Requests
{
	public class CriarAlunoRequest
	{
		public CriarAlunoRequest()
		{
		}

        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string? NomeMae { get; set; }
    }
}

