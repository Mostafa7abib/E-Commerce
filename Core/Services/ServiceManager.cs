using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Services.Absraction;
using Shared;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IBasketService> _basketService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IUnitOfWork unitOfWork,IMapper mapper,IBasketRepository repository,UserManager<User> userManager,IOptions<JwtOptins> options)
        {
            _productService = new Lazy<IProductService>(() =>
                new ProductService(unitOfWork, mapper));
            _basketService = new Lazy<IBasketService>(() =>
                new BasketService(repository, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
                new AuthenticationService(userManager,options));
        }
        public IProductService ProductService => _productService.Value;

        public IBasketService BasketService => _basketService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
