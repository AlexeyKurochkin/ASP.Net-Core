using System.IO;

namespace Mentoring.Services.ImageCacheService
{
	public interface IImageCacheService
	{
		bool TryLoadFromCache(string id, Stream stream);
		void SaveFileToCache(string id, MemoryStream stream);
	}
}