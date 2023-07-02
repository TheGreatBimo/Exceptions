using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02.Marketplace
{
	class ShopNotFoundException : Exception
	{
		public ShopNotFoundException(string shopName, string marketName) :base($"'{shopName}' is not in '{marketName}' market.") { }
	}
}
