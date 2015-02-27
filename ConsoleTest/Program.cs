using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Afk.Measure.Units;
using Afk.Measure.Quantity;
using Afk.Measure.Units.System;
using Afk.Measure.Units.Metric.SI;
using Afk.Measure.Units.Metric.Prefixes;
using Afk.Measure.Units.Metric;
using Afk.Measure.Units.Metric.Derived;
using Afk.Measure.Quantity.Base;
using Afk.Measure.Units.Imperial;

namespace ConsoleTest {
	class Program {

		class A<T> {
		}

		static void Main(string[] args) {
			try {
				Unit[] units = Unit.WellKnownUnits;

                Unit.Parse("pt");

                UKVolume();
                Console.ReadLine();
                return;

				Temperature<double> klv = 5;
				Temperature<long> klv2 = 15;

                var litre = Quantity.None<Litre>(1);
                Console.WriteLine(litre.ConvertTo(Unit.Parse("ml")));
                Console.WriteLine(litre.ConvertTo(Unit.Parse("pt")));

                //var k3 = klv * klv2;

                // Unit path : si on effectue W * h et après / h, il est bien de se souvenir qu'on est
                // venu de W pour retomber sur cette unité
                var watt = Quantity.None<Watt>(1);
                var wh = watt * Quantity.None<Hour>(1);
                var wt = wh / Quantity.None<Hour>(1);

                // m.C * C doit être possible même si pas de converter vers unité de base
                var lg = 10 * SI.METER;
                var mc = lg * (Quantity.None<double, Celsius>(6));
                var mcc = mc * Quantity.None<double, Celsius>(5);

				var qd = new DerivedQuantity<double>(5, "m3");

			//	var qfi = klv * klv2;
				var qc = (klv).ConvertTo(Unit.Parse("°C"));

				Afk.Measure.Quantity.Derived.Volume<double> v = 12;
				Console.WriteLine(v.ConvertTo(Unit.Parse("kl")));

				var v2 = Quantity.Deci<Litre>(764.1);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("mm3")));

				v2 = Quantity.Hecto<Volume>(4);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("hl")));

				v2 = Quantity.Deka<Litre>(1257);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("m3")));

				v2 = Quantity.Centi<Volume>(1729.743);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("dl")));

				v2 = Quantity.Milli<Volume>(128.173);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("ml")));

				v2 = Quantity.Deka<Volume>(3);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("hl")));

				v2 = Quantity.None<Litre>(79.47);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("cm3")));

				v2 = Quantity.Centi<Litre>(73475);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("m3")));

				v2 = Quantity.Deci<Volume>(4.59);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("dl")));

				/*
				var m2 = Quantity.Kilo<Meter>(5);
				var c = Quantity.None<double, Celsius>(6);
				var k = Quantity.None<double, Kelvin>(8);
				var second = Quantity.None<double, Second>(4);
				var hour = Quantity.None<double, Hour>(4);

				var item = (m2 * c) / (second * k);
				*/

				//Console.WriteLine(item.ToString());
			}
			catch (Exception e) {
				Console.WriteLine(e.ToString());
			}
			Console.WriteLine("Press a key to quit");
			Console.ReadLine();
		}

        static void UKVolume()
        {
            var litre = Quantity.None<Litre>(1);
            Console.WriteLine(litre.ConvertTo(Unit.Parse("m3")));

            var pint = Quantity.None<Afk.Measure.Units.US.Pint>(1);
            Console.WriteLine(pint.ConvertTo(Unit.Parse("ml")));
        }
	}
}
