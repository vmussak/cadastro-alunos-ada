using System;
using Ada.Aluno.Application.Interfaces.Repositories;
using Ada.Aluno.Database.Mappings;

namespace Ada.Aluno.Database.Repositories
{
	public class AlunoRepository : IAlunoRepository
	{
        private readonly AlunoContext _db;
        public AlunoRepository(AlunoContext db)
		{
            _db = db;
		}

        public Core.Aluno Adicionar(Core.Aluno aluno)
        {
            var alunoModel = aluno.ToModel();

            _db.Add(alunoModel);
            _db.SaveChanges();

            return alunoModel.ToCore();
        }

        public List<Core.Aluno> BuscarTodos()
        {
            return _db.Alunos
                .Select(x => x.ToCore())
                .ToList();
        }

        public Core.Aluno? BuscarPorId(int id)
        {
            return _db.Alunos
                .FirstOrDefault(x => x.Id == id)
                ?.ToCore();
        }
    }
}

