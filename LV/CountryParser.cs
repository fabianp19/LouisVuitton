using System;

namespace LV
{
    public static class CountryParser
    {
        /// <summary>
        /// Gets an array of <see cref="Country"/> enumeration values for a specified factory location code. One location code can belong to many countries.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <returns>An array of <see cref="Country"/> enumeration values.</returns>
        public static Country[] GetCountry(string factoryLocationCode)
        {
            Validate(factoryLocationCode);

            string[][] tab = CreateTable();

            Country[] values = Array.Empty<Country>();

            var k = 0;
            for (var i = 0; i < tab.Length; i++)
            {
                for (var j = 0; j < tab[i].Length; j++)
                {
                    if (factoryLocationCode == tab[i][j])
                    {
                        Array.Resize(ref values, k + 1);
                        values[k] = (Country)i;
                        k++;
                    }
                }
            }

            return values;
        }

        private static void Validate(string factoryLocationCode)
        {
            if (factoryLocationCode is null || factoryLocationCode.Length == 0)
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }
        }

        private static string[][] CreateTable()
        {
            string[][] tab = new string[6][];
            tab[0] = new string[] { "A0", "A1", "A2", "AA", "AH", "AN", "AR", "AS", "BA", "BJ", "BU", "DR", "DU", "DT", "CO", "CT", "CX", "ET", "FL", "LW",
                                    "MB", "MI", "NO", "RA", "RI", "SD", "SF", "SL", "SN", "SP", "SR", "TA", "TJ", "TH", "TN", "TR", "TS", "VI", "VX" };
            tab[1] = new string[] { "LP", "OL" };
            tab[2] = new string[] { "BC", "BO", "CE", "FN", "FO", "MA", "NZ", "OB", "PL", "RC", "RE", "SA", "TD" };
            tab[3] = new string[] { "CA", "LO", "LB", "LM", "LW", "GI", "UB" };
            tab[4] = new string[] { "DI", "FA" };
            tab[5] = new string[] { "FC", "FH", "LA", "OS", "SD", "FL", "TX" };

            return tab;
        }
    }
}