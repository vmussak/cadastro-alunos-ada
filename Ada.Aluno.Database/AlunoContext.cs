using System;
using Ada.Aluno.Database.Configuration;
using Ada.Aluno.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Ada.Aluno.Database
{
	public class AlunoContext : DbContext
	{
		private readonly string _connectionString;
		public AlunoContext(string connectionString)
		{
			_connectionString = connectionString;
        }

		public DbSet<AlunoModel> Alunos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString)
				.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
			//Retry
			//LazyLoad
			//Log
			//Interceptadores WITH (NOLOCK)
			//Replace
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AlunoConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}

