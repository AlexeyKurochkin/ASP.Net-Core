namespace Mentoring.Api.Tests.Swagger.Models
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.3.0 (Newtonsoft.Json v11.0.0.0)")]
	public partial class CustomerCustomerDemo 
	{
		[Newtonsoft.Json.JsonProperty("CustomerId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string CustomerId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("CustomerTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string CustomerTypeId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Customer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Customer Customer { get; set; }
    
		[Newtonsoft.Json.JsonProperty("CustomerType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public CustomerDemographics CustomerType { get; set; }
    
    
	}
}