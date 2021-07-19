using System.ComponentModel.DataAnnotations;

namespace Mentoring.Models.Identity
{
	public class ForgotPasswordModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
