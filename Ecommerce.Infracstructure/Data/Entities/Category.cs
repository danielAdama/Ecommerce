using Ecommerce.Infracstructure.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infracstructure.Data.Entities
{
    public class Category : BaseEntity
    {
#nullable disable
        public string Name { get; set; }
        // One-to-many relationship: there are items in different category
        public ICollection<Product> Products { get; set; }
        // public List<Item> Item { get; set; } = new List<Item>
    }

    public class Product : BaseEntity 
    {
#nullable disable
        public string Name { get; set; }
        public double Price { get; set; }
        public string ProductLogo { get; set; }
        public ProductCategoryEnum ProductCategory { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public ICollection<Seller> Sellers { get; set; }

        public long CategoryId { get; set; }
        // One-to-one relationship: Each item belong to a category
        public Category Category { get; set; }

    }

    public class Order : BaseEntity
    {
#nullable disable
        public Guid TrackingId { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public EcommerceUser User { get; set; }
        // One-to-many relationship: there are items in different cart
        public ICollection<ShoppingCartItem> Items { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem : BaseEntity
    {
#nullable disable
        public int Amount { get; set; }
        public double Price { get; set; }

        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public long OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }

    public class Seller : BaseEntity
    {
#nullable disable
        public string FullName { get; set; }
        public GenderTypeEnum GenderType { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<Product> Products { get; set; }
    }

}
