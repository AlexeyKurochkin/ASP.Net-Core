namespace Mentoring.Api.Tests.Swagger.Models
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.3.0 (Newtonsoft.Json v11.0.0.0)")]
	public partial class Territory 
	{
		[Newtonsoft.Json.JsonProperty("TerritoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string TerritoryId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("TerritoryDescription", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string TerritoryDescription { get; set; }
    
		[Newtonsoft.Json.JsonProperty("RegionId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int RegionId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Region", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Region Region { get; set; }
    
		[Newtonsoft.Json.JsonProperty("EmployeeTerritories", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.Collections.Generic.ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
    
    
	}
}