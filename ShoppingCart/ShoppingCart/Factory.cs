using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Factory
    {
        private readonly string name;
        private readonly double pricePerUnit;
        private readonly int nrUnits;
        private readonly int weight;
        private readonly int calories;
        private readonly double alcohol;
        public string Name => name;
        public double PricePerUnit => pricePerUnit;
        public int NrUnits => nrUnits;
        public int Weight => weight;
        public int Calories => calories;
        public double Alcohol => alcohol;

        private Factory(FactoryBuilder factoryBuilder)
        {
            this.name = factoryBuilder.name;
            this.pricePerUnit = factoryBuilder.pricePerUnit;
            this.nrUnits = factoryBuilder.nrUnits;
            this.weight = factoryBuilder.weight;
            this.calories = factoryBuilder.calories;
            this.alcohol = factoryBuilder.alcohol;
        }
        public class FactoryBuilder
        {
            internal string name;
            internal double pricePerUnit;
            internal int nrUnits;
            internal int weight;
            internal int calories;
            internal double alcohol;

            public FactoryBuilder(string name, double pricePerUnit, int nrUnits, int weight)
            {
                this.name = name;
                this.pricePerUnit = pricePerUnit;
                this.nrUnits = nrUnits;
                this.weight = weight;
            }
            public FactoryBuilder Calories(int calories)
            {
                this.calories = calories;
                return this;
            }
            public FactoryBuilder Alcohol(double alcohol)
            {
                this.alcohol = alcohol;
                return this;
            }
            public T Build<T>()
            {
                throw new NotImplementedException();

            }
        }
    }
}
