using System;
using Ada.Aluno.Application.Interfaces;
using Ada.Aluno.Application.Requests;
using System.Net;
using Ada.Aluno.Core;
using Ada.Aluno.Application.Interfaces.Repositories;

namespace Ada.Aluno.Application.UseCases
{
	public class CriarAlunoUseCase : ICriarAlunoUseCase
	{
		private readonly IAlunoRepository _alunoRepository;

        public CriarAlunoUseCase(IAlunoRepository alunoRepository)
		{
			_alunoRepository = alunoRepository;
        }

        public ApiResponse Execute(CriarAlunoRequest request)
		{
            var aluno = new Ada.Aluno.Core.Aluno(
				request.Nome,
				request.Cidade,
				request.NomeMae
			);

			if (!aluno.IsValid)
			{
				return new ApiResponse
				{
					StatusCode = HttpStatusCode.Conflict,
					Messages = aluno.Messages
				};
			}

			_alunoRepository.Adicionar(aluno);

            return new ApiResponse
			{
				StatusCode = HttpStatusCode.Created,
				Data = aluno
			};
			
		}
    }
}

