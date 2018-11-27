using Afk.Measure.Quantity;
using Afk.Measure.Units;
using Afk.Measure.Units.Metric.Derived;
using Afk.Measure.Units.Metric.Prefixes;
using Afk.Measure.Units.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMeasure
{
    [TestClass]
    public class UnitTest
    {
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
        [DataRow("m.s", "m.s")]
        [DataTestMethod]
        public void TestUnitParsing(string unit, string expected)
        {
            Assert.AreEqual(expected, Unit.Parse(unit).Symbol.Replace((char)183, '.'));
        }

        [TestMethod]
        public void TestUnitDeca()
        {
            Assert.AreEqual(true, Unit.TryParse("dam", out Unit unit));
            Assert.AreEqual("dam", unit.Symbol);
            Assert.AreEqual(typeof(PrefixUnit), unit.GetType());
            Assert.AreEqual(SIPrefixe.Deka, ((PrefixUnit)unit).Prefixe);
        }

        [TestMethod]
        public void TestWrongUnit()
        {
            Assert.ThrowsException<UnitException>(() => Unit.Parse("km.ks"));
            Assert.ThrowsException<UnitException>(() => Unit.Parse("ks-1.s"));
        }

        [TestMethod]
        public void TestUnitOneParse()
        {
            var unit = Unit.Parse(string.Empty);
            Assert.AreEqual(unit, BaseUnit.UNITONE);
        }

        [TestMethod]
        public void TestkWh2()
        {
            var unit = Unit.Parse("kWh2");
            Assert.AreEqual("kWh2", unit.Symbol);
        }

        [TestMethod]
        public void TestPrefixVanish()
        {
            var unit = Unit.Parse("km2/Ms");
            Assert.AreEqual("m2.s-1", unit.Symbol.Replace((char)183, '.'));
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
