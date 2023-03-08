using System;
namespace Ada.Aluno.Application.Interfaces.Repositories
{
	public interface IAlunoRepository
	{
		void Adicionar(Aluno.Core.Aluno aluno);

		List<Aluno.Core.Aluno> BuscarTodos();
	}
}

