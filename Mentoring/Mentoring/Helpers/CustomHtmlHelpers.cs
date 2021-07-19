using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.Helpers
{
	public static class CustomHtmlHelpers
	{
		public static IHtmlContent NorthwindImageLink<TModel>(this IHtmlHelper<TModel> htmlHelper,
			string imageId, string displayText)
		{
			return htmlHelper.RouteLink(displayText, new {controller = "categories", action = "Image", id = imageId});
		}
	}
}
