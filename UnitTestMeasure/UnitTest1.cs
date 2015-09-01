﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Afk.Measure;
using Afk.Measure.Units;
using Afk.Measure.Units.System;

namespace UnitTestMeasure
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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