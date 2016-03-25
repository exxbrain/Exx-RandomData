using System;
using System.Collections.Generic;
using System.Reflection;

namespace RandomData
{
    public class RandomDataGenerator<T> where T : class
    {
        private readonly InstanceGenerator _generator 
            = new InstanceGenerator(typeof(T));

        public T Generate()
        {
            return (T) _generator.GetValue();
        }

        public IEnumerable<T> Generate(int num)
        {
            for (int i = 0; i < num; i++)
            {
                yield return this.Generate();       
            }
        }
    }
}

