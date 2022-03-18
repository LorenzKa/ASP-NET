using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    [Serializable]
    public class Elefant : Carnivore
    {
        
        public override string? Name { get; set; } = "Elefant";
        public override int Price { get; set; } = 50000;
        public override double GreenfoodUsage { get; set; } = 50;
    }
}
