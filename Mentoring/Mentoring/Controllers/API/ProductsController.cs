using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mentoring.Models;
using Mentoring.Services.DataProvider;

namespace Mentoring.Controllers.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private IDataProvider<Product> _dataProvider;

		public ProductsController(IDataProvider<Product> dataProvider)
		{
			_dataProvider = dataProvider;
		}

		[HttpGet]
		public ActionResult<List<Product>> GetProducts()
		{
			try
			{
				List<Product> products = _dataProvider.GetData().ToList();
				return Ok(products);
			}
			catch (Exception e)
			{
			}

			return BadRequest();
		}

		[HttpGet("{id}")]
		[ProducesResponseType((int)HttpStatusCode.NotFound)]
		[ProducesResponseType((int)HttpStatusCode.OK)]
		public ActionResult<Product> GetProduct(int id)
		{
			try
			{
				Product product = _dataProvider.GetData().FirstOrDefault(p => p.ProductId == id);

				if (product == null)
				{
					return NotFound();
				}

				return Ok(product);
			}
			catch (Exception e)
			{
			}

			return BadRequest();
		}

		//Should i do them async?
		[HttpPut("{id}")]
		public ActionResult<Product> PutProduct(int id, [FromBody]Product product)
		{
			Product oldProduct = _dataProvider.GetData().FirstOrDefault(p => p.ProductId == id);
			if (oldProduct == null)
			{
				return NotFound();
			}

			try
			{
				oldProduct.Category = product.Category ?? oldProduct.Category;
				oldProduct.Supplier = product.Supplier ?? oldProduct.Supplier;
				oldProduct.CategoryId = product.CategoryId ?? oldProduct.CategoryId;
				oldProduct.Discontinued = product.Discontinued != oldProduct.Discontinued ? product.Discontinued : oldProduct.Discontinued;
				oldProduct.ProductName = product.ProductName ?? oldProduct.ProductName;
				oldProduct.QuantityPerUnit = product.QuantityPerUnit ?? oldProduct.QuantityPerUnit;
				oldProduct.ReorderLevel = product.ReorderLevel ?? oldProduct.ReorderLevel;
				oldProduct.SupplierId = product.SupplierId ?? oldProduct.SupplierId;
				oldProduct.UnitPrice = product.UnitPrice ?? oldProduct.UnitPrice;
				oldProduct.UnitsInStock = product.UnitsInStock ?? oldProduct.UnitsInStock;
				oldProduct.UnitsOnOrder = product.UnitsOnOrder ?? oldProduct.UnitsOnOrder;
				_dataProvider.Update();

				return Ok(oldProduct);
			}
			catch (Exception e)
			{
				//what is best way to handle exceptions? in pluralsight course they live it empty
			}

			return BadRequest();  //also i'm not getting how this will work? what are the cases when this will happen? it's not even in try/catche's "finally" section.
		}

		[HttpPost]
		[ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
		public ActionResult<Product> PostProduct([FromBody]Product product)
		{
			try
			{
				_dataProvider.Add(product);
				return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
			}
			catch (Exception e)
			{
			}

			return BadRequest();
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteProduct(int id)
		{
			try
			{
				Product product = _dataProvider.GetData().FirstOrDefault(p => p.ProductId == id);
				if (product == null)
				{
					return NotFound();
				}

				_dataProvider.Delete(product);
				_dataProvider.Update();

				return Ok();
			}
			catch (Exception e)
			{
			}

			return BadRequest();
		}
	}
}