using Mentoring.Services.ConfigReader;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Mentoring.ActionFilters
{
	public class LoggingActionFilter : IActionFilter
	{
		private ILogger<LoggingActionFilter> _logger;
		private IConfigReader _configReader;

		public LoggingActionFilter(ILogger<LoggingActionFilter> logger, IConfigReader configReader)
		{
			_logger = logger;
			_configReader = configReader;
		}
		public void OnActionExecuting(ActionExecutingContext context)
		{
			string controllerName = context.Controller.ToString();
			string actionName = context.ActionDescriptor.DisplayName;
			_logger.LogInformation($"{actionName} on {controllerName} started");
			if (_configReader.LogActionArguments())	
			{
				foreach (string actionArgumentsKey in context.ActionArguments.Keys)
				{
					_logger.LogInformation("Action arguments:");
					_logger.LogInformation($"{actionArgumentsKey} : {context.ActionArguments[actionArgumentsKey]}");
				}
			}
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			string controllerName = context.Controller.ToString();
			string actionName = context.ActionDescriptor.DisplayName;
			_logger.LogInformation($"{actionName} on {controllerName} ended");
		}
	}
}
