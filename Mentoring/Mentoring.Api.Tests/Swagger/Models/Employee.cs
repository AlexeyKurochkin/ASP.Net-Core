namespace Mentoring.Api.Tests.Swagger.Models
{
	[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.3.0 (Newtonsoft.Json v11.0.0.0)")]
	public partial class Employee 
	{
		[Newtonsoft.Json.JsonProperty("EmployeeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int EmployeeId { get; set; }
    
		[Newtonsoft.Json.JsonProperty("LastName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string LastName { get; set; }
    
		[Newtonsoft.Json.JsonProperty("FirstName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string FirstName { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Title { get; set; }
    
		[Newtonsoft.Json.JsonProperty("TitleOfCourtesy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string TitleOfCourtesy { get; set; }
    
		[Newtonsoft.Json.JsonProperty("BirthDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.DateTimeOffset? BirthDate { get; set; }
    
		[Newtonsoft.Json.JsonProperty("HireDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.DateTimeOffset? HireDate { get; set; }
    
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
    
		[Newtonsoft.Json.JsonProperty("HomePhone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string HomePhone { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Extension", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Extension { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Photo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public byte[] Photo { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Notes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string Notes { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ReportsTo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public int? ReportsTo { get; set; }
    
		[Newtonsoft.Json.JsonProperty("PhotoPath", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public string PhotoPath { get; set; }
    
		[Newtonsoft.Json.JsonProperty("ReportsToNavigation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public Employee ReportsToNavigation { get; set; }
    
		[Newtonsoft.Json.JsonProperty("EmployeeTerritories", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.Collections.Generic.ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
    
		[Newtonsoft.Json.JsonProperty("InverseReportsToNavigation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.Collections.Generic.ICollection<Employee> InverseReportsToNavigation { get; set; }
    
		[Newtonsoft.Json.JsonProperty("Orders", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
		public System.Collections.Generic.ICollection<Order> Orders { get; set; }
    
    
	}
}