using System.Collections.Generic;
using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tests.web;
using nothinbutdotnetstore.web.application;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace nothinbutdotnetstore.web.core
 {   
     public class AddProductToCartSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                             AddProductToCart>
         {
         }

         [Concern(typeof(AddProductToCart))]
         public class when_adding_product_to_cart : concern
         {
             context c = () =>
             {
                 request = the_dependency<Request>();
                 responseEngine = the_dependency<ResponseEngine>();
                 default_cart_manager = the_dependency<CartTasks>();
                 
                 cart_item = new CartItem(new Product(), 5);

                 request.Stub(x => x.map<CartItem>()).Return(cart_item);
             };

             because b = () =>
             {
                sut.process(request);
             };

        
             it should_ask_cartTask_to_add_item = () =>
             {
                 default_cart_manager.received(x => x.addItem(cart_item));   
             };

             static IEnumerable<CartItem> results;
             static Request request;
             static ResponseEngine responseEngine;
             static CartTasks default_cart_manager;
             static CartItem cart_item;
         }
     }
 }
