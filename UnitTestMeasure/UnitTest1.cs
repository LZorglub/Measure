using Afk.Measure.Quantity;
using Afk.Measure.Units;
using Afk.Measure.Units.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMeasure
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow("€/Wh", "Wh", 15, 152, 2280, "€")]
        [DataRow("€.Wh-1", "Wh", 15, 152, 2280, "€")]
        [DataRow("k€.Wh-1", "Wh", 15, 152, 2280, "k€")]
        [DataRow("k€.Wh-1", "kWh", 15, 152, 2280000, "k€")]
        //[DataRow("kWh-1.€", "kWh", 15, 152, 2280, "k€")]
        //[DataRow("m/ks", "ks", 15, 152, 2280, "m")]
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
            Assert.AreEqual(expectedUnit, qty.Unit.Symbol.Replace((char)183,'.'));
        }

        [TestMethod]
        public void Testkg()
        {
            Unit kg;
            if (Unit.TryParse("kg", out kg))
            {
                Assert.AreEqual(kg.Symbol, SI.GRAM.Symbol);
            } else
            {
                Assert.Fail("Not able to parse kg");
            }
        }

        [TestCategory("Parsing")]
        [DataRow("km/s.m", "ks-1")]
        [DataRow("km/ks", "m.s-1")]
        //[DataRow("kg/ks", "g.s-1")]
        [DataRow("1/s", "s-1")]
        [DataTestMethod]
        public void TestUnitParsing(string unit, string expected)
        {
            Assert.AreEqual(expected, Unit.Parse(unit).Symbol.Replace((char)183, '.'));
        }

        [TestMethod]
        public void TestUnitOneParse()
        {
            var unit = Unit.Parse(string.Empty);
            Assert.AreEqual(unit, BaseUnit.UNITONE);
        }

        [TestMethod]
        public void TestLocalizableUnit()
        {
            Unit gal = Unit.Parse("gal US");
            Assert.AreEqual(gal.GetType(), new Afk.Measure.Units.US.Gallon().GetType());

            gal = Unit.Parse("gal");
            Assert.AreEqual(gal.GetType(), new Afk.Measure.Units.Imperial.Gallon().GetType());
        }
    }
}
