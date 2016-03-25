using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;

namespace RandomData
{
    public class RandomDataGenerator<T> where T : class
    {
        private readonly ValueUpdater _valueUpdater 
            = new ValueUpdater();
        private readonly InstanceGenerator _generator;

        public RandomDataGenerator()
        {
            this._generator = new InstanceGenerator(typeof(T), _valueUpdater);
        }

        public void Ignore<TProp>(Expression<Func<T, TProp>> outExpr)
        {
            var expr = (MemberExpression) outExpr.Body;
            var prop = (PropertyInfo) expr.Member;
            this._valueUpdater.Ignore(prop);
        }

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

