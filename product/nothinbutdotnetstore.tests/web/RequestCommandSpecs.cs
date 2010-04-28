using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using developwithpassion.bdd.mocking.rhino;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestCommandSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RequestCommand,
                                            DefaultRequestCommand>
        {
        }

        [Concern(typeof (DefaultRequestCommand))]
        public class when_determining_if_it_can_handle_a_request : concern
        {
            context c = () =>
            {
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<Predicate<Request>>(x => true);
            };

            because b = () =>
            {
                result = sut.can_handle(request);
            };


            it should_leverage_its_request_specification_to_answer_the_question = () =>
            {
                result.should_be_true();
            };

            static bool result;
            static Request request;
        }

        [Concern(typeof (DefaultRequestCommand))]
        public class when_processing_a_request : concern
        {
            context c = () =>
            {
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<Predicate<Request>>(x => true);
                application_command = the_dependency<ApplicationCommand>();
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_delegate_the_processing_to_the_application_specific_command = () =>
            {
                application_command.received(x => x.process(request));
            };

            static bool result;
            static Request request;
            static ApplicationCommand application_command;
        }
    }
}