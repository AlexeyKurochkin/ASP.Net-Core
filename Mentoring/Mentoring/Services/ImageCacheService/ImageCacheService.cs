using System;
using System.IO;
using System.Timers;
using Mentoring.Services.ConfigReader;

namespace Mentoring.Services.ImageCacheService
{
	public class ImageCacheService : IImageCacheService
	{
		private readonly IConfigReader _configReader;
		private string _storageFolderName;
		private string _storageFolderPath;
		private int _maxCachedImages;

		private Timer _cacheExpirationTimer;

		public ImageCacheService(IConfigReader configReader)
		{
			_configReader = configReader;
			_storageFolderPath = configReader.GetCacheStorageFolder();
			_maxCachedImages = _configReader.GetMaxCachedImages();
			InitExpirationTimer();
		}

		public void SaveFileToCache(string id, MemoryStream stream)
		{
			_cacheExpirationTimer.Stop();
			int cachedImagesAmount = Directory.GetFiles(_storageFolderPath).Length;
			string fullPath = Path.Combine(_storageFolderPath, id);
			if (cachedImagesAmount < _maxCachedImages)
			{
				using (FileStream fileStream = File.Create(fullPath))
				{
					stream.CopyTo(fileStream);
				}
			}

			_cacheExpirationTimer.Start();
		}

		public bool TryLoadFromCache(string id, Stream stream)
		{
			_cacheExpirationTimer.Stop();
			bool result = TryLoad(id, stream);
			_cacheExpirationTimer.Start();
			return result;
		}

		private bool TryLoad(string id, Stream stream)
		{
			Directory.CreateDirectory(_storageFolderPath);
			string fullPath = Path.Combine(_storageFolderPath, id);

			if (File.Exists(fullPath))
			{
				using (FileStream fileStream = File.Open(fullPath, FileMode.Open))
				{
					fileStream.CopyTo(stream);
				}

				return true;
			}

			return false;
		}

		private void InitExpirationTimer()
		{
			_cacheExpirationTimer = new Timer();
			_cacheExpirationTimer.AutoReset = false;
			_cacheExpirationTimer.Interval = _configReader.GetCacheExpirationInterval();
			_cacheExpirationTimer.Elapsed += (sender, args) => RemoveExpiredCacheFiles();
		}

		private void RemoveExpiredCacheFiles()
		{
			foreach (string file in Directory.GetFiles(_storageFolderPath))
			{
				File.Delete(Path.Combine(_storageFolderPath, file));
			}

			_cacheExpirationTimer.Stop();
		}
	}
}