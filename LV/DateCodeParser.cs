using System;
using System.Globalization;

namespace LV
{
    public static class DateCodeParser
    {
        /// <summary>
        /// Parses a date code and returns a <see cref="manufacturingYear"/> and <see cref="manufacturingMonth"/>.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (dateCode is null || dateCode.Length == 0)
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length > 4 || dateCode.Length < 3)
            {
                throw new ArgumentException("Incorrect data code", nameof(dateCode));
            }

            string dateYear = dateCode.Substring(0, 2).Insert(0, "19");
            string dateMonth = dateCode.Substring(2).PadLeft(2, '0');

            manufacturingYear = uint.Parse(dateYear, NumberStyles.Number, CultureInfo.CurrentCulture);
            if (manufacturingYear >= 1990 || manufacturingYear < 1980)
            {
                throw new ArgumentException("Incorrect date", nameof(manufacturingYear));
            }

            manufacturingMonth = uint.Parse(dateMonth, NumberStyles.Number, CultureInfo.CurrentCulture);
            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentException("Incorrect date", nameof(manufacturingMonth));
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (dateCode is null || dateCode.Length == 0)
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length > 6 || dateCode.Length < 5)
            {
                throw new ArgumentException("Incorrect data code", nameof(dateCode));
            }

            string dateYear = dateCode.Substring(0, 2).Insert(0, "19");
            factoryLocationCode = dateCode.Substring(dateCode.Length - 2, 2);
            string dateMonth = dateCode.Remove(dateCode.Length - 2, 2).Substring(2).PadLeft(2, '0');

            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
            if (factoryLocationCountry.Length == 0)
            {
                throw new ArgumentException("Incorrect code", nameof(factoryLocationCode));
            }

            manufacturingYear = uint.Parse(dateYear, NumberStyles.Number, CultureInfo.CurrentCulture);
            if (manufacturingYear >= 1990 || manufacturingYear < 1980)
            {
                throw new ArgumentException("Incorrect date", nameof(manufacturingYear));
            }

            manufacturingMonth = uint.Parse(dateMonth, NumberStyles.Number, CultureInfo.CurrentCulture);
            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentException("Incorrect date", nameof(manufacturingMonth));
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (dateCode is null || dateCode.Length == 0)
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("Incorrect data code", nameof(dateCode));
            }

            string dateYear = dateCode.Substring(3, 1);
            dateYear += dateCode.Substring(5);
            if (dateYear[0] == '0')
            {
                dateYear = dateYear.Insert(0, "20");
            }
            else
            {
                dateYear = dateYear.Insert(0, "19");
            }

            factoryLocationCode = dateCode.Substring(0, 2);
            string dateMonth = dateCode.Substring(2, 1);
            dateMonth += dateCode.Substring(4, 1);

            factoryLocationCountry = CountryParser.GetCountry(factoryLocationCode);
            if (factoryLocationCountry.Length == 0)
            {
                throw new ArgumentException("Incorrect code", nameof(factoryLocationCode));
            }

            manufacturingYear = uint.Parse(dateYear, NumberStyles.Number, CultureInfo.CurrentCulture);
            if (manufacturingYear < 1990 || manufacturingYear > 2006)
            {
                throw new ArgumentException("Incorrect date", nameof(manufacturingYear));
            }

            manufacturingMonth = uint.Parse(dateMonth, NumberStyles.Number, CultureInfo.CurrentCulture);
            if (manufacturingMonth < 1 || manufacturingMonth > 12)
            {
                throw new ArgumentException("Incorrect date", nameof(manufacturingMonth));
            }
        }
    }
}