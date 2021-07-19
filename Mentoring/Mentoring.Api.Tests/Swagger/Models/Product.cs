namespace Mentoring.Api.Tests.Swagger.Models
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.3.0 (Newtonsoft.Json v11.0.0.0)")]
	public partial class Product 
	{
		[Newtonsoft.Json.JsonProperty("ProductId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int ProductId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ProductName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string ProductName { get; set; }
    
		[Newtonsoft.Json.JsonProperty("SupplierId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? SupplierId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("CategoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? CategoryId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("QuantityPerUnit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string QuantityPerUnit { get; set; }
    
		[Newtonsoft.Json.JsonProperty("UnitPrice", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public double? UnitPrice { get; set; }
    
		[Newtonsoft.Json.JsonProperty("UnitsInStock", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? UnitsInStock { get; set; }
    
		[Newtonsoft.Json.JsonProperty("UnitsOnOrder", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? UnitsOnOrder { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ReorderLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? ReorderLevel { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Discontinued", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public bool Discontinued { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Category Category { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Supplier", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Supplier Supplier { get; set; }
    
		[Newtonsoft.Json.JsonProperty("OrderDetails", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.Collections.Generic.ICollection<OrderDetails> OrderDetails { get; set; }
    
    
	}
}