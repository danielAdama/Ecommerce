using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ecommerce.Infrastructure.Data.Entities.Category;

namespace Ecommerce.Infrastructure.Data.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
#nullable disable
        public Product Product { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }

    public class ShoppingCart : BaseEntity
    {
#nullable disable
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public long CartId { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
