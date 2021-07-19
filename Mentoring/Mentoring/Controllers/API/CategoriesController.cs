using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mentoring.Models;
using Mentoring.Services.DataProvider;

namespace Mentoring.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IDataProvider<Category> _dataProvider;

        public CategoriesController(IDataProvider<Category> dataProvider)
        {
	        _dataProvider = dataProvider;
        }

        [HttpGet]
        public ActionResult GetCategories()
        {
	        List<Category> categories = _dataProvider.GetData().ToList();
			return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult GetCategory(int id)
        {
	        Category category = _dataProvider.GetData().FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category.Picture?.ToArray() ?? new byte[0]);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody]Category category)
        {
            try
            {
	            Category oldCategory = _dataProvider.GetData().FirstOrDefault(c => c.CategoryId == id);
	            if (oldCategory == null)
	            {
		            return NotFound();
	            }

	            oldCategory.Picture = category.Picture ?? oldCategory.Picture;
				_dataProvider.Update();

				return Ok(oldCategory.Picture?.ToArray() ?? new byte[0]);
            }
            catch (Exception e)
            {
            }

            return BadRequest();
        }
    }
}
