using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mentoring.Controllers;
using Mentoring.Models;
using Mentoring.Services.ConfigReader;
using Mentoring.Services.DataProvider;
using Mentoring.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Mentoring.Tests
{
	public class ProductsTests
	{
		private Mock<IDataProvider<Product>> mockProductDataProvider;
		private Mock<IDataProvider<Supplier>> mockSupplierDataProvider;
		private Mock<IDataProvider<Category>> mockCategoryDataProvider;
		private Mock<IConfigReader> mockConfigReader;
		private Mock<IMapper> mockMapper;

		[SetUp]
		public void Setup()
		{
			mockProductDataProvider = new Mock<IDataProvider<Product>>();
			mockProductDataProvider.Setup(x => x.GetData()).Returns(TestData.GetProductsTestData());

			mockSupplierDataProvider = new Mock<IDataProvider<Supplier>>();
			mockSupplierDataProvider.Setup(x => x.GetData()).Returns(TestData.GetSupplierTestData());

			mockCategoryDataProvider = new Mock<IDataProvider<Category>>();
			mockCategoryDataProvider.Setup(x => x.GetData()).Returns(TestData.GetCategoriesTestData());

			mockConfigReader = new Mock<IConfigReader>();
			mockConfigReader.Setup(x => x.GetMaxProductCount()).Returns(0);

			mockMapper = new Mock<IMapper>();
		}

		[TestCase(0)]
		[TestCase(1)]
		public void Index_ReturnsViewResult_WithListOfProducts(int maxProductCount)
		{
			mockConfigReader.Setup(x => x.GetMaxProductCount()).Returns(maxProductCount);

			var controller = new ProductsController(mockProductDataProvider.Object, mockConfigReader.Object,
				mockSupplierDataProvider.Object, mockCategoryDataProvider.Object, mockMapper.Object);
			var result = controller.Index();

			Assert.AreEqual(typeof(ViewResult), result.GetType());

			var viewResult = (ViewResult) result;
			Assert.IsAssignableFrom<List<ProductsViewModel>>(viewResult.Model);

			var model = (IEnumerable<ProductsViewModel>) viewResult.Model;
			Assert.AreEqual(model.Count(), maxProductCount == 0 ? TestData.GetProductsTestData().Count() : maxProductCount);
		}

		[Test]
		public void CreateProduct_ReturnsViewResult()
		{
			var controller = new ProductsController(mockProductDataProvider.Object, mockConfigReader.Object,
				mockSupplierDataProvider.Object, mockCategoryDataProvider.Object, mockMapper.Object);
			var result = controller.CreateProduct();

			Assert.AreEqual(typeof(ViewResult), result.GetType());

			var viewResult = (ViewResult)result;
			Assert.IsAssignableFrom<CreateEditProductViewModel>(viewResult.Model);
		}

		[Test]
		public void CreateProductPost_ReturnsARedirectAndAddsProduct_WhenModelStateIsValid()
		{
			var controller = new ProductsController(mockProductDataProvider.Object, mockConfigReader.Object,
				mockSupplierDataProvider.Object, mockCategoryDataProvider.Object, mockMapper.Object);
			mockProductDataProvider.Setup(x => x.Add(It.IsAny<Product>())).Returns(It.IsAny<Product>()).Verifiable();
			var result = controller.CreateProduct(new CreateEditProductViewModel());

			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());

			var redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual(redirectToActionResult.ActionName, "Index");
			mockProductDataProvider.Verify();
		}

		[Test]
		public void EditProduct_ReturnsARedirect_WhenProductNotFound()
		{
			var controller = new ProductsController(mockProductDataProvider.Object, mockConfigReader.Object,
				mockSupplierDataProvider.Object, mockCategoryDataProvider.Object, mockMapper.Object);
			var result = controller.EditProduct(-1);

			Assert.AreEqual(typeof(RedirectToActionResult), result.GetType());

			var redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual(redirectToActionResult.ActionName, "Index");
		}

		[Test]
		public void EditProductPost_ReturnsView_WhenModelStateIsInvalid()
		{
			var controller = new ProductsController(mockProductDataProvider.Object, mockConfigReader.Object,
				mockSupplierDataProvider.Object, mockCategoryDataProvider.Object, mockMapper.Object);
			var product = TestData.GetProductsTestData().First();
			var createEditProductViewModel = new CreateEditProductViewModel();
			controller.ModelState.AddModelError("ProductName", "ProductName is required");
			var result = controller.EditProduct(createEditProductViewModel);

			Assert.AreEqual(typeof(ViewResult), result.GetType());

			var viewResult = (ViewResult)result;
			Assert.IsAssignableFrom<CreateEditProductViewModel>(viewResult.Model);
		}
	}
}