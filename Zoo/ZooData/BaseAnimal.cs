using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    [Serializable]
    public abstract class BaseAnimal
    {
        public abstract string? Name { get; set; }
        public abstract int Price { get; set; }
        internal BaseAnimal DeepClone()
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();

            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            var copy = (BaseAnimal)formatter.Deserialize(stream);
            stream.Close();
            return copy;
        }

    }
}
