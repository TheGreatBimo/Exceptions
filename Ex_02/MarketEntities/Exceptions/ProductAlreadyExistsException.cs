using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02.Marketplace
{
	class ProductAlreadyExistsException : Exception
	{
		public ProductAlreadyExistsException(Price price) : base($"This product already exists in shop {price.Shop.Name}") { }
	}
}
