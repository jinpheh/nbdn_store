 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class DefaultRequestCommandSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<RequestCommand,
                                             DefaultRequestCommand>
         {
        
         }

         [Concern(typeof(DefaultRequestCommand))]
         public class when_determining_if_it_can_handle_a_request : concern
         {
             context c = () =>
             {
            
             };

             because b = () =>
             {
        
             };

        
             it first_observation = () =>
             {
                 
            
            
             };
         }
     }
 }
