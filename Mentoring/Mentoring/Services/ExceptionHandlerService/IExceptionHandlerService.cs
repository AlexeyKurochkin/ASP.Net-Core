using System;

namespace Mentoring.Services.ExceptionHandlerService
{
	public interface IExceptionHandlerService
	{
		void Process(Exception exception);
	}
}
