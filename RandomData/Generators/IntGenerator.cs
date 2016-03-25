using System;
using System.Collections.Generic;

namespace RandomData
{
    internal class IntGenerator : IValueGenerator
	{
        private Random _rand = new Random();
        private readonly int _minValue;
        private readonly int _maxValue;

        public IntGenerator(int minValue = 1, int maxValue = 20000)
        {
            this._maxValue = maxValue;
            this._minValue = minValue;
        }

        #region IValueGenerator implementation

        public object GetValue()
        {
            return _rand.Next(this._minValue, this._maxValue);
        }

        #endregion
        
	}

}

