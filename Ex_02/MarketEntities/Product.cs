using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02.Marketplace
{
	public class Product
	{
		public string Name { get; }
		public List<Price> PriceList { get; }

		public Product(string name)
		{
			this.Name = name;
			PriceList = new List<Price>();
		}
	}
}
