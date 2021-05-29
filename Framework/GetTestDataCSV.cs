using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace POHomeWork1.Framework
{
    class GetTestDataCSV
    {
        private static IEnumerable<string[]> GetTestData()
        {
            using (var csv = new CsvReader(new StreamReader("C:/Users/Ulledar/source/repos/POHomeWork1/Resources/NewUsers.csv"), CultureInfo.InvariantCulture))
            {
                while (csv.Read())
                {
                    string user = csv[0];
                    string pass = csv[1];
                    string first = csv[2];
                    string last = csv[3];

                    yield return new[] { user, pass, first, last };
                }
            }
        }
    }
}
