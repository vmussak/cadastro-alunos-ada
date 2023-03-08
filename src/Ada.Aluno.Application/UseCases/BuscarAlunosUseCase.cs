using System;
using System.Net;
using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Application.Interfaces.Repositories;
using Ada.Aluno.Core;

namespace Ada.Aluno.Application.UseCases
{
	public class BuscarAlunosUseCase : IBuscarAlunosUseCase
	{
        private readonly IAlunoRepository _repository;
		public BuscarAlunosUseCase(IAlunoRepository repository)
		{
            _repository = repository;
		}

        public ApiResponse Execute()
        {
            var alunos = _repository.BuscarTodos();

            return new ApiResponse
            {
                StatusCode = HttpStatusCode.OK,
                Data = alunos
            };
        }
    }
}

