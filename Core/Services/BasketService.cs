using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Services.Absraction;
using Shared;

namespace Services
{
    public class BasketService(IBasketRepository basketRepository,IMapper mapper) : IBasketService
    {
        public async Task<BasketDto?> GetBasketAsync(string id)
        {
            var basket = await basketRepository.GetBasketAsync(id);
            return  basket is null ? throw new BasketNotFoundException(id) : mapper.Map<BasketDto?>
                (basket);
        }

        public async Task<bool> DeleteBasketAsync(string id)
        => await basketRepository.DeleteBasketAsync(id);

        public async Task<BasketDto?> UpdateBasketAsync(BasketDto basket)
        {
            var customerBasket = await basketRepository.UpdateBasketAsync(mapper.Map<CustomerBasket>(basket));
            return customerBasket is null ? throw new Exception("Can't Update The Basket") : mapper.Map<BasketDto>(customerBasket);
        }
    }
}
