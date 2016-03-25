using System;

namespace RandomData
{
    internal class DateGenerator : IValueGenerator
    {
        private readonly Random _random = new Random();

        #region IValueGenerator implementation

        public object GetValue()
        {
            var start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;           
            return start.AddDays(_random.Next(range));
        }

        #endregion
    }
}

