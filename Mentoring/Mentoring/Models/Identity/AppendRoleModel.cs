using System.ComponentModel.DataAnnotations;

namespace Mentoring.Models.Identity
{
	public class AppendRoleModel
	{
		public string RoleName { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}