using System;
using Ada.Aluno.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ada.Aluno.Database.Configuration
{
	public class AlunoConfiguration : IEntityTypeConfiguration<AlunoModel>
	{
		public AlunoConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<AlunoModel> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(x => x.Cidade)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(x => x.NomeMae)
                .HasColumnType("VARCHAR(50)");
        }
    }
}

