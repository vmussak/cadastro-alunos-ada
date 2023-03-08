using System;
namespace Ada.Aluno.Core
{
	public class BaseEntity
	{
		public BaseEntity()
		{
			Messages = new List<string>();
        }

		public List<string> Messages { get; set; }

		public bool IsValid { get; set; }
	}
}

