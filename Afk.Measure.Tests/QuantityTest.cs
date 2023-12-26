using Afk.Measure.Units;
using Afk.Measure.Units.Metric.Prefixes;
using Afk.Measure.Quantity;

namespace Afk.Measure.Tests
{
    public class QuantityTest
    {
        [Theory]
        [InlineData("€/Wh", "Wh", 15, 152, 2280, "€")]
        [InlineData("€.Wh-1", "Wh", 15, 152, 2280, "€")]
        [InlineData("k€.Wh-1", "Wh", 15, 152, 2280, "k€")]
        [InlineData("k€.Wh-1", "kWh", 15, 152, 2280000, "k€")]
        [InlineData("kWh-1.€", "kWh", 15, 152, 2280, "€")]
        [InlineData("m.ks-1", "ks", 15, 152, 2280, "m")]
        [InlineData("m/ks", "ks", 15, 152, 2280, "m")]
        [InlineData("km", "ks", 15, 5, 75000, "km.s")]
        [InlineData("km", "s", 15, 5, 75, "km.s")]
        [InlineData("ks", "kh", 15, 152, 2280000, "ks.h")]
        public void TestEuroMWh(string unitA, string unitB, double valueA, double valueB, double expectedValue, string expectedUnit)
        {
            // L'erreur c'est qu'on perd le -1 sur le prefixe kilo kWh-1 devient km-2.s3.h-1.kg-1

            Assert.True(Unit.TryParse(unitA, out Unit uA));
            Assert.True(Unit.TryParse(unitB, out Unit uB));

            Quantity<double> qA = new Quantity<double>(valueA, uA);
            Quantity<double> qB = new Quantity<double>(valueB, uB);

            var qty = (qA * qB);
            Assert.Equal(expectedValue, qty.Value);
            Assert.Equal(expectedUnit, qty.Unit.Symbol.Replace((char)183, '.'));
        }

        [Theory]
        //[DataRow("c€/Wh", "Wh", 15, 152, 2280, "c€")]
        //[DataRow("c€/kWh", "kWh", 15, 152, 2280, "c€")]
        [InlineData("c€/kWh", "MWh", 15, 152, 2280000, "c€")]
        public void TestCentiEuroMWh(string unitA, string unitB, double valueA, double valueB, double expectedValue, string expectedUnit)
        {
            Assert.True(Unit.TryParse(unitA, out Unit uA));
            Assert.True(Unit.TryParse(unitB, out Unit uB));

            Quantity<double> qA = new Quantity<double>(valueA, uA);
            Quantity<double> qB = new Quantity<double>(valueB, uB);

            var qty = (qA * qB);
            Assert.Equal(expectedValue, Math.Round(qty.Value, 0));
            Assert.Equal(expectedUnit, qty.Unit.Symbol.Replace((char)183, '.'));
        }

        [Trait("Category", "Quantity")]
        [Fact]
        public void TestInverse()
        {
            Quantity<double> q1 = new Quantity<double>(5, "ks-1");
            Assert.Equal(0.005, q1.ConvertTo("s-1").Value);

            q1 = new Quantity<double>(5, "km2.m-2.s-1").ConvertTo("s-1");
            Assert.Equal(5000000, q1.Value);

            q1 = new Quantity<double>(5, "km2/m2.s").ConvertTo("s-1");
            Assert.Equal(5000000, q1.Value);
        }

        [Trait("Category","Quantity")]
        [Fact]
        public void TestPrefixPower()
        {
            Quantity<double> q1 = new Quantity<double>(1, "km2");
            Quantity<double> q2 = q1.ConvertTo("m2");

            // 1 km2 = 1 km * 1km = 1000 m * 1000 m = 1000000m 2
            Assert.Equal(1000000, q2.Value);
            Assert.Equal("m2", q2.Unit.Symbol);
        }

        [Trait("Category","Quantity")]
        [Fact]
        public void TestEnergy()
        {
            Quantity<double> q1 = new Quantity<double>(1, "kJ");
            Quantity<double> q2 = q1.ConvertTo("Wh");

            // 1 kJ == 1000J = 1000/3600 Wh
            Assert.Equal(1000d / 3600d, q2.Value);
            Assert.Equal("Wh", q2.Unit.Symbol);

            q1 = new Quantity<double>(1, "kWh");
            q2 = q1.ConvertTo("J");

            // 1 kWh == 1000 Wh = 1000 * 3600 J
            Assert.Equal(1000 * 3600, q2.Value);
            Assert.Equal("J", q2.Unit.Symbol);

            q1 = new Quantity<double>(1, "kWh2");
            q2 = q1.ConvertTo("Wh2");

            // 1 kWh2 == 1000000 Wh2
            Assert.Equal(1000000, q2.Value);
        }

