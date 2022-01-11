using Basket.API.Entities;
using System.Threading.Tasks;

namespace Basket.API.Interfaces.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string username);

        Task UpdateBasket(ShoppingCart basket);

        Task DeleteBasket(string username);
    }
}
