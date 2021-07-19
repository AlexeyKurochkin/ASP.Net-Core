namespace Mentoring.Api.Tests.Swagger.Models
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.3.0 (Newtonsoft.Json v11.0.0.0)")]
	public partial class OrderDetails 
	{
		[Newtonsoft.Json.JsonProperty("OrderId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int OrderId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ProductId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int ProductId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("UnitPrice", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public double UnitPrice { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Quantity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int Quantity { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Discount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public double Discount { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Order", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Order Order { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Product", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Product Product { get; set; }
    
    
	}
}