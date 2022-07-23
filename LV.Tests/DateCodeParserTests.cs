using System;
using NUnit.Framework;

namespace LV.Tests
{
    [TestFixture]
    public class DateCodeParserTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void ParseEarly1980Code_DateCodeIsNullOrEmpty_ThrowsArgumentNullException(string dateCode)
        {
            Assert.Throws<ArgumentNullException>(() => DateCodeParser.ParseEarly1980Code(dateCode, out uint _, out uint _));
        }

        [TestCase("83")]
        [TestCase("83678")]
        [TestCase("800")]
        [TestCase("8013")]
        [TestCase("791")]
        [TestCase("901")]
        public void ParseEarly1980Code_DateCodeIsInvalid_ThrowsArgumentException(string dateCode)
        {
            Assert.Throws<ArgumentException>(() => DateCodeParser.ParseEarly1980Code(dateCode, out uint _, out uint _));
        }

        [TestCase("801", 1980u, 1u)]
        [TestCase("8010", 1980u, 10u)]
        [TestCase("812", 1981u, 2u)]
        [TestCase("836", 1983u, 6u)]
        [TestCase("8312", 1983u, 12u)]
        [TestCase("864", 1986u, 4u)]
        [TestCase("8611", 1986u, 11u)]
        public void ParseEarly1980Code_DateCodeIsValid_ReturnsResult(string dateCode, uint expectedProductionYear, uint expectedProductionMonth)
        {
            DateCodeParser.ParseEarly1980Code(dateCode, out uint actualProductionYear, out uint actualProductionMonth);
            
            Assert.AreEqual(expectedProductionYear, actualProductionYear);
            Assert.AreEqual(expectedProductionMonth, actualProductionMonth);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ParseLate1980Code_DateCodeIsNullOrEmpty_ThrowsArgumentNullException(string dateCode)
        {
            Assert.Throws<ArgumentNullException>(() => DateCodeParser.ParseLate1980Code(dateCode, out Country[] _, out string _, out uint _, out uint _));
        }

        [TestCase("87VX")]
        [TestCase("87451VX")]
        [TestCase("800VX")]
        [TestCase("8013VX")]
        [TestCase("791VX")]
        [TestCase("901VX")]
        [TestCase("801QQ")]
        public void ParseLate1980Code_DateCodeIsInvalid_ThrowsArgumentException(string dateCode)
        {
            Assert.Throws<ArgumentException>(() => DateCodeParser.ParseLate1980Code(dateCode, out Country[] _, out string _, out uint _, out uint _));
        }

        [TestCase("861TH", new Country[] { Country.France }, "TH", 1986u, 1u)]
        [TestCase("8710SD", new Country[] { Country.France, Country.USA }, "SD", 1987u, 10u)]
        [TestCase("874VX", new Country[] { Country.France }, "VX", 1987u, 4u)]
        [TestCase("889FC", new Country[] { Country.USA }, "FC", 1988u, 9u)]
        [TestCase("8912FL", new Country[] { Country.France, Country.USA }, "FL", 1989u, 12u)]
        public void ParseLate1980Code_DateCodeIsValid_ReturnsResult(string dateCode, Country[] expectedCountries, string expectedFactoryLocationCode, uint expectedProductionYear, uint expectedProductionMonth)
        {
            DateCodeParser.ParseLate1980Code(dateCode, out Country[] actualCountries, out string actualFactoryLocationCode, out uint actualProductionYear, out uint actualProductionMonth);
            
            Assert.AreEqual(expectedFactoryLocationCode, actualFactoryLocationCode);
            Assert.AreEqual(expectedProductionYear, actualProductionYear);
            Assert.AreEqual(expectedProductionMonth, actualProductionMonth);
            Assert.AreEqual(expectedCountries.Length, actualCountries.Length);

            foreach (var expectedCountry in expectedCountries)
            {
                Assert.Contains(expectedCountry, actualCountries);
            }
        }

        [TestCase(null)]
        [TestCase("")]
        public void Parse1990Code_DateCodeIsNullOrEmpty_ThrowsArgumentNullException(string dateCode)
        {
            Assert.Throws<ArgumentNullException>(() => DateCodeParser.Parse1990Code(dateCode, out Country[] _, out string _, out uint _, out uint _));
        }

        [TestCase("R0017")]
        [TestCase("RI00170")]
        [TestCase("RI1930")]
        [TestCase("RI0819")]
        [TestCase("RI0017")]
        [TestCase("RI0900")]
        [TestCase("QQ0910")]
        public void Parse1990Code_DateCodeIsInvalid_ThrowsArgumentException(string dateCode)
        {
            Assert.Throws<ArgumentException>(() => DateCodeParser.Parse1990Code(dateCode, out Country[] _, out string _, out uint _, out uint _));
        }

        [TestCase("TH0910", new Country[] { Country.France }, "TH", 1990u, 1u)]
        [TestCase("FC0935", new Country[] { Country.USA }, "FC", 1995u, 3u)]
        [TestCase("SD1001", new Country[] { Country.France, Country.USA }, "SD", 2001u, 10u)]
        [TestCase("VI1025", new Country[] { Country.France }, "VI", 2005u, 12u)]
        public void Parse1990Code_DateCodeIsValid_ReturnsResult(string dateCode, Country[] expectedCountries, string expectedFactoryLocationCode, uint expectedProductionYear, uint expectedProductionMonth)
        {
            DateCodeParser.Parse1990Code(dateCode, out Country[] actualCountries, out string actualFactoryLocationCode, out uint actualProductionYear, out uint actualProductionMonth);
            
            Assert.AreEqual(expectedFactoryLocationCode, actualFactoryLocationCode);
            Assert.AreEqual(expectedProductionYear, actualProductionYear);
            Assert.AreEqual(expectedProductionMonth, actualProductionMonth);
            Assert.AreEqual(expectedCountries.Length, actualCountries.Length);

            foreach (var expectedCountry in expectedCountries)
            {
                Assert.Contains(expectedCountry, actualCountries);
            }
        }


    }
}