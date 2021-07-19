using System.IO;
using System.Threading.Tasks;
using Mentoring.Services.ImageCacheService;
using Microsoft.AspNetCore.Http;

namespace Mentoring.Middleware.ImageCacheManager
{
	public class ImageCacheManager
	{
		private readonly RequestDelegate _next;

		public ImageCacheManager(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context, IImageCacheService imageCacheService)
		{
			if (context.Request.Path.HasValue &&
			    context.Request.Path.Value.Contains("images"))
			{
				string id = GetImageId(context.Request.Path);
				await ProcessRequest(context, imageCacheService, id);
			}
			else
			{
				await _next(context);
			}
		}

		private async Task ProcessRequest(HttpContext context, IImageCacheService imageCacheService, string id)
		{
			if (!imageCacheService.TryLoadFromCache(id, context.Response.Body))
			{
				await ProcessAndSaveIntoCache(context, imageCacheService, id);
			}
		}

		private async Task ProcessAndSaveIntoCache(HttpContext context, IImageCacheService imageCacheService, string id)
		{
			Stream originalBody = context.Response.Body;

			using (MemoryStream memStream = new MemoryStream())
			{
				context.Response.Body = memStream;

				await _next(context);

				context.Response.Body = originalBody;

				memStream.Position = 0;
				memStream.CopyTo(originalBody);

				memStream.Position = 0;
				imageCacheService.SaveFileToCache(id, memStream);
			}
		}

		private string GetImageId(PathString requestPath)
		{
			return requestPath.Value.Replace("/images/", string.Empty);
		}
	}
}