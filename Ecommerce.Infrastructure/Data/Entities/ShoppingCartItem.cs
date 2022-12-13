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
        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public long ProductId { get; set; } //FK


        // Shopping cartId of a product 
        //public string ShoppingCartId { get; set; } //FK

    }

    
}
