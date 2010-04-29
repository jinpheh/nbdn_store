using System;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class AddProductToCart : ApplicationCommand
    {
        ResponseEngine response_engine;
        CartTasks manager;

        public void process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}