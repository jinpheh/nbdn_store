using System;

namespace nothinbutdotnetstore.model
{
	public class Product
	{
		public Product(string name, string desc, decimal price)
		{
			Name = name;
			Description = desc;
			Price = price;
		}

		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
	}
}