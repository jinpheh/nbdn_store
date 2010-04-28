using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using MbUnit.Framework;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class FrontControllerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<FrontController,
                                            DefaultFrontController>
        {
        }

        [Concern(typeof (DefaultFrontController))]
        public class when_processing_a_request : concern
        {
            context c = () =>
            {
                command_registry = the_dependency<CommandRegistry>();

                request = an<Request>();
                command_that_can_handle_the_request = an<RequestCommand>();


                command_registry.Stub(x => x.get_command_that_can_handle(request)).Return(command_that_can_handle_the_request);
            };


            because b = () =>
            {
                sut.process(request);
            };


            it should_dispatch_the_processing_to_the_command_for_the_request = () =>
            {
                command_that_can_handle_the_request.received(x => x.process(request));
            };

            static RequestCommand command_that_can_handle_the_request;
            static Request request;
            static CommandRegistry command_registry;
        }
    }
}