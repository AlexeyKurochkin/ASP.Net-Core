using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mentoring.Models;
using Mentoring.Services.ConfigReader;
using Mentoring.Services.DataProvider;
using Mentoring.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Mentoring.Controllers
{
	public class ProductsController : Controller
	{
		private IDataProvider<Product> _productDataProvider;
		private IDataProvider<Supplier> _supplierDataProvider;
		private IDataProvider<Category> _categoryDataProvider;
		private IConfigReader _configReader;
		private IMapper _mapper;

		public ProductsController(IDataProvider<Product> productDataProvider, IConfigReader configReader,
			IDataProvider<Supplier> supplierDataProvider, IDataProvider<Category> categoryDataProvider, IMapper mapper)
		{
			_productDataProvider = productDataProvider;
			_configReader = configReader;
			_supplierDataProvider = supplierDataProvider;
			_categoryDataProvider = categoryDataProvider;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			IQueryable<Product> products = _productDataProvider.GetData();
			int maxProductsCount = _configReader.GetMaxProductCount();
			if (maxProductsCount > 0)
				products = products.Take(maxProductsCount);

			List<ProductsViewModel> model = new List<ProductsViewModel>();
			foreach (Product product in products)
			{
				model.Add(_mapper.Map<ProductsViewModel>(product));
			}

			return View(model);
		}

		[HttpGet]
		public IActionResult CreateProduct()
		{
			CreateEditProductViewModel model = new CreateEditProductViewModel();
			CreateProductSelectLists(model);
			return View(model);
		}

		[HttpPost]
		public IActionResult CreateProduct(CreateEditProductViewModel model)
		{
			if (ModelState.IsValid)
			{
				Product newProduct = _mapper.Map<Product>(model);
				_productDataProvider.Add(newProduct);

				return RedirectToAction(nameof(Index));
			}
			else
			{
				CreateProductSelectLists(model);
				return View(model);
			}
		}

		[HttpGet]
		public IActionResult EditProduct(int id)
		{
			Product product = _productDataProvider.GetData().FirstOrDefault(p => p.ProductId == id);
			if (product != null)
			{
				CreateEditProductViewModel model = _mapper.Map<CreateEditProductViewModel>(product);
				CreateProductSelectLists(model);
				return View(nameof(CreateProduct), model);
			}
			else
			{
				return RedirectToAction(nameof(Index));
			}
		}

		[HttpPost]
		public IActionResult EditProduct(CreateEditProductViewModel model)
		{
			if (!ModelState.IsValid)
			{
				CreateProductSelectLists(model);
				return View(nameof(CreateProduct), model);
			}

			Product product = _productDataProvider.GetData().FirstOrDefault(p => p.ProductId == model.ProductId);
			if (product == null)
				return RedirectToAction(nameof(Index));

			product.CategoryId = model.CategoryId;
			product.Discontinued = model.Discontinued;
			product.ProductName = model.ProductName;
			product.QuantityPerUnit = model.QuantityPerUnit;
			product.ReorderLevel= model.ReorderLevel;
			product.SupplierId = model.SupplierId;
			product.UnitPrice = model.UnitPrice;
			product.UnitsInStock = model.UnitsInStock;
			product.UnitsOnOrder = model.UnitsOnOrder;
			_productDataProvider.Update();

			return RedirectToAction(nameof(Index));
		}

		private void CreateProductSelectLists(CreateEditProductViewModel model)
		{
			model.Category = new SelectList(_categoryDataProvider.GetData(), "CategoryId", "CategoryName");
			model.Supplier = new SelectList(_supplierDataProvider.GetData(), "SupplierId", "CompanyName");
		}
	}
}