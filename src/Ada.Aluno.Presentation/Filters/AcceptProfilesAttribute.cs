using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ada.Aluno.Presentation.Filters
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class AcceptProfilesAttribute : ActionFilterAttribute
	{
		private readonly string[] _profiles;
		public AcceptProfilesAttribute(params string[] profiles)
		{
			_profiles = profiles;
		}


        public override void OnActionExecuting(ActionExecutingContext context)
        {
			var profileQueVeioDoHeader = context.HttpContext.Request.Headers["Profile"];

			var mensagem = new
			{
				Error = "Você não possui acesso à este recurso."
			};

			if (string.IsNullOrEmpty(profileQueVeioDoHeader))
			{
				context.Result = new JsonResult(mensagem)
				{
					StatusCode = StatusCodes.Status401Unauthorized
				};
			}
			else if (!_profiles.Contains((string)profileQueVeioDoHeader))
			{
                context.Result = new JsonResult(mensagem)
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
        }
    }
}

