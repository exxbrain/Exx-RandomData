using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace RandomData
{
    internal class ValueUpdater
    {
        public ValueUpdater ()
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

        public void Ignore(PropertyInfo prop)
        {
            this._ignoredProperties.Add(prop);
        }

        public void UpdateValue(object obj, PropertyInfo propertyInfo)
        {
            if (this._ignoredProperties.Contains(propertyInfo))
                return;
            
            Func<object> generator;
            if (this._generationMapping.TryGetValue(propertyInfo, out generator))
            {
                propertyInfo.SetValue(obj, generator.Invoke());
                return;
            }

            var type = propertyInfo.PropertyType;
            IValueGenerator valueGenerator;
            if (this._dict.TryGetValue(type, out valueGenerator))
            {
                propertyInfo.SetValue(obj, valueGenerator.GetValue());
                return;
            }
            if (type.Namespace.StartsWith("System"))
                return;

            var instanceGenerator = new InstanceGenerator(type, this);
            propertyInfo.SetValue(obj, instanceGenerator.GetValue());
            return;
        }

        private readonly Dictionary<Type, IValueGenerator> _dict;
        private readonly List<PropertyInfo> _ignoredProperties = new List<PropertyInfo>();
        private readonly Dictionary<PropertyInfo, Func<object>> _generationMapping 
            = new Dictionary<PropertyInfo, Func<object>>();
    }
}

