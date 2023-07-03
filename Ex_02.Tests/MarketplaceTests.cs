using System;
using System.Collections.Generic;
using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Ex_02.Marketplace;

namespace Ex_02.Marketplace.Tests
{
	public class MarketplaceTests
	{
		[Fact]
		public void MarketName_ShouldBeSet_Correctly()
		{
			Market market = new Market()
			{
				Name = "Test",
			};

			Assert.Equal("Test", market.Name);
		}

		[Fact]
		public void MarketName_CanBe_Changed()
		{
			Market market = new Market()
			{
				Name = "Test",
			};

			Assert.Equal("Test", market.Name);

			market.Name = "Test2";
			Assert.Equal("Test2", market.Name);
		}

		[Fact]
		public void Market_ShopsProperty_ShouldReturn_CorrentCollection()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			var shops = market.Shops;

			Assert.IsType<List<Shop>>(shops);

			Assert.Same(shop1, shops.First());
			Assert.Same(shop2, shops.Last());
		}

		[Fact]
		public void CreateShop_method_shouldCreate_newShop()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			Assert.True(shop1 != null);
			Assert.True(shop2 != null);
		}

		[Fact]
		public void CreateShop_method_shouldCreate_newShop_withCorrectName()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			Assert.Equal(shop1.Name, shop1Name);
			Assert.Equal(shop2.Name, shop2Name);
		}

		[Fact]
		public void CreateShop_method_createdShop_mustBe_InMarket()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			Assert.Contains(shop1, market);
			Assert.Contains(shop2, market);
		}

		[Fact]
		public void CreateShop_method_ThrowsEx_When_ShopNameAlreadyTaken()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Assert.Throws<ShopNameAlreadyTakenException>(() => market.CreateShop(shop1Name));
		}

		[Fact]
		public void Market_ShouldReturn_CorrectCount()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			Assert.Equal(2, market.Count);
		}

		[Fact]
		public void Market_CanBe_Enumerated()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			Assert.Same(shop1, market.AsEnumerable().First());
			Assert.Same(shop2, market.AsEnumerable().Last());
		}

		[Fact]
		public void Market_Indexator_Returns_Correct_Entries()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			Assert.Same(shop1, market[shop1Name]);
			Assert.Same(shop2, market[shop2Name]);
		}

		[Fact]
		public void Market_Indexator_Throws_Exception_When_NotFound()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			Assert.Throws<ShopNotFoundException>(() => market["Test"]);
		}

		[Fact]
		public void Market_ShouldBe_ICollection_ofShops()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			Assert.True(market is ICollection<Shop>);
		}

		[Fact]
		public void Market_ShouldBe_notReadOnly_ICollection()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			Assert.False(market.IsReadOnly);
		}

		[Fact]
		public void Market_ICollection_ContainsMethod_ShouldWork()
		{
			Market market1 = new Market();
			Market market2 = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market1.CreateShop(shop1Name);
			Shop shop2 = market2.CreateShop(shop2Name);

			Assert.Contains(shop1, market1);
			Assert.Contains(shop2, market2);
			Assert.DoesNotContain(shop1, market2);
			Assert.DoesNotContain(shop2, market1);
		}

		[Fact]
		public void Market_ICollection_AddMethod_ShouldWork_When_ShopMarket_IsNull()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = new Shop(shop1Name, null);
			Shop shop2 = new Shop(shop2Name, null);

			market.Add(shop1);

			Assert.Contains(shop1, market);
			Assert.DoesNotContain(shop2, market);
		}

		[Fact]
		public void Market_ICollection_AddMethod_ShouldThrowEx_When_Shop_IsIn_Market()
		{
			Market market1 = new Market();
			Market market2 = new Market();

			string shop1Name = Guid.NewGuid().ToString();

			Shop shop1 = new Shop(shop1Name, market1);

			Assert.Throws<ShopIsInAnotherMarketException>(() => market2.Add(shop1));
		}

		[Fact]
		public void Market_ICollection_ClearMethod_ShouldWork_for_EmptyMarket()
		{
			Market market = new Market();

			Assert.Empty(market);

			market.Clear();

			Assert.Empty(market);
		}

		[Fact]
		public void Market_ICollection_ClearMethod_ShouldWork_for_NotEmptyMarket()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			Assert.NotEmpty(market);

			market.Clear();

			Assert.Empty(market);
		}

		[Fact]
		public void Market_ICollection_RemoveMethod_ShouldWork_for_ShopInMarket()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = market.CreateShop(shop2Name);

			Assert.Contains(shop1, market);
			Assert.Contains(shop2, market);

			market.Remove(shop1);

			Assert.DoesNotContain(shop1, market);
			Assert.Contains(shop2, market);
		}

		[Fact]
		public void Market_ICollection_RemoveMethod_ShouldThrowEx_When_ShopMarket_IsNull()
		{
			Market market = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market.CreateShop(shop1Name);
			Shop shop2 = new Shop(shop2Name, null);

			Assert.Contains(shop1, market);
			Assert.DoesNotContain(shop2, market);

			Assert.Throws<ShopNotFoundException>(() => market.Remove(shop2));
		}

		[Fact]
		public void Market_ICollection_RemoveMethod_ShouldThrowEx_When_ShopMarket_IsDifferent()
		{
			Market market1 = new Market();
			Market market2 = new Market();
			string shop1Name = Guid.NewGuid().ToString();
			string shop2Name = Guid.NewGuid().ToString();

			Shop shop1 = market1.CreateShop(shop1Name);
			Shop shop2 = market2.CreateShop(shop2Name);

			Assert.Contains(shop1, market1);
			Assert.Contains(shop2, market2);

			Assert.Throws<ShopNotFoundException>(() => market1.Remove(shop2));
		}
	}
}
