using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Löwe : Herbivore
    {
        public override string? Name { get; set; } = "Löwe";
        public override int Price { get; set; } = 100000;
        public override double MeatUsage { get; set; } = 5.0;
    }
}
