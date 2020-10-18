using Promotion_Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Promotion_Engine
{
    public class PromotionEngine
    {
        public static decimal GetTotalPrice(Order ord, Promotion prom)
        {
            decimal d = 0;

            var copp = ord.Products
                .GroupBy(x => x.Id)
                .Where(grp => prom.ProductInfo.Any(y => grp.Key == y.Key && grp.Count() >= y.Value))
                .Select(grp => grp.Count())
                .Sum();
            int ppc = prom.ProductInfo.Sum(kvp => kvp.Value);
            while (copp >= ppc)
            {
                d += prom.PromoPrice;
                copp -= ppc;
            }
            decimal nopromotionval = 0;
            foreach (var i in prom.ProductInfo.Keys)
            {
                if (ord.Products.FirstOrDefault(x => x.Id == i) != null)
                {
                    if(copp != 0)
                        nopromotionval += copp * ord.Products.FirstOrDefault(x => x.Id == i).Price;
                    else
                        nopromotionval += ord.Products.FirstOrDefault(x => x.Id == i).Price;
                }
            }
            return d + nopromotionval;
        }

        public static List<Promotion> GetActivePromotions()
        {
            Dictionary<String, int> d1 = new Dictionary<String, int>();
            d1.Add("A", 3);
            Dictionary<String, int> d2 = new Dictionary<String, int>();
            d2.Add("B", 2);
            Dictionary<String, int> d3 = new Dictionary<String, int>();
            d3.Add("C", 1);
            d3.Add("D", 1);
            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, d1, 130),
                new Promotion(2, d2, 45),
                new Promotion(3, d3, 30)
            };
            return promotions;
        }
    }
}
