using Ecommerce.Infrastructure.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data.Entities
{
//    public class Category : BaseEntity
//    {  // We need the category table just incase we have new categories tomorrow
//#nullable disable
//        public ProductCategoryEnum ProductCategory { get; set; }
//        // One-to-many relationship: there are items in different category
//        public ICollection<Product> Products { get; set; }
//    }

    public class Product : BaseEntity
    {
        public string? ProductImage { get; set; }
#nullable disable
        public string Name { get; set; }
        public double Price { get; set; }
        

        // One-to-one relationship: Each item belong to a category
        //[ForeignKey("CategoryId")]
        public ProductCategoryEnum ProductCategory { get; set; } //FK
        //public long CategoryId { get; set; } 


        public bool IsAvailable { get; set; }
        //public ICollection<Seller> Sellers { get; set; }

    }

    public class Order : BaseEntity
    {
#nullable disable
        public Guid TrackingId { get; set; }


        //[ForeignKey("EcommerceUser")]
        // A user can have many orders
        public string? UserId { get; set; }
        //public long UserId { get; set; } // FK UserId for the user that orders for product
        //public EcommerceUser? User { get; set; }


        // One-to-many relationship: there are items in different cart
        //public ICollection<ShoppingCartItem> CartItems { get; set; } // do not uncomment this
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } // list of items in an order
    }

    public class OrderItem : BaseEntity
    {
#nullable disable
        public int Quantity { get; set; }
        public double Price { get; set; }



        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public long ProductId { get; set; } //FK


        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public long OrderId { get; set; } //FK


    }

//    public class Seller : BaseEntity
//    {
//#nullable disable
//        public string FullName { get; set; }
//        public GenderTypeEnum GenderType { get; set; }
//        public string PictureUrl { get; set; }
//        public ICollection<Product> Products { get; set; }
//    }
}
