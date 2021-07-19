using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Mentoring.ActionFilters;
using Mentoring.AutoMapperProfiles;
using Mentoring.Data;
using Mentoring.Middleware.ExceptionHandler;
using Mentoring.Middleware.ImageCacheManager;
using Mentoring.Services.ConfigReader;
using Mentoring.Services.DataProvider;
using Mentoring.Services.EmailSender;
using Mentoring.Services.ExceptionHandlerService;
using Mentoring.Services.ImageCacheService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Mentoring
{
	public class Startup
	{
		public IConfiguration _configuration { get; }
		public ILogger _logger { get; private set; }

		public Startup(IConfiguration configuration, ILogger<Startup> logger)
		{
			_configuration = configuration;
			_logger = logger;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			string connectionString = _configuration.GetConnectionString("Northwind");
			_logger.LogInformation($"Read config values.Connection string: {connectionString}");
			services.AddSingleton<IConfigReader, ConfigReader>();
			services.AddDbContext<NorthwindDbContext>(options =>
				options.UseLazyLoadingProxies().UseSqlServer(connectionString));
			services.AddScoped(typeof(IDataProvider<>), typeof(SqlDataProvider<>));
			services.AddAutoMapper(typeof(NorthwindProfile));
			services.AddSingleton<IImageCacheService, ImageCacheService>();
			services.AddSingleton<IExceptionHandlerService, LoggingExceptionHandlerService>();
			services.AddSwaggerGen(c =>
				c.SwaggerDoc("v1", new OpenApiInfo()
				{
					Title = "Northwind API",
					Version = "v1",
					Description = "Designed for asp.net core mentoring program",
					Contact = new OpenApiContact()
					{
						Name = "Alexey Kurochkin",
						Email = String.Empty
					}
				}));

			string migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
			string identityConnectionString = _configuration.GetConnectionString("Identity");
			services.AddDbContext<IdentityDbContext>(options =>
				options.UseSqlServer(identityConnectionString, sql => sql.MigrationsAssembly(migrationAssembly)));
			services.AddIdentity<IdentityUser, IdentityRole>(options => { })
				.AddEntityFrameworkStores<IdentityDbContext>()
				.AddDefaultTokenProviders();
			services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(3));

			services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
				.AddAzureAD(options => _configuration.Bind("AzureAd", options));
			services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
			{
				options.Authority = options.Authority + "/v2.0/";
				options.TokenValidationParameters.ValidateIssuer = false;
			});

			services.AddMvc(options => { options.Filters.Add<LoggingActionFilter>(); })
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

			services.AddTransient<IEmailSender, SendGridEmailSender>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
			IApplicationLifetime applicationLifetime)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			applicationLifetime.ApplicationStarted.Register(() =>
				_logger.LogInformation($"App started. Location: {Directory.GetCurrentDirectory()}"));

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseMiddleware<ImageCacheManager>();
			app.UseMiddleware<ExceptionHandler>();

			app.UseCors(opt => opt.AllowAnyHeader().WithMethods("GET").AllowAnyOrigin());

			app.UseSwagger();
			app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind API v1"));

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute("images", "images/{id}",
					defaults: new {controller = "Categories", action = "Image"});
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}