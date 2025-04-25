using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Absraction
{
    public interface IServiceManager
    {
        //Signature Of ProductServices
        public IProductService ProductService { get;}
        //Signature Of BasketServices
        public IBasketService BasketService { get; }
    }
}
