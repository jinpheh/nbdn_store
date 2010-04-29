using System;
using System.Collections.Generic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public class DefaultCartTasks : CartTasks
    {
        Request request;

        public DefaultCartTasks(Request request, CartTasks cart_tasks;)
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