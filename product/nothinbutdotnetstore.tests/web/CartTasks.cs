using System.Collections.Generic;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public interface CartTasks
    {
        List<CartItem> get_items();
        void addItem(CartItem cart_item);
    }
}