        [Trait("Category","Quantity")]
        [Fact]
        public void TestPrefix()
        {
            Quantity<double> q1 = new Quantity<double>(1, "m.ks");
            Assert.Equal("ks.m", q1.Unit.Symbol.Replace((char)183, '.'));

            q1 = new Quantity<double>(1, "ks-1");
            Quantity<double> q2 = new Quantity<double>(1, "s");
            var q3 = q1 * q2;
            Assert.Equal(0.001, q3.Value);
            Assert.Equal(BaseUnit.UNITONE, q3.Unit);
        }

        [Trait("Category","Quantity")]
        [Fact]
        public void TestMergeUnit()
        {
            Quantity<double> q1 = new Quantity<double>(1, "m.km2");
            Assert.Equal("km3", q1.Unit.Symbol.Replace((char)183, '.'));

            // 5m * 2km2 = 5m * 2000000m2= 10000000m3
            q1 = new Quantity<double>(5, "m");
            Quantity<double> q2 = new Quantity<double>(2, "km2");
            var q3 = q1 * q2;
            // Unit given in first operand prefix
            Assert.Equal("m3", q3.Unit.Symbol.Replace((char)183, '.'));
            Assert.Equal(10000000, q3.Value);

            q1 = new Quantity<double>(2, "km2");
            q2 = new Quantity<double>(5, "m");
            q3 = q1 * q2;
            // Unit given in first operand prefix
            Assert.Equal("km3", q3.Unit.Symbol.Replace((char)183, '.'));
            Assert.Equal(0.01, q3.Value);

            // 2 km * 5 das = 2000m * 50s = 100000 ms = 100 kms
            q1 = new Quantity<double>(2, "km");
            q2 = new Quantity<double>(5, "das");
            q3 = q1 * q2;
            Assert.Equal("km.s", q3.Unit.Symbol.Replace((char)183, '.'));
            Assert.Equal(100, q3.Value);

            // 2 km * 5 ks-1 = 2000m * 0.005s = 10 m.s-1 = 0.01 km.s-1
            q1 = new Quantity<double>(2, "km");
            q2 = new Quantity<double>(5, "ks-1");
            q3 = q1 * q2;
            Assert.Equal("m.s-1", q3.Unit.Symbol.Replace((char)183, '.'));
            Assert.Equal(10, q3.Value);

            q1 = new Quantity<double>(2, "km");
            q2 = new Quantity<double>(5, "ks");
            q3 = q1 / q2;
            Assert.Equal("m.s-1", q3.Unit.Symbol.Replace((char)183, '.'));
            Assert.Equal(0.4, q3.Value);
        }

        [Trait("Category","Quantity")]
        [Fact]
        public void TestKiloWh()
        {
            // Teste "kWh-1.€" * "kWh"
            // L'erreur serait de perdre le -1 sur le prefixe kilo kWh-1 qui deviendrait km-2.s3.h-1.kg-1 avec un exposant 2 sur kilo
            Quantity<double> q1 = new Quantity<double>(5, "kWh-1.€");
            Quantity<double> q2 = new Quantity<double>(2, "kWh");
            var q3 = q1 * q2;

            // Avoid Precision error by using decimal
            var d = 10d;
            Assert.Equal(d, q3.Value);
            Assert.Equal("€", q3.Unit.Symbol);

            q1 = new Quantity<double>(5, "€/MWh");
            q2 = new Quantity<double>(2000, "kWh");
            q3 = (q1 * q2).ConvertTo("€");
            Assert.Equal(10, q3.Value);
            Assert.Equal("€", q3.Unit.Symbol);
        }

        [Trait("Category","Quantity")]
        [Fact]
        public void TestBestConverter()
        {
            // m.°C * °C 
            Quantity<double> q1 = new Quantity<double>(5, "m.°C");
            Quantity<double> q2 = new Quantity<double>(2, "°C");
            var q3 = q1 * q2;

            Assert.Equal(10, q3.Value);
            Assert.Equal("m.°C2", q3.Unit.Symbol.Replace((char)183, '.'));
        }
    }
}
