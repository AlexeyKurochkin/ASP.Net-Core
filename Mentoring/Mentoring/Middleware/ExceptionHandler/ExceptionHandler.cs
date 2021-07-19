using System;
using System.Threading.Tasks;
using Mentoring.Services.ExceptionHandlerService;
using Microsoft.AspNetCore.Http;

namespace Mentoring.Middleware.ExceptionHandler
{
	public class ExceptionHandler
	{
		private readonly RequestDelegate _next;

		public ExceptionHandler(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context, IExceptionHandlerService exceptionHandlerService)
		{
			try
			{
				await _next.Invoke(context);
			}
			catch (Exception exception)
			{
				exceptionHandlerService.Process(exception);
			}
		}
	}
}
