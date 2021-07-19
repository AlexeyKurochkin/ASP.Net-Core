using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.IO;

namespace Mentoring.Services.ConfigReader
{
	public class ConfigReader : IConfigReader
	{
		const string MaxProductsCount = "MaxProductsCount";
		const string CacheFolder = "CacheFolder";
		const string MaxCachedImages = "MaxCachedImages";
		const string CacheExpirationInterval = "CacheExpirationInterval";
		const string EnableActionArgumentsLog = "EnableActionArgumentsLog";
		const string _wwwroot = "wwwroot";

		private IConfiguration _configuration;
		private ILogger<ConfigReader> _logger;

		public ConfigReader(IConfiguration configuration, ILogger<ConfigReader> logger)
		{
			_configuration = configuration;
			_logger = logger;
		}

		public int GetMaxProductCount()
		{
			string maxProductCount = _configuration[MaxProductsCount];
			if (int.TryParse(maxProductCount, out int parsedMaxProductCount))
			{
				_logger.LogDebug($"Read MaxProductsCount: {parsedMaxProductCount}");
				return parsedMaxProductCount;
			}
			else
			{
				throw new ConfigurationErrorsException($"Incorrect config value: {MaxProductsCount}");
			}
		}

		public string GetCacheStorageFolder()
		{
			string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), _wwwroot);
			return Path.Combine(wwwRootPath, _configuration[CacheFolder]);
		}

		public int GetMaxCachedImages()
		{
			string maxCachedImages = _configuration[MaxCachedImages];
			if (int.TryParse(maxCachedImages, out int parsedMaxCachedImages))
			{
				return parsedMaxCachedImages;
			}
			else
			{
				throw new ConfigurationErrorsException($"Incorrect config value: {MaxCachedImages}");
			}
		}

		public int GetCacheExpirationInterval()
		{
			string cacheExpirationInterval = _configuration[CacheExpirationInterval];
			if (int.TryParse(cacheExpirationInterval, out int parsedCacheExpirationInterval))
			{
				return parsedCacheExpirationInterval;
			}
			else
			{
				throw new ConfigurationErrorsException($"Incorrect config value: {CacheExpirationInterval}");
			}
		}

		public bool LogActionArguments()
		{
			string enableActionArgumentsLog = _configuration[EnableActionArgumentsLog];
			if (bool.TryParse(enableActionArgumentsLog, out bool parsedEnableActionArgumentsLog))
			{
				return parsedEnableActionArgumentsLog;
			}
			else
			{
				throw new ConfigurationErrorsException($"Incorrect config value: {EnableActionArgumentsLog}");
			}
		}
	}
}