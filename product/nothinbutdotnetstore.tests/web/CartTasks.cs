using System;
using System.Collections.Generic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    class CartTasks
    {
        Request request;

        public CartTasks(Request request)
        {
            this.request = request;
        }

        public List<CartItem> get_items()
        {
            throw new NotImplementedException();
        }

        public void addItem(CartItem cart_item)
        {
            throw new NotImplementedException();
        }
    }
}