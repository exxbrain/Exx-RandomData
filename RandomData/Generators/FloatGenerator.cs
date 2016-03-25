using System;

namespace RandomData
{
    public class FloatGenerator : IValueGenerator
    {
        private Random _rand = new Random();

        #region IValueGenerator implementation

        public object GetValue()
        {
            var units = _rand.Next(1, 2000);
            var decimals = _rand.Next(1, 99);
            return float.Parse(units + "." + decimals);
        }

        #endregion
    }
}

