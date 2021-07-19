using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PBI.Test.BusinessLogic
{
    public static class StockParser
    {
        public static List<Models.StockData> Parse(string filePath)
        {
            using (var reader = new StreamReader(string.Format("{0}\\wwwroot\\FileDump\\{1}.csv", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location), filePath)))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return csv.GetRecords<Models.StockData>().ToList();
                }
            }
        }
    }
}
