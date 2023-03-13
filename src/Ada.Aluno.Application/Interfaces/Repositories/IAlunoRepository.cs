using System;
namespace Ada.Aluno.Application.Interfaces.Repositories
{
	public interface IAlunoRepository
	{
        Core.Aluno Adicionar(Aluno.Core.Aluno aluno);

		List<Aluno.Core.Aluno> BuscarTodos();
	}
}

