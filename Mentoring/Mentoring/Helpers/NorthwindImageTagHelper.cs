using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Mentoring.Helpers
{
	[HtmlTargetElement("a", Attributes = "northwind-id")]
	public class NorthwindImageTagHelper : TagHelper
	{
		public int NorthwindId { get; set; }
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.Attributes.SetAttribute("href", $"images/{NorthwindId}");
		}
	}
}
