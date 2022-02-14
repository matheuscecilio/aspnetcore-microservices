using System.Collections.Generic;

namespace AspnetRunBasics.Models
{
    public class BasketModel
    {
        public string UserName { get; set; }
        public List<BasketItemExtentedModel> Items { get; set; }
            = new List<BasketItemExtentedModel>();
        public decimal TotalPrice { get; set; }
    }
}
