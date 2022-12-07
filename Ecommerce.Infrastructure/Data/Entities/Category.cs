﻿using Ecommerce.Infrastructure.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data.Entities
{
    public class Category : BaseEntity
    {  // We need the category table just incase we have new categories tomorrow
#nullable disable
        public string Name { get; set; }
        // One-to-many relationship: there are items in different category
        public ICollection<Product> Products { get; set; }
    }

    public class Product : BaseEntity
    {
#nullable disable
        public string Name { get; set; }
        public double Price { get; set; }
        public string ProductImage { get; set; }
        

        // One-to-one relationship: Each item belong to a category
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public long CategoryId { get; set; } //FK


        public bool IsAvailable { get; set; }
        //public ICollection<Seller> Sellers { get; set; }

    }

    public class Order : BaseEntity
    {
#nullable disable
        public Guid TrackingId { get; set; }
        

        [ForeignKey(nameof(UserId))]
        public EcommerceUser User { get; set; }
        // A user can have many orders
        public long UserId { get; set; } // FK


        // One-to-many relationship: there are items in different cart
        public ICollection<ShoppingCartItem> CartItems { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } // list of items in an order
    }

    public class OrderItem : BaseEntity
    {
#nullable disable
        public int SelectedAmount { get; set; }
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
