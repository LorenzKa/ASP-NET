using ElementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    internal class VisitorAlcohol : IVisitor
    {
        public double value { get; set; }
        public string ResultString => throw new NotImplementedException();

        public void Reset()
        {
            value = 0.0;
        }  

        public void VisitBeverage(Beverage beverage)
        {
            value += beverage.Alcohol;
        }

        public void VisitCosmetic(Cosmetic cosmetic)
        {
            value += new Random().NextDouble();
        }

        public void VisitFood(Food food)
        {
            value += new Random().NextDouble();
        }
    }
}
