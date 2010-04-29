using System.Collections.Specialized;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application.mappers;

namespace nothinbutdotnetstore.tests.web
 {   
 	public class ProductMapperSpecs
 	{
 		public abstract class concern : observations_for_a_sut_with_a_contract<Mapper<NameValueCollection,Product>,
 		                                	ProductMapper>
 		{
        
 		}

 		[Concern(typeof(ProductMapper))]
 		public class when_mapping_a_product_from_a_namevaluecollection : concern
 		{
 			context c = () =>
 			{
 				name = "cow hide";
 				desc = "blah";
 				price = (decimal) 5.30F;
 				item_data = new NameValueCollection();
 				product = new Product(name, desc, price);
 			};

 			because b = () =>
 			{
 				result = sut.map(item_data);
 			};

        
 			it should_return_the_product_from_collection = () =>
 			{
 				result.Name.should_be_equal_to(name);
				result.Description.should_be_equal_to(desc);
				result.Price.should_be_equal_to(price);
 			};

 			static Product result;
 			static NameValueCollection item_data;
 			static string name;
 			static string desc;
 			static decimal price;
 			static Product product;
 		}
 	}
 }
