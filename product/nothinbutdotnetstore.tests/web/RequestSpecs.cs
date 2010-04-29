using System.Collections.Specialized;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Request,
                                            DefaultRequest>
        {
        }

        [Concern(typeof (DefaultRequest))]
        public class when_mapping_an_input_model : concern
        {
            context c = () =>
            {
                input_model = new SomeRandomInputModel();
                request_data = new NameValueCollection();
                mapper_registry = the_dependency<MapperRegistry>();
                mapper = an<Mapper<NameValueCollection, SomeRandomInputModel>>();

                mapper.Stub(mapper1 => mapper1.map(request_data)).Return(input_model);

                mapper_registry.Stub(registry => registry.get_mapper_for<NameValueCollection, SomeRandomInputModel>()).Return(mapper);

                provide_a_basic_sut_constructor_argument(request_data);
            };

            because b = () =>
            {
                result = sut.map<SomeRandomInputModel>();
            };


            it should_return_the_model_mapped_using_the_mapper_for_that_input_model = () =>
            {
                result.should_be_equal_to(input_model);
            };

            static SomeRandomInputModel result;
            static SomeRandomInputModel input_model;
            static Mapper<NameValueCollection, SomeRandomInputModel> mapper;
            static NameValueCollection request_data;
            static MapperRegistry mapper_registry;
        }
    }

    public class SomeRandomInputModel
    {
    }
}