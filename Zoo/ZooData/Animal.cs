using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public abstract class Animal
    {
        public abstract string? Name { get; set; }
        public abstract double GreenfoodUsage { get; set; }
        public abstract double MeatUsage { get; set; }
        public abstract int Price { get; set; }
        
        
    }
}
