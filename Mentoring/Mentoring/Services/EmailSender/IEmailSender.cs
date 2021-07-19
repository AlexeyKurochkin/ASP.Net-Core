using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mentoring.Services.EmailSender
{
	public interface IEmailSender
	{
		Task SendEmailAsync(List<string> emails, string subject, string message);
	}
}
