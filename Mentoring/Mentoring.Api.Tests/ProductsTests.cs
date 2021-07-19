using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Mentoring.Api.Tests.Swagger.Client;
using Mentoring.Api.Tests.Swagger.Models;
using Mentoring.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NUnit.Framework;

namespace Mentoring.Api.Tests
{
	class ProductsTests
	{
		private const string TestDatabaseConnectionString = "Data Source=EPRURYAW0650\\SQLEXPRESS;Initial Catalog=NorthwindTest;Integrated Security=True";

		private Client _client;
		private HttpClient _httpClient;
		private NorthwindDbContext _dbContext;
		private Models.Product dbProduct;

		[SetUp]
		public void Setup()
		{
			PrepareTestDataBase();
			InitClient();
		}

		[TearDown]
		public void Cleanup()
		{
			RemoveTestDataFromDb();
			_httpClient.Dispose();
			_dbContext.Dispose();
		}

		[Test]
		public async Task Products_Get_All()
		{
			ICollection<Product> result = await _client.ProductsGetAsync();

			Assert.AreEqual(3, result.Count);
			Assert.IsNotNull(result.FirstOrDefault(p => p.ProductName == "TestProduct1"));
			Assert.IsNotNull(result.FirstOrDefault(p => p.ProductName == "TestProduct2"));
			Assert.IsNotNull(result.FirstOrDefault(p => p.ProductName == "TestProduct3"));
		}

		[Test]
		public async Task Products_Get_Single()
		{
			string expectedProductName = "TestProduct2";

			Product result = await _client.ProductsGetAsync(dbProduct.ProductId);

			Assert.AreEqual(expectedProductName, result.ProductName);
		}

		[Test]
		public async Task Products_Post()
		{
			Product testProduct = new Product()
			{
				ProductName = "TestProduct",
				QuantityPerUnit = "qpu",
				CategoryId = 1,
				Discontinued = true,
				ReorderLevel = 2,
				SupplierId = 3,
				UnitPrice = 4,
				UnitsInStock = 5,
				UnitsOnOrder = 6
			};

			Product result = await _client.ProductsPostAsync(testProduct);

			Assert.AreEqual(testProduct.ProductName, result.ProductName);
			Assert.AreEqual(testProduct.QuantityPerUnit, result.QuantityPerUnit);
			Assert.AreEqual(testProduct.CategoryId, result.CategoryId);
			Assert.AreEqual(testProduct.Discontinued, result.Discontinued);
			Assert.AreEqual(testProduct.ReorderLevel, result.ReorderLevel);
			Assert.AreEqual(testProduct.SupplierId, result.SupplierId);
			Assert.AreEqual(testProduct.UnitPrice, result.UnitPrice);
			Assert.AreEqual(testProduct.UnitsInStock, result.UnitsInStock);
			Assert.AreEqual(testProduct.UnitsOnOrder, result.UnitsOnOrder);
			Assert.AreNotEqual(0, result.ProductId);

			Models.Product postedProduct = _dbContext.Products.FirstOrDefault(p => p.ProductId == result.ProductId);
			Assert.AreEqual(testProduct.ProductName, postedProduct.ProductName);
			Assert.AreEqual(testProduct.QuantityPerUnit, postedProduct.QuantityPerUnit);
			Assert.AreEqual(testProduct.CategoryId, postedProduct.CategoryId);
			Assert.AreEqual(testProduct.Discontinued, postedProduct.Discontinued);
			Assert.AreEqual(testProduct.ReorderLevel, postedProduct.ReorderLevel);
			Assert.AreEqual(testProduct.SupplierId, postedProduct.SupplierId);
			Assert.AreEqual(testProduct.UnitPrice, postedProduct.UnitPrice);
			Assert.AreEqual(testProduct.UnitsInStock, postedProduct.UnitsInStock);
			Assert.AreEqual(testProduct.UnitsOnOrder, postedProduct.UnitsOnOrder);
			Assert.AreNotEqual(0, postedProduct.ProductId);
		}

