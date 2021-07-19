using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mentoring.Components
{
	public class Breadcrumbs : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			Breadcrumb breadcrumb = new Breadcrumb();
			breadcrumb.ControllerName = RouteData.Values["controller"].ToString();
			breadcrumb.ActionName = RouteData.Values["action"].ToString();
			return View(breadcrumb);
		}
	}

	public class Breadcrumb
	{
		public string ControllerName { get; set; }
		public string ActionName { get; set; }
	}

}
