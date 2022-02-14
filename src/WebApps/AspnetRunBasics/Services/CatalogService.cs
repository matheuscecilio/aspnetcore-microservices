using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _httpClient;

        public CatalogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatalogModel> CreateCatalog(CatalogModel model)
        {
            var response = await _httpClient.PostAsJson("/Catalog", model);

            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAs<CatalogModel>();
            }

            throw new Exception("Somethong went wrong when calling the API.");
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var response = await _httpClient.GetAsync("/Catalog");
            return await response.ReadContentAs<IEnumerable<CatalogModel>>();
        }

        public async Task<CatalogModel> GetCatalog(Guid id)
        {
            var response = await _httpClient.GetAsync($"/Catalog/{id}");
            return await response.ReadContentAs<CatalogModel>();
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            var response = await _httpClient.GetAsync($"/Catalog/GetProductByCategory/{category}");
            return await response.ReadContentAs<IEnumerable<CatalogModel>>();
        }
    }
}
