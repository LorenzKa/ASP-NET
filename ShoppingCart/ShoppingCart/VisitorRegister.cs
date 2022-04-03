
using ElementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class VisitorRegister : IVisitor
    {
        public string ResultString => throw new NotImplementedException();
        public double value = 0.0;
        public void Reset()
        {
            value = 0.0;
        }

        public void VisitBeverage(Beverage beverage)
        {
            value += beverage.PricePerUnit * beverage.NrUnits;
        }

        public void VisitCosmetic(Cosmetic cosmetic)
        {
            value += cosmetic.PricePerUnit * cosmetic.NrUnits;
        }

        public void VisitFood(Food food)
        {
            value += food.PricePerUnit * food.NrUnits;
        }
    }
}
