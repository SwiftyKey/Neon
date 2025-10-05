using Neon.Application.IServices;

namespace Neon.Application.Services;

public class DummyPaymentService
(
	IOrderService orderService,
	IProductService productService
) : IPaymentService
{
	public async Task PayAsync(int userId)
	{
		var cart = orderService.GetOrderByUserId(userId).First(x => !x.Bought);
		cart.Bought = true;

		await orderService.UpdateAsync(cart);
		await orderService.CreateCartByUserId(userId);

		foreach (var item in cart.Compositions)
		{
			var product = productService.GetById(item.ProductId);
			product.Count -= item.Count;
			await productService.UpdateAsync(product);
		}
	}
}
