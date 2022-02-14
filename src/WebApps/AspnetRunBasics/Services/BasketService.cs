using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CheckoutBasket(BasketCheckoutModel model)
        {
            var response = await _httpClient.PostAsJson($"/Basket/Checkout", model);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Somethong went wrong when calling the API.");
            }
        }

        public async Task<BasketModel> GetBasket(string userName)
        {
            var response = await _httpClient.GetAsync($"/Basket/{userName}");
            return await response.ReadContentAs<BasketModel>();
        }

        public async Task<BasketModel> UpdateBasket(BasketModel model)
        {
            var response = await _httpClient.PostAsJson($"/Basket", model);

            if (response.IsSuccessStatusCode)
            {
                //return await response.ReadContentAs<BasketModel>();
                return new();
            }

            throw new Exception("Somethong went wrong when calling the API.");
        }
    }
}
