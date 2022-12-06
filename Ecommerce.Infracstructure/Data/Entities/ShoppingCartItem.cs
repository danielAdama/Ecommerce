namespace Ecommerce.Infracstructure.Data.Entities
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