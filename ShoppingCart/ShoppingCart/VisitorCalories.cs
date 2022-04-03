using ElementLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class VisitorCalories : IVisitor
    {
        public string ResultString => throw new NotImplementedException();

        public int value { get; set; }

        public void Reset()
        {
            value = 0;
        }

        public void VisitBeverage(Beverage beverage)
        {
            value += beverage.Calories;
        }

        public void VisitCosmetic(Cosmetic cosmetic)
        {
            value += new Random().Next(50, 500);
        }

        public void VisitFood(Food food)
        {
            value += food.Calories;
        }
    }
}
