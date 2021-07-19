using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mentoring.Controllers;
using Mentoring.Models;
using Mentoring.Services.DataProvider;
using Mentoring.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Mentoring.Tests
{
	public class CategoriesTests
	{
		private Mock<IDataProvider<Category>> mockCategoryDataProvider;
		private Mock<IMapper> mockMapper;

		[SetUp]
		public void Setup()
		{
			mockCategoryDataProvider = new Mock<IDataProvider<Category>>();
			mockCategoryDataProvider.Setup(x => x.GetData()).Returns(TestData.GetCategoriesTestData());
			mockMapper = new Mock<IMapper>();
		}

		[Test]
		public void Index_ReturnsViewResult_WithListOfCategories()
		{
			

			var controller = new CategoriesController(mockCategoryDataProvider.Object, mockMapper.Object);
			var result = controller.Index();

			Assert.AreEqual(typeof(ViewResult),result.GetType());

			var viewResult = (ViewResult)result;
			Assert.IsAssignableFrom<List<CategoryViewModel>>(viewResult.Model);

			var model = (IEnumerable<CategoryViewModel>)viewResult.Model;
			Assert.AreEqual(TestData.GetCategoriesTestData().Count(), model.Count());
		}
	}
}