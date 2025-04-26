using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Services.Absraction
{
    public interface IBasketService
    {
        //Get , Update , Delete
        Task<BasketDto?> GetBasketAsync(string id);
        Task<bool> DeleteBasketAsync(string id);
        Task<BasketDto?> UpdateBasketAsync(BasketDto basket);
    }
}
