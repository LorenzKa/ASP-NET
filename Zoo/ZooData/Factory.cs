using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zoo;

namespace ZooData
{
    public class Factory
    {
        public Dictionary<string, Animal> animals = new();
        public Factory()
        {
            animals = GetDictonaryOfType<Animal>();
        }

        public Animal GetAnimal(string animal)
        {
            return animals.GetValueOrDefault(animal)!;
        }

        public Dictionary<string, T> GetDictonaryOfType<T>(params object[] constructorArgs) where T : class
        {
            return Assembly.GetAssembly(typeof(T))
                .GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(T)))
                .Select(type => (T)Activator.CreateInstance(type, constructorArgs))
                .ToDictionary(x => x.GetType().FullName);
        }

        public Animal cloneAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
