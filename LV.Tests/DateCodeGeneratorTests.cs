using System;
using NUnit.Framework;

namespace LV.Tests
{
    [TestFixture]
    public class DateCodeGeneratorTests
    {
        [TestCase(1979u, 1u)]
        [TestCase(1990u, 1u)]
        [TestCase(1980u, 13u)]
        public void GenerateEarly1980_ParameterIsOutOfRange_ThrowsArgumentOutOfRangeException(uint manufacturingYear, uint manufacturingMonth)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.GenerateEarly1980(manufacturingYear, manufacturingMonth));
        }

        [TestCase(1980u, 1u, "801")]
        [TestCase(1980u, 12u, "8012")]
        [TestCase(1983u, 6u, "836")]
        [TestCase(1986u, 1u, "861")]
        [TestCase(1986u, 12u, "8612")]
        public void GenerateEarly1980_ParametersAreValid_ReturnsResult(uint manufacturingYear, uint manufacturingMonth, string expectedResult)
        {
            string actual = DateCodeGenerator.GenerateEarly1980(manufacturingYear, manufacturingMonth);
            Assert.AreEqual(expectedResult, actual);
        }

        private static readonly object[][] GenerateEarly1980CodeOutOfRangeData =
        {
            new object[] { new DateTime(1979, 12, 1) },
            new object[] { new DateTime(1990, 1, 1) },
        };
        
        [TestCaseSource(nameof(GenerateEarly1980CodeOutOfRangeData))]
        public void GenerateEarly1980Code_DateTime_ParameterIsOutOfRange_ThrowsArgumentOutOfRangeException(object[] data)
        {
            DateTime dateTime = (DateTime)data[0];
            
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.GenerateEarly1980Code(dateTime));
        }

        private static readonly object[][] GenerateEarly1980CodeData =
        {
            new object[] { new DateTime(1980, 1, 1), "801" },
            new object[] { new DateTime(1980, 12, 1), "8012" },
            new object[] { new DateTime(1983, 6, 1), "836" },
            new object[] { new DateTime(1986, 1, 1), "861" },
            new object[] { new DateTime(1986, 12, 1), "8612" },
        };

        [TestCaseSource(nameof(GenerateEarly1980CodeData))]
        public void GenerateEarly1980Code_DateTime_ParametersAreValid_ReturnsResult(object[] data)
        {
            DateTime dateTime = (DateTime)data[0];
            string expectedResult = (string)data[1];
            
            string actualResult = DateCodeGenerator.GenerateEarly1980Code(dateTime);
            
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(null)]
        [TestCase("")]
        public void GenerateLate1980Code_FactoryLocationCodeIsNullOrEmpty_ThrowsArgumentNullException(string factoryLocationCode)
        {
            Assert.Throws<ArgumentNullException>(() => DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, 1986, 1));
        }

        [TestCase(1979u, 1u)]
        [TestCase(1990u, 1u)]
        [TestCase(1980u, 13u)]
        public void GenerateLate1980Code_ProductionYearOrMonthIsOutOfRange_ThrowsArgumentOutOfRangeException(uint manufacturingYear, uint manufacturingMonth)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.GenerateLate1980Code("BC", manufacturingYear, manufacturingMonth));
        }

        [TestCase("79")]
        [TestCase("b9")]
        [TestCase("7b")]
        [TestCase("abc")]
        [TestCase("b")]
        public void GenerateLate1980Code_ParameterIsOutOfRange_ThrowsArgumentException(string factoryLocationCode)
        {
            Assert.Throws<ArgumentException>(() => DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, 1986, 1));
        }

        private static readonly object[][] GenerateLate1980CodeOutOfRangeData =
        {
            new object[] { "bc", new DateTime(1979, 12, 1), },
            new object[] { "vx", new DateTime(1990, 1, 1), },
        };

        [TestCaseSource(nameof(GenerateLate1980CodeOutOfRangeData))]
        public void GenerateLate1980Code_DateTime_ParameterIsOutOfRange_ThrowsArgumentOutOfRangeException(object[] data)
        {
            string factoryLocationCode = (string)data[0];
            DateTime dateTime = (DateTime)data[1];
            
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, dateTime));
        }

        [TestCase("bc", 1987u, 1u, ExpectedResult = "871BC")]
        [TestCase("vx", 1987u, 4u, ExpectedResult = "874VX")]
        [TestCase("lw", 1989u, 9u, ExpectedResult = "899LW")]
        public string GenerateLate1980Code_ParametersAreValid_ReturnsResult(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            return DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, manufacturingYear, manufacturingMonth);
        }

        private static readonly object[][] GenerateLate1980CodeData =
        {
            new object[] { "bc", new DateTime(1987, 1, 1), "871BC" },
            new object[] { "lp", new DateTime(1987, 12, 1), "8712LP" },
            new object[] { "Vx", new DateTime(1987, 4, 1), "874VX" },
            new object[] { "FC", new DateTime(1989, 2, 1), "892FC" },
            new object[] { "dI", new DateTime(1989, 12, 1), "8912DI" },
        };

        [TestCaseSource(nameof(GenerateLate1980CodeData))]
        public void GenerateLate1980Code_DateTime_ParametersAreValid_ReturnsResult(object[] data)
        {
            string factoryLocationCode = (string)data[0];
            DateTime dateTime = (DateTime)data[1];
            string expectedResult = (string)data[2];
            
            string actualResult = DateCodeGenerator.GenerateLate1980Code(factoryLocationCode, dateTime);
            
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1989u, 1u)]
        [TestCase(2007u, 1u)]
        [TestCase(1990u, 13u)]
        public void Generate1990Code_ProductionYearOrMonthIsOutOfRange_ThrowsArgumentOutOfRangeException(uint manufacturingYear, uint manufacturingMonth)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.Generate1990Code("BC", manufacturingYear, manufacturingMonth));
        }

        [TestCase(null)]
        [TestCase("")]
        public void Generate1990Code_FactoryLocationCodeIsNullOrEmpty_ThrowsArgumentNullException(string factoryLocationCode)
        {
            Assert.Throws<ArgumentNullException>(() => DateCodeGenerator.Generate1990Code(factoryLocationCode, 1990, 1));
        }

        [TestCase("79")]
        [TestCase("b9")]
        [TestCase("7c")]
        [TestCase("abc")]
        [TestCase("b")]
        public void Generate1990Code_ParameterIsOutOfRange_ThrowsArgumentException(string factoryLocationCode)
        {
            Assert.Throws<ArgumentException>(() => DateCodeGenerator.Generate1990Code(factoryLocationCode, 1990, 1));
        }

        private static readonly object[][] Generate1990CodeOutOfRangeData =
        {
            new object[] { "bc", new DateTime(1989, 12, 1), },
            new object[] { "bc", new DateTime(2007, 1, 1), },
        };

        [TestCaseSource(nameof(Generate1990CodeOutOfRangeData))]
        public void Generate1990Code_DateTime_ParameterIsOutOfRange_ThrowsArgumentOutOfRangeException(object[] data)
        {
            string factoryLocationCode = (string)data[0];
            DateTime dateTime = (DateTime)data[1];
            
            Assert.Throws<ArgumentOutOfRangeException>(() => DateCodeGenerator.Generate1990Code(factoryLocationCode, dateTime));
        }

        [TestCase("th", 1990u, 1u, ExpectedResult = "TH0910")]
        [TestCase("mb", 1995u, 3u, ExpectedResult = "MB0935")]
        [TestCase("ct", 2001u, 10u, ExpectedResult = "CT1001")]
        [TestCase("vi", 2005u, 12u, ExpectedResult = "VI1025")]
        public string Generate1990Code_ParametersAreValid_ReturnsResult(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            return DateCodeGenerator.Generate1990Code(factoryLocationCode, manufacturingYear, manufacturingMonth);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Generate1990Code_DateTime_FactoryLocationCodeIsNullOrEmpty_ThrowsArgumentNullException(string factoryLocationCode)
        {
            Assert.Throws<ArgumentNullException>(() => DateCodeGenerator.Generate1990Code(factoryLocationCode, new DateTime(1990, 1, 1)));
        }

        [TestCase("79")]
        [TestCase("b9")]
        [TestCase("7c")]
        [TestCase("abc")]
        [TestCase("b")]
        public void Generate1990Code_DateTime_ParameterIsOutOfRange_ThrowsArgumentException(string factoryLocationCode)
        {
            Assert.Throws<ArgumentException>(() => DateCodeGenerator.Generate1990Code(factoryLocationCode, 1990, 1));
        }

        private static readonly object[][] Generate1990CodeData =
        {
            new object[] { "th", new DateTime(1990, 1, 1), "TH0910" },
            new object[] { "mb", new DateTime(1995, 3, 1), "MB0935" },
            new object[] { "Ct", new DateTime(2001, 10, 1), "CT1001" },
            new object[] { "VI", new DateTime(2005, 12, 1), "VI1025" },
            new object[] { "rC", new DateTime(2006, 7, 1), "RC0076" },
        };

        [TestCaseSource(nameof(Generate1990CodeData))]
        public void Generate1990Code_DateTime_ParametersAreValid_ReturnsResult(object[] data)
        {
            string factoryLocationCode = (string)data[0];
            DateTime dateTime = (DateTime)data[1];
            string expectedResult = (string)data[2];
            
            string actualResult = DateCodeGenerator.Generate1990Code(factoryLocationCode, dateTime);
            
            Assert.AreEqual(expectedResult, actualResult);
        }


    }
}