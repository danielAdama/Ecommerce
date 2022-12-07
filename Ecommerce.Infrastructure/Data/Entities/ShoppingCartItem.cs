using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
#nullable disable
        public int SelectedAmount { get; set; }


        // Shopping cartId of a product 
        [ForeignKey("ShoppingCardId")]
        public Product Product { get; set; }
        public string ShoppingCartId { get; set; } //FK


    }

    public class ShoppingCart : BaseEntity
    {
#nullable disable
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public long CartId { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
