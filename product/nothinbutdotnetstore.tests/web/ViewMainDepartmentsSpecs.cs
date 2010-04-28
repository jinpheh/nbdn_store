using System.Collections.Generic;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class ViewMainDepartmentsSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                            ViewMainDepartments>
        {
        }

        [Concern(typeof (ViewMainDepartments))]
        public class when_displaying_the_list_of_the_main_departments : concern
        {
            context c = () =>
            {
                request = an<Request>();
                main_departments = new List<Department>();
                response_engine = the_dependency<ResponseEngine>();
                catalog_tasks = the_dependency<CatalogTasks>();


                catalog_tasks.Stub(x => x.get_all_main_departments()).Return(main_departments);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_display_only_the_main_departments_in_the_store = () =>
            {
                response_engine.received(x => x.display(main_departments));
            };

            static ResponseEngine response_engine;
            static IEnumerable<Department> main_departments;
            static Request request;
            static CatalogTasks catalog_tasks;
        }
    }
}