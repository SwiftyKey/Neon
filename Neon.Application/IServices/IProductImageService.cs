using Microsoft.AspNetCore.Http;

namespace Neon.Application.IServices;

public interface IProductImageService
{
	public string UploadImages(IEnumerable<IFormFile> images, uint productId);
}
