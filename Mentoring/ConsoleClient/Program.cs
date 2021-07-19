using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Mentoring.Models;
using Newtonsoft.Json;

namespace ConsoleClient
{
	class Program
	{
		private static HttpClient client = new HttpClient();

		static void Main(string[] args)
		{
			client.BaseAddress = new Uri("https://localhost:44339/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			List<Product> products = Get<Product>("api/products").GetAwaiter().GetResult();
			PrintProducts(products);
			List<Category> categories = Get<Category>("api/categories").GetAwaiter().GetResult();
			PrintCategories(categories);
		}

		private static void PrintCategories(List<Category> categories)
		{
			foreach (Category category in categories)
			{
				ShowCategory(category);
			}
		}

		private static void PrintProducts(List<Product> products)
		{
			foreach (Product product in products)
			{
				ShowProduct(product);
			}
		}

		private static async Task<List<T>> Get<T>(string path)
		{
			List<T> products = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				products = await ParseFromJson<List<T>>(response);
			}

			return products;
		}

		private static void ShowProduct(Product product)
		{
			Console.WriteLine($"ProductName: {product.ProductName}");
			Console.WriteLine($"Category: {product.Category.CategoryName}");
			Console.WriteLine($"Discontinued: {product.Discontinued}");
			Console.WriteLine($"ProductId: {product.ProductId}");
			Console.WriteLine($"QuantityPerUnit: {product.QuantityPerUnit}");
			Console.WriteLine($"ReorderLevel: {product.ReorderLevel}");
			Console.WriteLine($"SupplierCompanyName: {product.Supplier.CompanyName}");
			Console.WriteLine($"UnitPrice: {product.UnitPrice}");
			Console.WriteLine($"UnitsInStock: {product.UnitsInStock}");
			Console.WriteLine($"UnitsOnOrder: {product.UnitsOnOrder}");
			Console.WriteLine();
		}

		private static void ShowCategory(Category category)
		{
			Console.WriteLine($"CategoryId: {category.CategoryId}");
			Console.WriteLine($"CategoryName: {category.CategoryName}");
			Console.WriteLine($"Description: {category.Description}");
			Console.WriteLine();
		}

		public static async Task<T> ParseFromJson<T>(HttpResponseMessage response)
		{
			string content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(content);
		}
	}
}
