 using System.Web;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.tests.utility;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class RawHandlerSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<IHttpHandler,
                                             RawRequestHandler>
         {
        
         }

         [Concern(typeof(RawRequestHandler))]
         public class when_processing_an_incoming_asp_net_request : concern
         {
             context c = () =>
             {
                 front_controller = the_dependency<FrontController>();
                 request_factory = the_dependency<RequestFactory>();
                 http_context = ObjectMother.create_http_context();
                 request = an<Request>();

                 request_factory.Stub(factory => factory.create_a_request_from(http_context)).Return(request);
             };

             because b = () =>
             {
                sut.ProcessRequest(http_context); 
             };
        
             it should_dispatch_the_processing_of_the_request_to_the_front_controller = () =>
             {
                 front_controller.received(x => x.process(request));
             };

             static FrontController front_controller;
             static HttpContext http_context;
             static Request request;
             static RequestFactory request_factory;
         }
     }
 }
