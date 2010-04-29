using System;
using System.Collections.Specialized;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.mappers;

namespace nothinbutdotnetstore.tests.web
{
    public class DepartmentMapperSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Mapper<NameValueCollection, Department>,
                                            DepartmentMapper>
        {
        }

        [Concern(typeof (DepartmentMapper))]
        public class when_mapping_a_department_from_a_name_value_collection : concern
        {
            context c = () =>
            {
                form_data = new NameValueCollection();
                department_name = "this is the department";
                first_of_january_2009 = new DateTime(2009,1,1);

                form_data.Add(PayloadKeys.department.name, department_name);
                form_data.Add(PayloadKeys.department.active_in_store_since, first_of_january_2009.ToShortDateString());
                form_data.Add(PayloadKeys.department.is_active, true.ToString());
            };

            because b = () =>
            {
                result = sut.map(form_data);
            };


            it should_return_a_well_formed_department = () =>
            {
                result.name.should_be_equal_to(department_name);
                result.active_in_store_since.should_be_equal_to(first_of_january_2009);
                result.is_special.should_be_true();
            };

            static Department result;
            static string department_name;
            static NameValueCollection form_data;
            static DateTime first_of_january_2009;
        }
    }
}