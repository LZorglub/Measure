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
using Afk.Measure.Quantity.Derived;
using System.Globalization;
using Afk.Measure;
using Afk.Measure.Units.Currency;

namespace ConsoleTest {
	class Program {

		static void Main(string[] args) {
			try {

                // Currency exchange (ThreadLocalStorage)
                using (var context = new CurrencyContext())
                {
                    context.AddOrReplaceConverter("$", 0.87745);
                    context.AddOrReplaceConverter("¥", 0.00785);

                    var dollar = 1 * Unit.Parse("$");
                    Console.WriteLine("{0} Dollar to Yen : {1}", dollar.Value, dollar.ConvertTo((Unit)"¥").Value);
                }

                var temperature = 5 * SI.KELVIN;
                var speed = 5 * (SIPrefixe.Kilo * SI.METER);
                var speed2 = 5 * (Unit)"km.s-1";

                // Watthour
                var wh1 = 10 * (Unit)"Wh";
                var watt1 = wh1 / (3600 * SI.SECOND);
                var wh2 = watt1 * (7200 * SI.SECOND);

                // Units
                Unit[] units = Unit.WellKnownUnits;

                UKVolume();
                Console.ReadLine();
                //return;

				Temperature<double> klv = 5;
				Temperature<int> klv2 = 15;
                Quantity<double> cinq = 5;
                var result = klv * cinq;
                klv = klv2;

                Energy<double> energy = 15;
                Energy<int> energyInt = 8;
                energy = energyInt;

                Length<double> metre = 1;

                var metreKelvin = metre * klv;

                var litre = BaseQuantity.None<Litre>(1);
                Console.WriteLine(litre.ConvertTo(Unit.Parse("ml")));
                Console.WriteLine(litre.ConvertTo(Unit.Parse("pt")));

                //var k3 = klv * klv2;

                // Unit path : si on effectue W * h et après / h, il est bien de se souvenir qu'on est
                // venu de W pour retomber sur cette unité
                var watt = BaseQuantity.None<Watt>(1);
                var wh = watt * BaseQuantity.None<Hour>(1);
                var wt = wh / BaseQuantity.None<Hour>(1);

                // m.C * C doit être possible même si pas de converter vers unité de base
                var lg = 10 * SI.METER;
                var mc = lg * (BaseQuantity.None<double, Celsius>(6));
                var mcc = mc * BaseQuantity.None<double, Celsius>(5);

				var qd = new Quantity<double>(5, "m3");

			//	var qfi = klv * klv2;
				var qc = (klv).ConvertTo(Unit.Parse("°C"));

				Afk.Measure.Quantity.Derived.Volume<double> v = 12;
				Console.WriteLine(v.ConvertTo(Unit.Parse("kl")));

				var v2 = BaseQuantity.Deci<Litre>(764.1);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("mm3")));

				v2 = BaseQuantity.Hecto<Volume>(4);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("hl")));

				v2 = BaseQuantity.Deka<Litre>(1257);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("m3")));

				v2 = BaseQuantity.Centi<Volume>(1729.743);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("dl")));

				v2 = BaseQuantity.Milli<Volume>(128.173);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("ml")));

				v2 = BaseQuantity.Deka<Volume>(3);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("hl")));

				v2 = BaseQuantity.None<Litre>(79.47);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("cm3")));

				v2 = BaseQuantity.Centi<Litre>(73475);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("m3")));

				v2 = BaseQuantity.Deci<Volume>(4.59);
				Console.WriteLine(v2.ConvertTo(Unit.Parse("dl")));

                Quantity<double> q1 = 15d;
                /*
				var m2 = Quantity.Kilo<Meter>(5);
				var c = Quantity.None<double, Celsius>(6);
				var k = Quantity.None<double, Kelvin>(8);
				var second = Quantity.None<double, Second>(4);
				var hour = Quantity.None<double, Hour>(4);

				var item = (m2 * c) / (second * k);
				*/
                //BaseQuantity<double> doubleHour = 5d;

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
            var litre = BaseQuantity.None<Litre>(1);
            Console.WriteLine(litre.ConvertTo(Unit.Parse("m3")));
            Console.WriteLine(litre.ConvertTo("m3"));

            var pint = BaseQuantity.None<Afk.Measure.Units.US.Pint>(1);
            Console.WriteLine(pint.ConvertTo(Unit.Parse("ml")));
        }
	}
}
