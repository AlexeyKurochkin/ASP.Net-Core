using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace Mentoring.Api.Tests
{
	public class MentoringApiWebApplicationFactory : WebApplicationFactory<Startup>
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			base.ConfigureWebHost(builder);
			builder.ConfigureAppConfiguration((builderContext, config) =>
			{
				IHostingEnvironment env = builderContext.HostingEnvironment;
				env.EnvironmentName = "Test";
				config.AddJsonFile($"appsettings.{env.EnvironmentName}.json");
			});
		}
	}
}
