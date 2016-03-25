using System;

namespace RandomData
{
    internal class StringGenerator : IValueGenerator
    {
        private readonly Random _random = new Random();
        #region IValueGenerator implementation

        public object GetValue()
        {
            var start = _random.Next(0, Data.LoremIpsum.Length - 100);
            var length = _random.Next(50, 100);
            var text = Data.LoremIpsum.Substring(start, length);
            text = text.Replace(".", "");
            return text;
        }

        #endregion
    }
}

