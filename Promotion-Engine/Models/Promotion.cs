using System;
using System.Collections.Generic;
using System.Text;

namespace Promotion_Engine.Models
{
   public class Promotion
    {
        public int PromotionID { get; set; }
        public Dictionary<string, int> ProductInfo { get; set; }
        public decimal PromoPrice { get; set; }

        public Promotion(int promotionid, Dictionary<string, int> productInfo, decimal promoprice)
        {
            this.PromotionID = promotionid;
            this.ProductInfo = productInfo;
            this.PromoPrice = promoprice;
        }
    }
}
