using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    [Serializable]
    public abstract class Herbivore : BaseAnimal
    {

        public abstract double MeatUsage { get; set; }
    }
}
