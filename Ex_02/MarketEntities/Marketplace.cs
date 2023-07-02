using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02.Marketplace
{
	class Market : ICollection<Shop>
	{
		public List<Shop> Shops { get; set; }
		public string Name { get; set; }

		public Market()
		{
			Shops = new List<Shop>();
		}

		public Shop CreateShop(string name)
		{
			Shop shopByName = Shops.Find(shop => shop.Name == name);
			if (shopByName != null)
				throw new ShopNameAlreadyTakenException(name, this.Name);
			return new Shop(name, this);
		}

		public Shop this[string name]
		{
			get
			{
				Shop shopByName = Shops.Find(shop => shop.Name == name);

				if (shopByName == null)
				{
					throw new ShopNotFoundException(name, this.Name);
				}
				return shopByName;
			}
		}

		public int Count
		{
			get
			{
				return Shops.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public void Add(Shop item)
		{
			Shops.Add(item);
		}

		public void Clear()
		{
			Shops.Clear();
		}

		public bool Contains(Shop item)
		{
			return Shops.Contains(item);
		}

		public void CopyTo(Shop[] array, int arrayIndex)
		{
			Shops.CopyTo(array, arrayIndex);
		}

		public IEnumerator<Shop> GetEnumerator()
		{
			return Shops.GetEnumerator();
		}

		public bool Remove(Shop item)
		{
			return Shops.Remove(item);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (Shops as IEnumerable).GetEnumerator();
		}
	}
}
