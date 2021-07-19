using System.ComponentModel.DataAnnotations;

namespace Mentoring.Models.Identity
{
	public class ResetPasswordModel
	{
		public string Token { get; set; }
		public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Compare(nameof(Password))]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}