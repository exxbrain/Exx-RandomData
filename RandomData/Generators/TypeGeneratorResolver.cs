using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RandomData
{
    internal class TypeGeneratorResolver
    {
        public TypeGeneratorResolver ()
        {
            var intGenerator = new IntGenerator();
            var floatGenerator = new FloatGenerator();

            _dict = new Dictionary<Type, IValueGenerator>()
            {
                { typeof(int), intGenerator },
                { typeof(float), floatGenerator },
                { typeof(double), floatGenerator },
                { typeof(decimal), new DecimalGenerator() },
                { typeof(long), intGenerator },
                { typeof(string), new StringGenerator() },
                { typeof(DateTime), new DateGenerator() },
            };
        }

        public IValueGenerator GetGenerator(Type type)
        {
            if (!this._dict.ContainsKey(type))
            {
                if (type.Namespace.StartsWith("System"))
                    return null;
                Debug.WriteLine("Unknown type " + type.FullName);
                return new InstanceGenerator(type);
            }
            return this._dict[type];
        }

        private readonly Dictionary<Type, IValueGenerator> _dict;
    }
}

