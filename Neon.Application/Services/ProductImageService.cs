using Microsoft.AspNetCore.Http;
using Neon.Application.IServices;

namespace Neon.Application.Services;

public  class ProductImageService(string imagesPath) : IProductImageService
{
	private readonly string _imagesPath = imagesPath;

	public string UploadImages(IEnumerable<IFormFile> images, uint productId)
	{
		var pathToDirectory = Path.Combine(_imagesPath, productId.ToString());

		if (!Directory.Exists(pathToDirectory))
		{
			Directory.CreateDirectory(pathToDirectory);
		}

		var fileIndex = 0;
		foreach (var file in images)
		{
			if (file.Length <= 0) continue;

			var filePath = Path.Combine(pathToDirectory, $"{fileIndex}.png");
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				file.CopyTo(stream);
			}

			fileIndex++;
		}

		return pathToDirectory.Replace('\\', '/');
	}
}
