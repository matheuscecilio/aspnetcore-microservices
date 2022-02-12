using System.Collections.Generic;

namespace Shopping.Aggregator.Models
{
    public class BasketModel
    {
        public string UserName { get; set; }
        public IEnumerable<BasketItemExtentedModel> Items { get; set; } 
            = new List<BasketItemExtentedModel>();
        public decimal TotalPrice { get; set; }
    }
}
