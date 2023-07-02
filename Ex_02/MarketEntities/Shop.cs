using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02.Marketplace
{
	public class Shop : ICollection<Product>
	{
		public Market Market { get; set; }
		public string Name { get; set; }

		public List<Product> Products;

		public Dictionary<Product, Price> Pricelist { get; set; }

		public Shop(string name, Market market)
		{
			Name = name;
			market.Add(this);
			Market = market;
			Products = new List<Product>();
			Pricelist = new Dictionary<Product, Price>();
		}
		public void AddProduct(Product product, int price)
		{
			new Price(product, this, price);
		}

		public void UpdateProduct(Product product, int newPrice)
		{
			Pricelist[product].Value = newPrice;
		}

		public void ShowAllProducts()
		{
			foreach (var product in Pricelist)
			{
				Console.WriteLine($"Product Name: {product.Key.Name}");
				Console.WriteLine($"Product Price: {product.Value.Value}");
			}
		}
		public int Count
		{
			get
			{
				return Products.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public void Add(Product item)
		{
			Products.Add(item);
		}

		public void Clear()
		{
			Products.Clear();
		}

		public bool Contains(Product item)
		{
			return Products.Contains(item);
		}

		public void CopyTo(Product[] array, int arrayIndex)
		{
			Products.CopyTo(array, arrayIndex);
		}

		public IEnumerator<Product> GetEnumerator()
		{
			return Products.GetEnumerator();
		}

		public bool Remove(Product item)
		{
			return Products.Remove(item);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return (Products as IEnumerable).GetEnumerator();
		}
	}
}
