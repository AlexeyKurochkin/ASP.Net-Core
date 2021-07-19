using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mentoring.Controllers
{
	[Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
	    private UserManager<IdentityUser> _userManager;

	    public AdministrationController(UserManager<IdentityUser> userManager)
	    {
		    _userManager = userManager;
	    }

	    public IActionResult Index()
	    {

			return View(_userManager.Users);
        }
    }
}