 using System.Collections.Generic;
 using System.Linq;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;
 using developwithpassion.bdd.core.extensions;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class CommandRegistrySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<CommandRegistry,
                                             DefaultCommandRegistry>
         {
        
         }

         [Concern(typeof(DefaultCommandRegistry))]
         public class when_getting_a_command_for_a_request_and_it_has_the_command : concern
         {
             context c = () =>
             {
                request = an<Request>(); 
                command_that_can_handle_the_request = an<RequestCommand>();

                 all_available_commands = new List<RequestCommand>();
                 Enumerable.Range(1,100).each(x => all_available_commands.Add(an<RequestCommand>()));
                 all_available_commands.Add(command_that_can_handle_the_request);
                 command_that_can_handle_the_request.Stub(x => x.can_handle(request)).Return(true);

                 provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_available_commands);
             };

             because b = () =>
             {
                 result = sut.get_command_that_can_handle(request);
             };

        
             it should_return_the_command_to_the_caller = () =>
             {
                 result.should_be_equal_to(command_that_can_handle_the_request);
            
            
             };

             static RequestCommand result;
             static RequestCommand command_that_can_handle_the_request;
             static Request request;
             static IList<RequestCommand> all_available_commands;
         }

         [Concern(typeof(DefaultCommandRegistry))]
         public class when_attempting_to_get_a_command_for_a_request_and_it_does_not_have_the_command : concern
         {
             context c = () =>
             {
                request = an<Request>(); 

                 all_available_commands = new List<RequestCommand>();
                 Enumerable.Range(1,100).each(x => all_available_commands.Add(an<RequestCommand>()));
                 provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_available_commands);
             };

             because b = () =>
             {
                 result = sut.get_command_that_can_handle(request);
             };

        
             it should_return_a_missing_command_to_the_caller = () =>
             {
                 result.should_be_an_instance_of<MissingRequestCommand>();
             };

             static RequestCommand result;
             static Request request;
             static IList<RequestCommand> all_available_commands;
         }
     }
 }
