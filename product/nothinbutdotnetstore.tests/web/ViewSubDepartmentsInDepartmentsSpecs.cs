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
    public class ViewSubDepartmentsInDepartmentsSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ApplicationCommand,
                                            ViewSubDepartmentsInDepartment>
        {
        }

        [Concern(typeof (ViewSubDepartmentsInDepartment))]
        public class when_displaying_the_list_of_the_sub_departments_in_department : concern
        {
            context c = () =>
            {
                request = an<Request>();
                sub_departments = new List<Department>();
                response_engine = the_dependency<ResponseEngine>();
                department = new Department();
                catalog_tasks = the_dependency<CatalogTasks>();


                request.Stub(x => x.map<Department>()).Return(department);
                catalog_tasks.Stub(x => x.get_all_sub_departments_in_department(department)).Return(sub_departments);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_display_only_the_main_departments_in_the_store = () =>
            {
                response_engine.received(x => x.display(sub_departments));
            };

            static ResponseEngine response_engine;
            static Request request;
            static CatalogTasks catalog_tasks;
            static IEnumerable<Department> sub_departments;
            static Department department;
        }
    }
}