using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zoo;

namespace ZooData
{
    public sealed class Factory
    {
        private static Factory instance = null;
        private static readonly object padlock = new object();

        public Dictionary<string, Animal> Spezies { get; }
        public static Factory Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Factory();
                    }
                    return instance;
                }
            }
        }
        Factory()
        {
            Spezies = GetDictonaryOfType<Animal>();
        }

        public Animal GetAnimal(string animal)
        {
            return Spezies.GetValueOrDefault(animal)!;
        }

        public Dictionary<string, T> GetDictonaryOfType<T>(params object[] constructorArgs) where T : class
        {
            return Assembly.GetAssembly(typeof(T))
                .GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(T)))
                .Select(type => (T)Activator.CreateInstance(type, constructorArgs))
                .ToDictionary(x => x.GetType().Name);
        }

        public Animal FactoryMethod(string animal)
        {
            return Spezies[animal];
        }
    }
}
