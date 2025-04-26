using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts
{
    public interface IBasketRepository
    {
        //Get Basket
        Task<CustomerBasket?> GetBasketAsync(string id);
        // Delete Basket
        Task<bool> DeleteBasketAsync(string id);
        // Create or Update Basket
        Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket, TimeSpan? timeToLeave=null);
    }
}
