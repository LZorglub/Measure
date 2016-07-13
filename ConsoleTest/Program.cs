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
using System.Reflection;

namespace ConsoleTest {
	class Program {

        static void Test()
        {
            double d = 15d;
            int a = 8;

            Unit u = (Unit)"m";
            Quantity<double> qty = 15 * u;
            Quantity<int> qtyInt = (Quantity<int>)(15 * u);
            Length<int> lg = 15;

            Quantity<double> result = qty * lg;
        }

		static void Main(string[] args) {
			try {

                LoadAssembly(); 

                CustomUnit();

                Test();

                Quantity<double> dd = 20; // Quantity unitless
                Acceleration<double> acc = 15; // Acceleration m.s-2
                Quantity<double> kg = 10 * SI.GRAM; // Gram 10kg
                Length<int> meter = 2; // Length 2m
                Quantity<double> meterAcc = acc * meter; // Quantity multiplication
                var tempK = Quantity.From<double>(SI.KELVIN, 293.15); // Quantity From
                var tempC = new Quantity<double>(20, "°C"); // Quantity constructor
                bool compare = tempK == tempC;

                Unit unit = Unit.Parse("ms"); // Represents the milliseconds
                bool boolean = Unit.TryParse("skg", out unit); // Returns false
                boolean = Unit.TryParse("s.kg", out unit); // Returns true, seconds * gram
                unit = (Unit)"Wh"; // Represents the WattHour
                unit = SIPrefixe.Kilo * SI.METER; // Represents the km
                unit = (Unit)"m-2.kg/s"; // Represents m-2.kg.s-1

                // Currency exchange (ThreadLocalStorage)
                using (var context = new CurrencyContext())
                {
                    context.AddOrReplaceConverter("$", 0.87745);
                    context.AddOrReplaceConverter("¥", 0.00785);

                    var dollar = 1 * Unit.Parse("$");
                    Console.WriteLine("{0} Dollar to Yen : {1}", dollar.Value, dollar.ConvertTo("¥").Value);
                }

                Quantity<double> temperature = 5 * SI.KELVIN;
                var speed = 5 * (SIPrefixe.Kilo * SI.METER);
                var speed2 = 5 * (Unit)"km.s-1";

                // Watthour
                var wh1 = 10 * (Unit)"Wh";
                var watt1 = wh1 / (3600 * SI.SECOND);
                var wh2 = watt1 * (7200 * SI.SECOND);

                // mol/kg
                var mol = 1 * SI.MOLE;
                var molKg = mol / (1*SI.GRAM);

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

				var qd = new Quantity<double>(5, "m3");

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

                Quantity<double> q1 = 15d;
                /*
				var m2 = Quantity.Kilo<Meter>(5);
				var c = Quantity.None<double, Celsius>(6);
				var k = Quantity.None<double, Kelvin>(8);
				var second = Quantity.None<double, Second>(4);
				var hour = Quantity.None<double, Hour>(4);

				var item = (m2 * c) / (second * k);
				*/
                //Quantity<double> doubleHour = 5d;

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
            Console.WriteLine(litre.ConvertTo("m3"));

            var pint = Quantity.None<Afk.Measure.Units.US.Pint>(1);
            Console.WriteLine(pint.ConvertTo(Unit.Parse("ml")));
        }

        static void LoadAssembly()
        {
            Unit[] units = Unit.WellKnownUnits;
            Console.WriteLine(units.FirstOrDefault(e => e.Symbol == "cal")?.Symbol);
            Unit.LoadAssembly(Assembly.GetExecutingAssembly());
            units = Unit.WellKnownUnits;
            Console.WriteLine(units.FirstOrDefault(e => e.Symbol == "cal")?.Symbol);
        }

        static void CustomUnit()
        {
            Calorie cal = new Calorie();
            var qtyCal = 1 * cal;

            Console.WriteLine(qtyCal.ConvertTo<Joule>());
        }
	}
}
