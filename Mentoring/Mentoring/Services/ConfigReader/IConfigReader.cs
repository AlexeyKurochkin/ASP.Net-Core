namespace Mentoring.Services.ConfigReader
{
	public interface IConfigReader
	{
		int GetMaxProductCount();
		string GetCacheStorageFolder();
		int GetMaxCachedImages();
		int GetCacheExpirationInterval();
		bool LogActionArguments();
	}
}
