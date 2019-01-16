using Afk.Measure.Quantity;
using Afk.Measure.Units;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestMeasure
{
    [TestClass]
    public class QuantityTest
    {
        [DataRow("€/Wh", "Wh", 15, 152, 2280, "€")]
        [DataRow("€.Wh-1", "Wh", 15, 152, 2280, "€")]
        [DataRow("k€.Wh-1", "Wh", 15, 152, 2280, "k€")]
        [DataRow("k€.Wh-1", "kWh", 15, 152, 2280000, "k€")]
        [DataRow("kWh-1.€", "kWh", 15, 152, 2280, "€")]
        [DataRow("m.ks-1", "ks", 15, 152, 2280, "m")]
        [DataRow("m/ks", "ks", 15, 152, 2280, "m")]
        [DataRow("km", "ks", 15, 5, 75000, "km.s")]
        [DataRow("km", "s", 15, 5, 75, "km.s")]
        [DataRow("ks", "kh", 15, 152, 2280000, "ks.h")]
        [DataTestMethod]
        public void TestEuroMWh(string unitA, string unitB, double valueA, double valueB, double expectedValue, string expectedUnit)
        {
            // L'erreur c'est qu'on perd le -1 sur le prefixe kilo kWh-1 devient km-2.s3.h-1.kg-1

            Assert.AreEqual(true, Unit.TryParse(unitA, out Unit uA));
            Assert.AreEqual(true, Unit.TryParse(unitB, out Unit uB));

            Quantity<double> qA = new Quantity<double>(valueA, uA);
            Quantity<double> qB = new Quantity<double>(valueB, uB);

            var qty = (qA * qB);
            Assert.AreEqual(expectedValue, qty.Value);
            Assert.AreEqual(expectedUnit, qty.Unit.Symbol.Replace((char)183, '.'));
        }

        //[DataRow("c€/Wh", "Wh", 15, 152, 2280, "c€")]
        //[DataRow("c€/kWh", "kWh", 15, 152, 2280, "c€")]
        [DataRow("c€/kWh", "MWh", 15, 152, 2280000, "c€")]
        [DataTestMethod]
        public void TestCentiEuroMWh(string unitA, string unitB, double valueA, double valueB, double expectedValue, string expectedUnit)
        {
            Assert.AreEqual(true, Unit.TryParse(unitA, out Unit uA));
            Assert.AreEqual(true, Unit.TryParse(unitB, out Unit uB));

            Quantity<double> qA = new Quantity<double>(valueA, uA);
            Quantity<double> qB = new Quantity<double>(valueB, uB);

            var qty = (qA * qB);
            Assert.AreEqual(expectedValue, Math.Round(qty.Value, 0));
            Assert.AreEqual(expectedUnit, qty.Unit.Symbol.Replace((char)183, '.'));
        }

        [TestCategory("Quantity")]
        [Description("Inverse")]
        [TestMethod]
        public void TestInverse()
        {
            Quantity<double> q1 = new Quantity<double>(5, "ks-1");
            Assert.AreEqual(0.005, q1.ConvertTo("s-1").Value);

            q1 = new Quantity<double>(5, "km2.m-2.s-1").ConvertTo("s-1");
            Assert.AreEqual(5000000, q1.Value);

            q1 = new Quantity<double>(5, "km2/m2.s").ConvertTo("s-1");
            Assert.AreEqual(5000000, q1.Value);
        }

        [TestCategory("Quantity")]
        [Description("Prefix power")]
        [TestMethod]
        public void TestPrefixPower()
        {
            Quantity<double> q1 = new Quantity<double>(1, "km2");
            Quantity<double> q2 = q1.ConvertTo("m2");

            // 1 km2 = 1 km * 1km = 1000 m * 1000 m = 1000000m 2
            Assert.AreEqual(1000000, q2.Value);
            Assert.AreEqual("m2", q2.Unit.Symbol);
        }

        [TestCategory("Quantity")]
        [Description("Energy")]
        [TestMethod]
        public void TestEnergy()
        {
            Quantity<double> q1 = new Quantity<double>(1, "kJ");
            Quantity<double> q2 = q1.ConvertTo("Wh");

            // 1 kJ == 1000J = 1000/3600 Wh
            Assert.AreEqual(1000d/3600d, q2.Value);
            Assert.AreEqual("Wh", q2.Unit.Symbol);

            q1 = new Quantity<double>(1, "kWh");
            q2 = q1.ConvertTo("J");

            // 1 kWh == 1000 Wh = 1000 * 3600 J
            Assert.AreEqual(1000 * 3600, q2.Value);
            Assert.AreEqual("J", q2.Unit.Symbol);

            q1 = new Quantity<double>(1, "kWh2");
            q2 = q1.ConvertTo("Wh2");

            // 1 kWh2 == 1000000 Wh2
            Assert.AreEqual(1000000, q2.Value);
        }

        [TestCategory("Quantity")]
        [Description("Prefixes")]
        [TestMethod]
        public void TestPrefix()
        {
            Quantity<double> q1 = new Quantity<double>(1, "m.ks");
            Assert.AreEqual("ks.m", q1.Unit.Symbol.Replace((char)183, '.'));

            q1 = new Quantity<double>(1, "ks-1");
            Quantity<double> q2 = new Quantity<double>(1, "s");
            var q3 = q1 * q2;
            Assert.AreEqual(0.001, q3.Value);
            Assert.AreEqual(BaseUnit.UNITONE, q3.Unit);
        }

        [TestCategory("Quantity")]
        [Description("Merge units")]
        [TestMethod]
        public void TestMergeUnit()
        {
            Quantity<double> q1 = new Quantity<double>(1, "m.km2");
            Assert.AreEqual("km3", q1.Unit.Symbol.Replace((char)183, '.'));

            // 5m * 2km2 = 5m * 2000000m2= 10000000m3
            q1 = new Quantity<double>(5, "m");
            Quantity<double> q2 = new Quantity<double>(2, "km2");
            var q3 = q1 * q2;
            // Unit given in first operand prefix
            Assert.AreEqual("m3", q3.Unit.Symbol.Replace((char)183, '.'));
            Assert.AreEqual(10000000, q3.Value);

            q1 = new Quantity<double>(2, "km2");
            q2 = new Quantity<double>(5, "m");
            q3 = q1 * q2;
            // Unit given in first operand prefix
            Assert.AreEqual("km3", q3.Unit.Symbol.Replace((char)183, '.'));
            Assert.AreEqual(0.01, q3.Value);

            // 2 km * 5 das = 2000m * 50s = 100000 ms = 100 kms
            q1 = new Quantity<double>(2, "km");
            q2 = new Quantity<double>(5, "das");
            q3 = q1 * q2;
            Assert.AreEqual("km.s", q3.Unit.Symbol.Replace((char)183, '.'));
            Assert.AreEqual(100, q3.Value);

            // 2 km * 5 ks-1 = 2000m * 0.005s = 10 m.s-1 = 0.01 km.s-1
            q1 = new Quantity<double>(2, "km");
            q2 = new Quantity<double>(5, "ks-1");
            q3 = q1 * q2;
            Assert.AreEqual("m.s-1", q3.Unit.Symbol.Replace((char)183, '.'));
            Assert.AreEqual(10, q3.Value);

            q1 = new Quantity<double>(2, "km");
            q2 = new Quantity<double>(5, "ks");
            q3 = q1 / q2;
            Assert.AreEqual("m.s-1", q3.Unit.Symbol.Replace((char)183, '.'));
            Assert.AreEqual(0.4, q3.Value);
        }

        [TestCategory("Quantity")]
        [Description("Exponent on prefix")]
        [TestMethod]
        public void TestKiloWh()
        {
            // Teste "kWh-1.€" * "kWh"
            // L'erreur serait de perdre le -1 sur le prefixe kilo kWh-1 qui deviendrait km-2.s3.h-1.kg-1 avec un exposant 2 sur kilo
            Quantity<double> q1 = new Quantity<double>(5, "kWh-1.€");
            Quantity<double> q2 = new Quantity<double>(2, "kWh");
            var q3 = q1 * q2;

            // Avoid Precision error by using decimal
            var d = 10d;
            Assert.AreEqual(d, q3.Value);
            Assert.AreEqual("€", q3.Unit.Symbol);

            q1 = new Quantity<double>(5, "€/MWh");
            q2 = new Quantity<double>(2000, "kWh");
            q3 = (q1 * q2).ConvertTo("€");
            Assert.AreEqual(10, q3.Value);
            Assert.AreEqual("€", q3.Unit.Symbol);
        }

        [TestCategory("Quantity")]
        [Description("Exponent on prefix")]
        [TestMethod]
        public void TestBestConverter()
        {
            // m.°C * °C 
            Quantity<double> q1 = new Quantity<double>(5, "m.°C");
            Quantity<double> q2 = new Quantity<double>(2, "°C");
            var q3 = q1 * q2;

            Assert.AreEqual(10, q3.Value);
            Assert.AreEqual("m.°C2", q3.Unit.Symbol.Replace((char)183, '.'));
        }
    }
}
