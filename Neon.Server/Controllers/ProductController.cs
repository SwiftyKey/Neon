using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neon.Application.IServices;
using Neon.Domain.Entities;
using Neon.Server.RequestEntities.Product;

namespace Neon.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService, IMapper mapper) : ControllerBase
{
	[HttpGet("{productId:int}", Name = nameof(GetProductById))]
	public ActionResult<ProductToGet> GetProductById([FromRoute] int productId)
	{
		var product = productService.GetById(productId);
		if (product is null)
			return NotFound();
		var productToGet = mapper.Map<ProductToGet>(product);
		return Ok(productToGet);
	}

	[HttpGet("{name}", Name = nameof(GetProductByName))]
	public ActionResult<IEnumerable<ProductToGet>> GetProductByName([FromRoute] string name)
	{
		var products = productService.GetByName(name);
		if (products is null)
			return NotFound();
		var productsToGet = products.Select(mapper.Map<ProductToGet>);
		return Ok(productsToGet);
	}

	[HttpGet(Name = nameof(GetAllProducts))]
	public ActionResult<IEnumerable<ProductToGet>> GetAllProducts()
	{
		var products = productService.GetAll();
		var productsToGet = products.Select(mapper.Map<ProductToGet>);
		return Ok(productsToGet);
	}

	[HttpPost(Name = nameof(CreateProduct))]
	public async Task<IActionResult> CreateProduct([FromBody] ProductToPost productToPost)
	{
		if (productToPost is null)
			return BadRequest("Product is empty");
		if (!ModelState.IsValid)
			return UnprocessableEntity();
		var product = mapper.Map<Product>(productToPost);
		var createdProduct = await productService.AddAsync(product);
		return CreatedAtRoute(nameof(GetProductById), new { productId = createdProduct.Id }, createdProduct.Id);
	}

	[HttpPatch("{productId:int}", Name = nameof(UpdateProduct))]
	public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductToPatch productToPatch)
	{
		var product = mapper.Map<Product>(productToPatch);
		product.Id = productId;
		await productService.UpdateAsync(product);
		return Ok();
	}

	[HttpDelete("{productId:int}", Name = nameof(DeleteProduct))]
	public async Task<IActionResult> DeleteProduct(int productId)
	{
		await productService.DeleteAsync(productService.GetById(productId));
		return Ok();
	}
}
