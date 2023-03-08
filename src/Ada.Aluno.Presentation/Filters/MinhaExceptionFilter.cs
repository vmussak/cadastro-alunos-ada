using System;
using Ada.Aluno.Application;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Ada.Aluno.Presentation.Filters
{
	public class MinhaExceptionFilter : IExceptionFilter
	{
		public MinhaExceptionFilter()
		{
		}

        public void OnException(ExceptionContext context)
        {
            var valorParaRetornar = new List<string> {
                "Ocorreu o seguinte erro:",
                context.Exception.Message
            };

            context.Result = new JsonResult(valorParaRetornar)
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}

