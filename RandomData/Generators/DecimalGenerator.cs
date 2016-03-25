using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RandomData
{
    internal class DecimalGenerator : IValueGenerator
	{
        private Random _rand = new Random();

        #region IValueGenerator implementation
        public object GetValue()
        {
            var units = _rand.Next(1, 2000);
            var decimals = _rand.Next(1, 99);
            return decimal.Parse(units + "." + decimals);
        }
        #endregion
	}

}

