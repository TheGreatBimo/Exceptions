using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02.Marketplace
{
	class ShopNameAlreadyTakenException : Exception
	{
		public ShopNameAlreadyTakenException(string shopName, string marketName) : base($"Shop with name {shopName} already exists in market {marketName}")	{ }
	}
}