		[Test]
		public async Task Products_Put()
		{
			Product testProduct = new Product()
			{
				ProductName = "TestProductUpdated",
				QuantityPerUnit = "upq",
				CategoryId = 8,
				Discontinued = false,
				ReorderLevel = 22,
				SupplierId = 2,
				UnitPrice = 44,
				UnitsInStock = 55,
				UnitsOnOrder = 66
			};

			Product result = await _client.ProductsPutAsync(dbProduct.ProductId, testProduct);

			Assert.AreEqual(testProduct.ProductName, result.ProductName);
			Assert.AreEqual(testProduct.QuantityPerUnit, result.QuantityPerUnit);
			Assert.AreEqual(testProduct.CategoryId, result.CategoryId);
			Assert.AreEqual(testProduct.Discontinued, result.Discontinued);
			Assert.AreEqual(testProduct.ReorderLevel, result.ReorderLevel);
			Assert.AreEqual(testProduct.SupplierId, result.SupplierId);
			Assert.AreEqual(testProduct.UnitPrice, result.UnitPrice);
			Assert.AreEqual(testProduct.UnitsInStock, result.UnitsInStock);
			Assert.AreEqual(testProduct.UnitsOnOrder, result.UnitsOnOrder);

			Models.Product putProduct = _dbContext.Products.FirstOrDefault(p => p.ProductId == result.ProductId);
			_dbContext.Entry(putProduct).Reload();
			Assert.AreEqual(testProduct.ProductName, putProduct.ProductName);
			Assert.AreEqual(testProduct.QuantityPerUnit, putProduct.QuantityPerUnit);
			Assert.AreEqual(testProduct.CategoryId, putProduct.CategoryId);
			Assert.AreEqual(testProduct.Discontinued, putProduct.Discontinued);
			Assert.AreEqual(testProduct.ReorderLevel, putProduct.ReorderLevel);
			Assert.AreEqual(testProduct.SupplierId, putProduct.SupplierId);
			Assert.AreEqual(testProduct.UnitPrice, putProduct.UnitPrice);
			Assert.AreEqual(testProduct.UnitsInStock, putProduct.UnitsInStock);
			Assert.AreEqual(testProduct.UnitsOnOrder, putProduct.UnitsOnOrder);
		}

		[Test]
		public async Task Products_Delete()
		{
			await _client.ProductsDeleteAsync(dbProduct.ProductId);

			Models.Product product = _dbContext.Products.FirstOrDefault(p => p.ProductId == dbProduct.ProductId);
			Assert.IsNull(product);
		}

		private void PrepareTestDataBase()
		{
			ConfigureDbContext();
			AddDataToDatabase();
		}

		private void ConfigureDbContext()
		{
			DbContextOptionsBuilder<NorthwindDbContext> optionsBuilder = new DbContextOptionsBuilder<NorthwindDbContext>();
			optionsBuilder.UseLazyLoadingProxies().UseSqlServer(TestDatabaseConnectionString);
			_dbContext = new NorthwindDbContext(optionsBuilder.Options);
		}
		private void AddDataToDatabase()
		{
			_dbContext.Add(GetTestProduct("TestProduct1"));
			EntityEntry<Models.Product> product = _dbContext.Add(GetTestProduct("TestProduct2"));
			_dbContext.Add(GetTestProduct("TestProduct3"));
			_dbContext.SaveChanges();
			dbProduct = product.Entity;
		}

		private void InitClient()
		{
			MentoringApiWebApplicationFactory appFactory = new MentoringApiWebApplicationFactory();
			_httpClient = appFactory.CreateClient();
			_client = new Client(_httpClient.BaseAddress.ToString(), _httpClient);
		}

		private void RemoveTestDataFromDb()
		{
			_dbContext.Products.RemoveRange(_dbContext.Products);
			_dbContext.SaveChanges();
		}

		private Models.Product GetTestProduct(string productName = "TestProduct")
		{
			return new Models.Product()
			{
				ProductName = productName,
				QuantityPerUnit = "qpu",
				CategoryId = 1,
				Discontinued = true,
				ReorderLevel = 2,
				SupplierId = 3,
				UnitPrice = 4,
				UnitsInStock = 5,
				UnitsOnOrder = 6
			};
		}
	}
}
