using System;
using Ada.Aluno.Application.Requests;

namespace Ada.Aluno.Application.Interfaces
{
	public interface ICriarAlunoUseCase
	{
		ApiResponse Execute(CriarAlunoRequest request);
	}
}

