namespace Mentoring.Api.Tests.Swagger.Models
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.3.0 (Newtonsoft.Json v11.0.0.0)")]
	public partial class Shipper 
	{
		[Newtonsoft.Json.JsonProperty("ShipperId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int ShipperId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("CompanyName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string CompanyName { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Phone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Phone { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Orders", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.Collections.Generic.ICollection<Order> Orders { get; set; }
    
    
	}
}