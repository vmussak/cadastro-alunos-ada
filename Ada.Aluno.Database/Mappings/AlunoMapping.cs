using System;
using Ada.Aluno.Database.Models;

namespace Ada.Aluno.Database.Mappings
{
	public static class AlunoMapping
	{
		public static AlunoModel ToModel(this Aluno.Core.Aluno aluno)
		{
			return new AlunoModel
			{
				Id = aluno.Id,
				Nome = aluno.Nome,
				Cidade = aluno.Cidade,
				NomeMae = aluno.NomeMae
			};
		}

		public static Aluno.Core.Aluno ToCore(this AlunoModel alunoModel)
		{
			return new Core.Aluno {
				Id = alunoModel.Id,
				Nome = alunoModel.Nome,
				Cidade = alunoModel.Cidade,
				NomeMae = alunoModel.NomeMae
			};
        }
    }
}

