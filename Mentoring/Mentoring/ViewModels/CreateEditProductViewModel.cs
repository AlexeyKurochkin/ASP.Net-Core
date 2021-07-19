using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mentoring.ViewModels
{
	public class CreateEditProductViewModel
	{
		public int ProductId { get; set; }
		[Required, MaxLength(40)]
		public string ProductName { get; set; }
		[Required]
		public int? SupplierId { get; set; }
		[Required]
		public int? CategoryId { get; set; }
		[Required, MaxLength(20)]
		public string QuantityPerUnit { get; set; }
		[Range(0, double.MaxValue)]
		public decimal? UnitPrice { get; set; }
		[Range(0, short.MaxValue)]
		public short? UnitsInStock { get; set; }
		[Range(0, short.MaxValue)]
		public short? UnitsOnOrder { get; set; }
		[Range(0, short.MaxValue)]
		public short? ReorderLevel { get; set; }
		public bool Discontinued { get; set; }
		public SelectList Category { get; set; }
		public SelectList Supplier { get; set; }
	}
}
