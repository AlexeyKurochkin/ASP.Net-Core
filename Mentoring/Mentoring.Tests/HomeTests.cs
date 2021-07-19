using System;
using Mentoring.Controllers;
using Mentoring.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Mentoring.Tests
{
	class HomeTests
	{
		[Test]
		public void Index_ReturnsViewResult()
		{
			var controller = new HomeController();
			var result = controller.Index();

			Assert.AreEqual(typeof(ViewResult), result.GetType());
		}

		[Test]
		public void Error_ReturnsViewResult()
		{
			var controller = new HomeController();

			var exceptionHandlerFeature = new ExceptionHandlerFeature();
			exceptionHandlerFeature.Error = new Exception();

			var httpContext = new DefaultHttpContext();
			httpContext.Features.Set<IExceptionHandlerFeature>(exceptionHandlerFeature);

			var controllerContext = new ControllerContext();
			controllerContext.HttpContext = httpContext;

			controller.ControllerContext = controllerContext;
			var result = controller.Error();

			Assert.AreEqual(typeof(ViewResult), result.GetType());

			var viewResult = (ViewResult) result;
			Assert.IsAssignableFrom<ErrorViewModel>(viewResult.Model);
		}
	}
}
