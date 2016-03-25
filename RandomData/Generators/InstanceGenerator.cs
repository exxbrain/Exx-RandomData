using System;
using System.Collections.Generic;
using System.Reflection;

namespace RandomData
{
    internal class InstanceGenerator : IValueGenerator
	{
        private readonly TypeGeneratorResolver _typeGeneratorResolver 
            = new TypeGeneratorResolver();

        private readonly Type _type;

        public InstanceGenerator (Type type)
        {
            this._type = type;
        }

        #region IValueGenerator implementation

        public object GetValue()
        {
            var instance = Activator.CreateInstance(this._type);
            var typeInfo = this._type.GetTypeInfo();
            foreach (var prop in typeInfo.DeclaredProperties)
            {
                var generator = this._typeGeneratorResolver
                    .GetGenerator(prop.PropertyType);
                if (generator != null)
                    prop.SetValue(instance, generator.GetValue());
            }
            return instance;
        }

        #endregion
        
	}

}

