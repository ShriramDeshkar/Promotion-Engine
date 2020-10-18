using Promotion_Engine;
using Promotion_Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Promotion_Engine_Tests
{
    public class TestPromotions
    {
        [Fact]
        public void GetTotalPrice_ShouldReturn_SumOfUnitPrice_WhenNoPromotionAvailable()
        {
            //Arrenge
            var promotions = PromotionEngine.GetActivePromotions();

            //Act
            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("B"), new Product("C") });

            List<decimal> totalorderprice = promotions
                    .Select(promo => PromotionEngine.GetTotalPrice(order, promo))
                    .ToList();
            decimal orderprice = totalorderprice.Sum();

            //Assert
            Assert.Equal(100, orderprice);
        }
    }
}
