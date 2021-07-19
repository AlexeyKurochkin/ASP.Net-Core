namespace Mentoring.Api.Tests.Swagger.Models
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.3.0 (Newtonsoft.Json v11.0.0.0)")]
	public partial class CustomerDemographics 
	{
		[Newtonsoft.Json.JsonProperty("CustomerTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string CustomerTypeId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("CustomerDesc", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string CustomerDesc { get; set; }
    
		[Newtonsoft.Json.JsonProperty("CustomerCustomerDemo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.Collections.Generic.ICollection<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
    
    
	}
}