using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mentoring.ViewModels;
using Microsoft.AspNetCore.Diagnostics;

namespace Mentoring.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Error()
		{
			Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
			return View(new ErrorViewModel
				{RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Exception = exception});
		}
	}
}