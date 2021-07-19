namespace Mentoring.Api.Tests.Swagger.Models
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.3.0 (Newtonsoft.Json v11.0.0.0)")]
	public partial class Supplier 
	{
		[Newtonsoft.Json.JsonProperty("SupplierId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int SupplierId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("CompanyName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string CompanyName { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ContactName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ContactName { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ContactTitle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ContactTitle { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Address", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Address { get; set; }
    
		[Newtonsoft.Json.JsonProperty("City", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string City { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Region", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Region { get; set; }
    
		[Newtonsoft.Json.JsonProperty("PostalCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string PostalCode { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Country", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Country { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Phone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Phone { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Fax", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Fax { get; set; }
    
		[Newtonsoft.Json.JsonProperty("HomePage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string HomePage { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Products", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.Collections.Generic.ICollection<Product> Products { get; set; }
    
    
	}
}