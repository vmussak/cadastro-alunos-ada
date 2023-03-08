using System;
using Ada.Aluno.Application.Requests;

namespace Ada.Aluno.Application.Interfaces
{
	public interface IBuscarAlunosUseCase
	{
        ApiResponse Execute();
    }
}

