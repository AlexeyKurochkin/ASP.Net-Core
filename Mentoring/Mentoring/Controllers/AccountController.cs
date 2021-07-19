using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Mentoring.Models.Identity;
using Mentoring.Services.EmailSender;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mentoring.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<IdentityUser> _userManager;
		private RoleManager<IdentityRole> _roleManager;
		private IUserClaimsPrincipalFactory<IdentityUser> _claimsPrincipalFactory;
		private IEmailSender _emailSender;

		public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager,
			IUserClaimsPrincipalFactory<IdentityUser> claimsPrincipalFactory,
			IEmailSender emailSender)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_claimsPrincipalFactory = claimsPrincipalFactory;
			_emailSender = emailSender;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				IdentityUser user = await _userManager.FindByEmailAsync(model.Email);

				if (user == null)
				{
					user = new IdentityUser(model.Email) {Email = model.Email};
					IdentityResult result = await _userManager.CreateAsync(user, model.Password);
					if (result.Succeeded)
					{
						return View("Success");
					}
					else
					{
						AddErrorsToModelState(result.Errors);
					}
				}
				else
				{
					ModelState.AddModelError("", "User already exist.");
				}

			}

			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				IdentityUser user = await _userManager.FindByEmailAsync(model.Email);
				if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
				{
					ClaimsPrincipal principal = await _claimsPrincipalFactory.CreateAsync(user);
					await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);

					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError("","Invalid UserName or Password");
			}

			return View();
		}

		[HttpGet]
		public IActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
		{
			if (ModelState.IsValid)
			{
				IdentityUser user = await _userManager.FindByEmailAsync(model.Email);

				List<string> emails = new List<string>() {model.Email};
				if (user != null)
				{
					string token = await _userManager.GeneratePasswordResetTokenAsync(user);
					string resetUrl = Url.Action("ResetPassword", "Account", new {token = token, email = user.Email}, Request.Scheme);

					await _emailSender.SendEmailAsync(emails, "Password recovery", $"Please follow the link to reset password <a href=\"{resetUrl}\">Click</a>");
				}
				else
				{
					await _emailSender.SendEmailAsync(emails, "Login attempt", $"You do not have registered account.");
				}

				return View("Success");
			}

			return View();
		}

		[HttpGet]
		public IActionResult ResetPassword(string token, string email)
		{
			return View(new ResetPasswordModel {Token = token, Email = email});
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
		{
			if (ModelState.IsValid)
			{
				IdentityUser user = await _userManager.FindByEmailAsync(model.Email);

				if (user != null)
				{
					IdentityResult result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

					if (!result.Succeeded)
					{
						AddErrorsToModelState(result.Errors);
						return View();
					}

					return View("Success");
				}

				ModelState.AddModelError("", "Invalid Request");
			}

			return View();
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult ExternalLogin(string provider)
		{
			AuthenticationProperties properties = new AuthenticationProperties()
			{
				RedirectUri = Url.Action("ExternalLoginCallback"),
				Items = {{"scheme", provider}}
			};

			return Challenge(properties, provider);
		}

		[HttpGet]
		public async Task<IActionResult> ExternalLoginCallback()
		{
			AuthenticateResult result = await HttpContext.AuthenticateAsync(AzureADDefaults.AuthenticationScheme);

			string externalUserId = result.Principal.FindFirstValue("sub")
			                     ?? result.Principal.FindFirstValue(ClaimTypes.NameIdentifier)
			                     ?? throw new Exception("Cannot find external user id");
			string provider = result.Properties.Items["scheme"];

			IdentityUser user = await _userManager.FindByLoginAsync(provider, externalUserId);

			if (user == null)
			{
				string email = result.Principal.FindFirstValue("email")
				            ?? result.Principal.FindFirstValue(ClaimTypes.Email)
				            ?? result.Principal.FindFirstValue("preferred_username");
				if (email != null)
				{
					user = await _userManager.FindByEmailAsync(email);

					if (user == null)
					{
						user = new IdentityUser() { UserName = email, Email = email };
						await _userManager.CreateAsync(user);
					}

					await _userManager.AddLoginAsync(user, new UserLoginInfo(provider, externalUserId, provider));
				}
			}

			if (user == null)
				return View("Error");

			await HttpContext.SignOutAsync(AzureADDefaults.AuthenticationScheme);

			ClaimsPrincipal claimsPrincipal = await _claimsPrincipalFactory.CreateAsync(user);
			await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, claimsPrincipal);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public IActionResult AppendRole()
		{
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AppendRole(AppendRoleModel model)
		{
			if (ModelState.IsValid)
			{
				IdentityUser user = await _userManager.FindByEmailAsync(model.Email);
				if (user == null)
				{
					ModelState.AddModelError("", "User do not exist.");
				}
				else
				{
					if (await _userManager.IsInRoleAsync(user, model.RoleName))
					{
						ModelState.AddModelError("", "User already has this role.");
					}
					else
					{
						IdentityRole role = await _roleManager.FindByNameAsync(model.RoleName);
						if (role == null)
						{
							role = new IdentityRole(model.RoleName);
							IdentityResult roleResult = await _roleManager.CreateAsync(role);
							if (!roleResult.Succeeded)
							{
								AddErrorsToModelState(roleResult.Errors);
								return View();
							}
						}

						IdentityResult addRoleResult = await _userManager.AddToRoleAsync(user, role.Name);
						if (addRoleResult.Succeeded)
						{
							return View("Success");
						}
						else
						{
							AddErrorsToModelState(addRoleResult.Errors);
						}
					}
				}
			}

			return View();
		}

		private void AddErrorsToModelState(IEnumerable<IdentityError> errors, string errorKey = "")
		{
			foreach (IdentityError identityError in errors)
			{
				ModelState.AddModelError(errorKey, identityError.Description);
			}
		}
	}
}