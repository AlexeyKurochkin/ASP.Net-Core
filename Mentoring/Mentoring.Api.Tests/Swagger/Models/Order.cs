namespace Mentoring.Api.Tests.Swagger.Models
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.3.0 (Newtonsoft.Json v11.0.0.0)")]
	public partial class Order 
	{
		[Newtonsoft.Json.JsonProperty("OrderId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int OrderId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("CustomerId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string CustomerId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("EmployeeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? EmployeeId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("OrderDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.DateTimeOffset? OrderDate { get; set; }
    
		[Newtonsoft.Json.JsonProperty("RequiredDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.DateTimeOffset? RequiredDate { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ShippedDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.DateTimeOffset? ShippedDate { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ShipVia", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? ShipVia { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Freight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public double? Freight { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ShipName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ShipName { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ShipAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ShipAddress { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ShipCity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ShipCity { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ShipRegion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ShipRegion { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ShipPostalCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ShipPostalCode { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ShipCountry", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ShipCountry { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Customer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Customer Customer { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Employee", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Employee Employee { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ShipViaNavigation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Shipper ShipViaNavigation { get; set; }
    
		[Newtonsoft.Json.JsonProperty("OrderDetails", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.Collections.Generic.ICollection<OrderDetails> OrderDetails { get; set; }
    
    
	}
}