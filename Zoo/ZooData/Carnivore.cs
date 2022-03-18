using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    [Serializable]
    public abstract class Carnivore : BaseAnimal
    {

        public abstract double GreenfoodUsage { get; set; }

    }
}
