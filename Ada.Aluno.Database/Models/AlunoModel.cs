using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ada.Aluno.Database.Models
{
	public class AlunoModel
	{
		public AlunoModel()
		{
		}

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string? NomeMae { get; set; }
    }
}

