using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Mentoring.Models;
using Mentoring.Services.DataProvider;
using Mentoring.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mentoring.Controllers
{
    public class CategoriesController : Controller
    {
		private IDataProvider<Category> _dataProvider;
	    private IMapper _mapper;

	    public CategoriesController(IDataProvider<Category> dataProvider, IMapper mapper)
	    {
		    _dataProvider = dataProvider;
		    _mapper = mapper;
	    }

	    public IActionResult Index()
	    {
		    IQueryable<Category> categories = _dataProvider.GetData();
			List<CategoryViewModel> model = new List<CategoryViewModel>();
			foreach (Category category in categories)
			{
				model.Add(_mapper.Map<CategoryViewModel>(category));
			}

			return View(model);
		}

	    public IActionResult Image(int id)
	    {
		    Category category = _dataProvider.GetData().FirstOrDefault(c => c.CategoryId == id);
		    return File(category?.Picture?.ToArray() ?? new byte[0], "image/png");
	    }

	    public IActionResult EditImage(int id)
	    {
		    Category category = _dataProvider.GetData().FirstOrDefault(c => c.CategoryId == id);
		    CategoryViewModel model = _mapper.Map<CategoryViewModel>(category);
		    return View(model);
	    }

		[HttpPost]
	    public IActionResult EditImage(CategoryViewModel model, IFormFile picture)
	    {
		    if (!ModelState.IsValid)
			    return View(nameof(EditImage), model);

		    Category category = _dataProvider.GetData().FirstOrDefault(c => c.CategoryId == model.CategoryId);
		    if (category == null || picture == null)
			    return RedirectToAction(nameof(Index));

		    using (MemoryStream memoryStream = new MemoryStream())
		    {
			    picture.CopyTo(memoryStream);
			    category.Picture = memoryStream.ToArray();
		    }

		    _dataProvider.Update();

		    return RedirectToAction(nameof(Index));
	    }
	}
}