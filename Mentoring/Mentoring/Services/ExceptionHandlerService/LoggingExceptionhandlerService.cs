using System;
using Microsoft.Extensions.Logging;

namespace Mentoring.Services.ExceptionHandlerService
{
	public class LoggingExceptionHandlerService : IExceptionHandlerService
	{
		private ILogger<LoggingExceptionHandlerService> _logger;

		public LoggingExceptionHandlerService(ILogger<LoggingExceptionHandlerService> logger)
		{
			_logger = logger;
		}

		public void Process(Exception exception)
		{
			_logger.Log(LogLevel.Error, exception, "Error occured during processing request.");
		}
	}
}
