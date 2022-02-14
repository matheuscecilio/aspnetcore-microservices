using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics
{
    public class CartModel : PageModel
    {
        private readonly IBasketService _basketService;

        public CartModel(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public BasketModel Cart { get; set; } = new BasketModel();        

        public async Task<IActionResult> OnGetAsync()
        {
            var userName = "matheus.cecilio";
            Cart = await _basketService.GetBasket(userName);

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(Guid productId)
        {
            var userName = "matheus.cecilio";
            var basket = await _basketService.GetBasket(userName);

            var item = basket.Items.FirstOrDefault(x => x.ProductId == productId);
            basket.Items.Remove(item);

            var basketUpdate = await _basketService.UpdateBasket(basket);

            return RedirectToPage();
        }
    }
}