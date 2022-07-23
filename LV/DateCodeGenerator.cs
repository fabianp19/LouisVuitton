using System;
using System.Globalization;

namespace LV
{
    public static class DateCodeGenerator
    {
        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980(uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            manufacturingYear %= 100;
            return Convert.ToString(manufacturingYear) + Convert.ToString(manufacturingMonth);
        }

        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(DateTime manufacturingDate)
        {
            if (manufacturingDate.Year < 1980 || manufacturingDate.Year >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            var year = manufacturingDate.Year % 100;
            var month = manufacturingDate.Month;

            return $"{year}{month}";
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            ValidateLate1980Code(factoryLocationCode, manufacturingYear, manufacturingMonth);

            manufacturingYear %= 100;
            return Convert.ToString(manufacturingYear) + Convert.ToString(manufacturingMonth) + factoryLocationCode.ToUpper(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            ValidateLate1980Code(factoryLocationCode, manufacturingDate);

            var year = manufacturingDate.Year % 100;
            var month = manufacturingDate.Month;

            return $"{year}{month}{factoryLocationCode.ToUpper(CultureInfo.CurrentCulture)}";
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            Validate1990Code(factoryLocationCode, manufacturingYear, manufacturingMonth);

            manufacturingYear %= 100;
            var year = Convert.ToString(manufacturingYear);
            var month = Convert.ToString(manufacturingMonth);
            year = year.PadLeft(2, '0');
            month = month.PadLeft(2, '0');

            return factoryLocationCode.ToUpper(CultureInfo.CurrentCulture) + month[0] + year[0] + month[1] + year[1];
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            Validate1990Code(factoryLocationCode, manufacturingDate);

            var year = (manufacturingDate.Year % 100).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
            var month = manufacturingDate.Month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');

            return $"{factoryLocationCode.ToUpper(CultureInfo.CurrentCulture)}{month[0]}{year[0]}{month[1]}{year[1]}";
        }

        private static void ValidateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1980 || manufacturingYear >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            if (factoryLocationCode is null)
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length == 0)
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2)
            {
                throw new ArgumentException("Too many characters in factory location code", nameof(factoryLocationCode));
            }

            if (!char.IsLetter(factoryLocationCode, 0) || !char.IsLetter(factoryLocationCode, 1))
            {
                throw new ArgumentException("Factory location code is incorrect", nameof(factoryLocationCode));
            }
        }

        private static void ValidateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (manufacturingDate.Year < 1980 || manufacturingDate.Year >= 1990)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (factoryLocationCode is null)
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length == 0)
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2)
            {
                throw new ArgumentException("Too many characters in factory location code", nameof(factoryLocationCode));
            }

            if (!char.IsLetter(factoryLocationCode, 0) || !char.IsLetter(factoryLocationCode, 1))
            {
                throw new ArgumentException("Factory location code is incorrect", nameof(factoryLocationCode));
            }
        }

        private static void Validate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1990 || manufacturingYear >= 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            if (factoryLocationCode is null)
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length == 0)
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2)
            {
                throw new ArgumentException("Too many characters in factory location code", nameof(factoryLocationCode));
            }

            if (!char.IsLetter(factoryLocationCode, 0) || !char.IsLetter(factoryLocationCode, 1))
            {
                throw new ArgumentException("Factory location code is incorrect", nameof(factoryLocationCode));
            }
        }

        private static void Validate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (manufacturingDate.Year < 1990 || manufacturingDate.Year > 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            if (factoryLocationCode is null)
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length == 0)
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (factoryLocationCode.Length != 2)
            {
                throw new ArgumentException("Too many characters in factory location code", nameof(factoryLocationCode));
            }

            if (!char.IsLetter(factoryLocationCode, 0) || !char.IsLetter(factoryLocationCode, 1))
            {
                throw new ArgumentException("Factory location code is incorrect", nameof(factoryLocationCode));
            }
        }
    }
}