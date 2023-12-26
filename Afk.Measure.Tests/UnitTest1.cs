using Afk.Measure.Units;
using Afk.Measure.Units.Metric.Prefixes;

namespace Afk.Measure.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Parsekg_IsSuccess()
        {
            Unit kg;
            if (Unit.TryParse("kg", out kg))
            {
                Assert.Equal(kg.Symbol, Units.System.SI.GRAM.Symbol);
            }
            else
            {
                Assert.Fail("Not able to parse kg");
            }
        }

        [Theory]
        [Trait("Category", "Parsing")]
        [InlineData("km/s.m", "ks-1")]
        [InlineData("km/ks", "m.s-1")]
        [InlineData("1/s", "s-1")]
        [InlineData("m.s", "m.s")]
        public void ParsingStringUnit_IsSuccess(string unit, string expected)
        {
            Assert.Equal(expected, Unit.Parse(unit).Symbol.Replace((char)183, '.'));
        }

        [Fact]
        public void ParsingDecaMeter_IsSuccess()
        {
            Assert.True(Unit.TryParse("dam", out Unit unit));
            Assert.Equal("dam", unit.Symbol);
            Assert.Equal(typeof(PrefixUnit), unit.GetType());
            Assert.Equal(SIPrefixe.Deka, ((PrefixUnit)unit).Prefixe);
        }

        [Fact]
        public void ParsingIncorrectUnit_IsException()
        {
            Assert.Throws<UnitException>(() => Unit.Parse("km.ks"));
            Assert.Throws<UnitException>(() => Unit.Parse("ks-1.s"));
        }

        [Fact]
        public void ParisngUnitOne_IsSuccess()
        {
            var unit = Unit.Parse(string.Empty);
            Assert.Equal(unit, BaseUnit.UNITONE);
        }

        [Fact]
        public void ParsingkWh2_IsSuccess()
        {
            var unit = Unit.Parse("kWh2");
            Assert.Equal("kWh2", unit.Symbol);
        }

        [Fact]
        public void ParsingVA_IsSuccess()
        {
            var unit = Unit.Parse("VA");
            Assert.Equal("VA", unit.Symbol);

            unit = unit.Inverse();
            Assert.Equal("VA-1", unit.Symbol);

            unit = unit.Power(2);
            Assert.Equal("VA-2", unit.Symbol);

            unit = Unit.Parse("kVA");
            Assert.Equal("kVA", unit.Symbol);
        }

        [Fact]
        public void DividePrefixUnit_IsUnitUnPrefixed()
        {
            var unit = Unit.Parse("km2/Ms");
            Assert.Equal("m2.s-1", unit.Symbol.Replace((char)183, '.'));
        }

        [Fact]
        public void ParsingUSAndImperialUnit_IsSuccess()
        {
            Unit gal = Unit.Parse("gal US");
            Assert.Equal(gal.GetType(), new Afk.Measure.Units.US.Gallon().GetType());

            gal = Unit.Parse("gal");
            Assert.Equal(gal.GetType(), new Afk.Measure.Units.Imperial.Gallon().GetType());
        }
    }
}