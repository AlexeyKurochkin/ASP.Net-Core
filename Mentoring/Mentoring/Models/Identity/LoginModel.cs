using System.ComponentModel.DataAnnotations;

namespace Mentoring.Models.Identity
{
	public class LoginModel
	{
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}