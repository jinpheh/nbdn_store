using System;
using System.Data;
using System.Security.Principal;
using System.Threading;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.examples
{
    public class CalculatorSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Calculator,BasicCalculator>
        {
            context c = () =>
            {
                provide_a_basic_sut_constructor_argument(12);
                provide_a_basic_sut_constructor_argument("sdfsf");
                the_connection = the_dependency<IDbConnection>();
            };

            protected static IDbConnection the_connection;
        }

        public class when_closing_the_connection_and_they_are_in_the_correct_role : concern
        {
            context c = () =>
            {
                our_principal = an<IPrincipal>();

                our_principal.Stub(x => x.IsInRole(Arg<string>.Is.NotNull)).Return(true);


                change(() => Thread.CurrentPrincipal).to(our_principal);
            };


            //act
            because b = () =>
            {
                sut.close_the_connection();
            };


            it should_close_the_connection = () =>
            {
                the_connection.received(x => x.Close());
            };

            static IPrincipal our_principal;
        }

        public class when_closing_the_connection_and_they_are_not_in_the_correct_role : concern
        {
            context c = () =>
            {
                our_principal = an<IPrincipal>();

                our_principal.Stub(x => x.IsInRole(Arg<string>.Is.NotNull)).Return(false);

                change(() => Thread.CurrentPrincipal).to(our_principal);
            };


            //act
            because b = () =>
            {
                doing(() =>sut.close_the_connection());
            };


            it should_not_close_the_connection = () =>
            {
                the_connection.never_received(x => x.Close());
            };

            static IPrincipal our_principal;
        }

        public class when_adding_two_numbers : concern
        {
            context c = () =>
            {
//                the_dependency<>()
//                an<>()
//                provide_a_basic_sut_constructor_argument()
//                  the_connection.Stub()
//                change
                the_connection = the_dependency<IDbConnection>();
                command = an<IDbCommand>();
            };


            //act
            because b = () =>
            {
                //doing
                result = sut.add(1, 3);
            };


            it should_return_the_sum = () =>
            {
                result.should_be_equal_to(4);
            };

            it should_open_a_connection_to_the_database = () =>
            {
                the_connection.received(connection => connection.Open());
            };

            it should_execute_a_command_against_the_database = () =>
            {
                command.received(x => x.ExecuteNonQuery());
            };

            static int result;
            static IDbCommand command;
        }
    }


    public interface Calculator
    {
        void close_the_connection();
        int add(int first, int second);
        void some_new_method();
    }

    public class BasicCalculator : Calculator
    {
        IDbConnection connection;

        public BasicCalculator(string other, int some_value, IDbConnection connection)
        {
            this.connection = connection;
        }

        public void close_the_connection()
        {
            if (Thread.CurrentPrincipal.IsInRole("blah")) connection.Close();
        }


        public int add(int first, int second)
        {
            connection.Open();
            connection.CreateCommand().ExecuteNonQuery();

            return first + second;
        }

        public void some_new_method()
        {
            throw new NotImplementedException();
        }
    }
}