using Afk.Measure.Converter;
using Afk.Measure.Units.Metric.Derived;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    class Calorie : Joule
    {
        public Calorie()
        {
            this._symbol = "cal";
            this._baseConverter = new MultiplyConverter(4.184);
        }
    }
}
