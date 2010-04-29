using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.core
{
    public class CartItem
    {
        public virtual Product product { get; set; }
        public virtual int quantity { get; set; }



        public CartItem(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
    }
}