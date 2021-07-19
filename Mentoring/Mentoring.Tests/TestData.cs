using System.Collections.Generic;
using System.Linq;
using Mentoring.Models;

namespace Mentoring.Tests
{
	public class TestData
	{
		public static IQueryable<Category> GetCategoriesTestData()
		{
			List<Category> categories = new List<Category>();
			categories.Add(new Category() {CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales", CategoryId = 1});
			categories.Add(new Category() {CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings", CategoryId = 2});
			categories.Add(new Category() {CategoryName = "Confections", Description = "Desserts, candies, and sweet breads", CategoryId = 3});
			return categories.AsQueryable();
		}

		public static IQueryable<Product> GetProductsTestData()
		{
			var beveragesCategory = GetCategoriesTestData().First(category => category.CategoryId == 1);
			var condimentsCategory = GetCategoriesTestData().First(category => category.CategoryId == 2);
			var exoticLiquidsSupplier = GetSupplierTestData().First();

			List<Product> products = new List<Product>();
			var chai = new Product();
			chai.Category = beveragesCategory;
			chai.CategoryId = beveragesCategory.CategoryId;
			chai.Discontinued = false;
			chai.ProductId = 1;
			chai.ProductName = "Chai";
			chai.QuantityPerUnit = "10 boxes x 20 bags";
			chai.ReorderLevel = 10;
			chai.Supplier = exoticLiquidsSupplier;
			chai.SupplierId = exoticLiquidsSupplier.SupplierId;
			chai.UnitPrice = 18;
			chai.UnitsInStock = 0;
			chai.UnitsOnOrder = 39;
			products.Add(chai);

			var chang = new Product();
			chang.Category = beveragesCategory;
			chang.CategoryId = beveragesCategory.CategoryId;
			chang.Discontinued = false;
			chang.ProductId = 2;
			chang.ProductName = "Chang";
			chang.QuantityPerUnit = "24 - 12 oz bottles";
			chang.ReorderLevel = 25;
			chang.Supplier = exoticLiquidsSupplier;
			chang.SupplierId = exoticLiquidsSupplier.SupplierId;
			chang.UnitPrice = 19;
			chang.UnitsInStock = 40;
			chang.UnitsOnOrder = 17;
			products.Add(chang);

			var aniseedSyrup = new Product();
			aniseedSyrup.Category = condimentsCategory;
			aniseedSyrup.CategoryId = condimentsCategory.CategoryId;
			aniseedSyrup.Discontinued = false;
			aniseedSyrup.ProductId = 3;
			aniseedSyrup.ProductName = "Aniseed Syrup";
			aniseedSyrup.QuantityPerUnit = "12 - 550 ml bottles";
			aniseedSyrup.ReorderLevel = 25;
			aniseedSyrup.Supplier = exoticLiquidsSupplier;
			aniseedSyrup.SupplierId = exoticLiquidsSupplier.SupplierId;
			aniseedSyrup.UnitPrice = 10;
			aniseedSyrup.UnitsInStock = 70;
			aniseedSyrup.UnitsOnOrder = 13;
			products.Add(aniseedSyrup);

			return products.AsQueryable();
		}

		public static IQueryable<Supplier> GetSupplierTestData()
		{
			return new[] { new Supplier() { SupplierId = 1, CompanyName = "Exotic Liquids" } }.AsQueryable();
		}
	}
}