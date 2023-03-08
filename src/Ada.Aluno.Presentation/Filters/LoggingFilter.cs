using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ada.Aluno.Presentation.Filters
{
	public class LoggingFilter : IActionFilter
	{
        private readonly ILogger<LoggingFilter> _logger;

		public LoggingFilter(ILogger<LoggingFilter> logger)
		{
            _logger = logger;
		}

        //antes da action
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.ActionDescriptor.DisplayName;
            var parametros = context.ActionArguments;
            _logger.LogInformation($"Action '{action}' foi chamada com os parâmetros {parametros}");
        }

        //depois da action
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var action = context.ActionDescriptor.DisplayName;
            var resultado = context.Result;
            var tempo = context.HttpContext.Response.Headers["X-Elapsed-Time"];
            _logger.LogInformation($"Action '{action}' foi encerrada com o resultado {resultado}, em {tempo} ms");
        }
    }
}

