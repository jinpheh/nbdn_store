 using System.Collections.Specialized;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {   
     public class PayloadKeySpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<PayloadKey<int>>
         {
        
         }

         [Concern(typeof(PayloadKey<>))]
         public class when_implicitly_converting_to_a_string : concern
         {
             context c = () =>
             {
                 key_name = "sdfsfasdf";
                provide_a_basic_sut_constructor_argument(key_name); 
             };

             because b = () =>
             {
                 result = sut;
             };

        
             it should_return_the_name_of_its_key = () =>
             {
                result.should_be_equal_to(key_name);
            
            
             };

             static string result;
             static string key_name;
         }

         [Concern(typeof(PayloadKey<>))]
         public class when_mapping_from_a_name_value_collection : concern
         {
             context c = () =>
             {
                 key_name = "sdfsfasdf";
                 collection = new NameValueCollection();

                 collection.Add(key_name, 34.ToString());
                 provide_a_basic_sut_constructor_argument(key_name); 
             };

             because b = () =>
             {
                 result = sut.map_from(collection);
             };

        
             it should_return_the_value_for_the_key_strongly_typed = () =>
             {
                result.should_be_equal_to(34);
            
            
             };

             static int result;
             static string key_name;
             static NameValueCollection collection;
         }
     }
 }
