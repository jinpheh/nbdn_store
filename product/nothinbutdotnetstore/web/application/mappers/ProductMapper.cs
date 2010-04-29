using System;
using System.Collections.Specialized;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.application.mappers
{
	public class ProductMapper : Mapper<NameValueCollection, Product>
	{
		public Product map(NameValueCollection input)
		{
			return new Product
			{
				Name = PayloadKeys.product.Name.map_from(input),
				Description = PayloadKeys.product.Description.map_from(input),
				Price = PayloadKeys.product.Price.map_from(input)
			};
		}
	}
}