using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02.Marketplace
{
	class Product
	{
		public string Name { get; }
		public List<Price> PriceList { get; }

		public Product(string name)
		{
			this.Name = name;
			PriceList = new List<Price>();
		}

		public void ShowAllPrices()
		{
			Console.WriteLine($"Prices info for {Name}");
			foreach (var price in PriceList)
			{
				Console.WriteLine($"Price in shop {price.Shop.Name}: {price.Value}");
			}
		}
	}
}
