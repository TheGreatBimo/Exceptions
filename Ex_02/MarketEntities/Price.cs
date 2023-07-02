using System;

namespace Ex_02.Marketplace
{
	class Price
	{
		public double Value { get; set; }
		public Shop Shop { get; }
		public Product Product { get; }

		public Price(Product product, Shop shop, double value)
		{
			if (product == null)
				throw new ArgumentNullException(nameof(product));

			if (shop == null)
				throw new ArgumentNullException(nameof(shop));

			if (value <= 0)
				throw new ArgumentOutOfRangeException(nameof(value));
			

			Product = product;
			Shop = shop;
			Value = value;
		}
	}
}
