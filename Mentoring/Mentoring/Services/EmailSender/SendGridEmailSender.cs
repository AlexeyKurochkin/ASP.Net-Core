using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Mentoring.Services.EmailSender
{
	public class SendGridEmailSender : IEmailSender
	{
		public EmailAuthOptions Options { get; }

		public SendGridEmailSender(IOptions<EmailAuthOptions> optionsAccessor)
		{
			Options = optionsAccessor.Value;
		}

		public Task SendEmailAsync(List<string> emails, string subject, string message)
		{
			return Execute(Environment.GetEnvironmentVariable("MENTORING_ENVIRONMENT_SENDGRID_KEY"), subject, message, emails);
		}

		private Task Execute(string apiKey, string subject, string message, List<string> emails)
		{
			var client = new SendGridClient(apiKey);
			var msg = new SendGridMessage()
			{
				From = new EmailAddress("noreply@domain.com", "AspCoreMentoring"),
				Subject = subject,
				PlainTextContent = message,
				HtmlContent = message
			};

			foreach (var email in emails)
			{
				msg.AddTo(new EmailAddress(email));
			}

			Task response = client.SendEmailAsync(msg);
			return response;
		}


		public class EmailAuthOptions
		{
			public string SendGridUser { get; set; }
			public string SendGridKey { get; set; }
		}
	}
}
