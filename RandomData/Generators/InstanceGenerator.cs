using System;
using System.Collections.Generic;
using System.Reflection;

namespace RandomData
{
    internal class InstanceGenerator : IValueGenerator
	{
        private readonly Type _type;
        private readonly ValueUpdater _updater;

        public InstanceGenerator (Type type, ValueUpdater factory)
        {
            this._updater = factory;
            this._type = type;
        }

        #region IValueGenerator implementation

        public object GetValue()
        {
            var instance = Activator.CreateInstance(this._type);
            var typeInfo = this._type.GetTypeInfo();
            foreach (var prop in typeInfo.DeclaredProperties)
            {
                this._updater.UpdateValue(instance, prop);
            }
            return instance;
        }

        #endregion
        
	}

}

