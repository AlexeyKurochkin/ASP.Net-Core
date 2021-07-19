namespace Mentoring.Api.Tests.Swagger.Models
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.3.0 (Newtonsoft.Json v11.0.0.0)")]
	public partial class EmployeeTerritories 
	{
		[Newtonsoft.Json.JsonProperty("EmployeeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int EmployeeId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("TerritoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string TerritoryId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Employee", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Employee Employee { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Territory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Territory Territory { get; set; }
    
    
	}
}