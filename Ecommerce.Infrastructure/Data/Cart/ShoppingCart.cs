using Ecommerce.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data.Cart
{
    public class ShoppingCart
    {
#nullable disable
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public long CartId { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
