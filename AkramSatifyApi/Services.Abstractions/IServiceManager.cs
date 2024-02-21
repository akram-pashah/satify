using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IOwnerService OwnerService { get; }

        IAccountService AccountService { get; }

        ICategoryService CategoryService { get; }

        IProductService ProductService { get; }

        ICartService CartService { get; }

        IOrderService OrderService { get; }

        IUserService UserService { get; }
    }
}
