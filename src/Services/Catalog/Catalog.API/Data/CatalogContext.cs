using Catalog.API.Constants;
using Catalog.API.Entities;
using Catalog.API.Interfaces.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IMongoDatabase _database;

        public CatalogContext(IOptions<MongoOptions> mongoOptions)
        {
            var client = new MongoClient(mongoOptions.Value.Connection);
            _database = client.GetDatabase(mongoOptions.Value.Database);

            CatalogContextSeed.SeedData(Products);
        }
        
        public IMongoCollection<Product> Products 
            => _database.GetCollection<Product>(Collections.Products);
    }
}
