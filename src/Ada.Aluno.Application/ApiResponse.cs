using System;
using System.Net;

namespace Ada.Aluno.Application
{
	public class ApiResponse
	{
		public ApiResponse()
		{
			Messages = new List<string>();
		}

		public HttpStatusCode StatusCode { get; set; }
		public object Data { get; set; }
		public List<string> Messages { get; set; }
	}
}

