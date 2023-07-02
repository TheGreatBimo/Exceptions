using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex_02.Marketplace;

namespace Ex_02
{
	class Program
	{
		static void Main(string[] args)
		{
			// TODO: Use Add in Shop instead of AddPrice in Product
			Market market = new Market() { Name = "Malika" };
			market.CreateShop("A-01");
			market.CreateShop("A-02");
			market.CreateShop("B-01");
			market.CreateShop("B-02");


			Product product_LGLcd = new Product("LG LCD Screen");
			Product product_Iphone13pro = new Product("Iphone 13 pro");
			Product product_SeagateHDD1Tb = new Product("Seagate HDD 1TB");
			Product product_HPPrinter = new Product("HP Laserjet Printer");

			market["A-01"].AddProduct(product_LGLcd, 650000);
			market["A-02"].AddProduct(product_LGLcd, 639000);
			market["B-01"].AddProduct(product_LGLcd, 645000);
			market["B-02"].AddProduct(product_LGLcd, 650000);

			market["A-01"].AddProduct(product_Iphone13pro, 10000000);
			market["B-01"].AddProduct(product_Iphone13pro, 9700000);

			market["A-02"].AddProduct(product_SeagateHDD1Tb, 560000);
			market["B-02"].AddProduct(product_SeagateHDD1Tb, 520000);

			market["A-01"].AddProduct(product_HPPrinter, 1160000);
			market["A-02"].AddProduct(product_HPPrinter, 1150000);
			market["A-02"].UpdateProduct(product_HPPrinter, 1155000);
			market["B-01"].AddProduct(product_HPPrinter, 1158000);

			Console.WriteLine("Enter the name of shop to list products from:");
			string shopname = Console.ReadLine();
			market[shopname].ShowAllProducts();

			Console.ReadKey();

		}
	}
}
